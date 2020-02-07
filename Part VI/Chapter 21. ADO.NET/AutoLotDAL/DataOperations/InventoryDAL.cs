using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;

        public InventoryDAL() : this("Data Source = bor-srv-02; Initial Catalog = AutoLot;" +
            "User ID = sa; Password = Pass01012011")
        {
        }

        public InventoryDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection _sqlConnection = null;

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }
        }

        public List<Car> GetAllInventory()
        {
            OpenConnection();
            List<Car> inventory = new List<Car>();
            string sql = "SELECT * FROM Inventory";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader =
                    command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }

            return inventory;
        }

        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;
            string sql = $"SELECT * FROM Inventory WHERE CarId = {id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader =
                    command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };
                }
                dataReader.Close();
            }
            return car;
        }

        public void InsertAuto(string color, string make, string petName)
        {
            OpenConnection();
            string sql = $"INSERT INTO Inventory (Make, Color, PetName)" +
                $"VALUES ('{color}', '{make}', '{petName}')";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void InsertAuto(Car car)
        {
            OpenConnection();
            string sql = "INSERT INTO Inventory (Make, Color, PetName)" +
                "VALUES (@Make, @Color, @PetName)";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char//, Size = car.Make.Length
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char//, Size = car.Color.Length
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char//, Size = car.PetName.Length
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void DeleteCar(int id)
        {
            OpenConnection();
            string sql = $"DELETE FROM Inventory WHERE CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
            CloseConnection();
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();
            string sql = $"UPDATE Inventory SET PetName = '{newPetName}' WHERE CarId = '{id}')";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                //command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public string LookUpPetName(int carId)
        {
            OpenConnection();
            string carPetName;

            // Установить имя хранимой процедуры.
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Входной параметр.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@carId",
                    Value = carId,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(parameter);

                // Выходной параметр.
                parameter = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            OpenConnection();
            string fName;
            string lName;
            var cmdSelect = new SqlCommand($"SELECT * FROM Customers WHERE CustId = {custId}",
                _sqlConnection);
            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }

            // Создать объекты команд, которые представляют каждый шаг операции.
            var cmdRemove =
                new SqlCommand($"DELETE FROM Customers WHERE CustId = {custId}", _sqlConnection);
            var cmdInsert =
                new SqlCommand("INSERT INTO CreditRisks" +
                $"(FirstName, LastName) VALUES ('{fName}','{lName}')",
                _sqlConnection);

            SqlTransaction transaction = null;
            try
            {
                transaction = _sqlConnection.BeginTransaction();
                cmdInsert.Transaction = transaction;
                cmdRemove.Transaction = transaction;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // Эмулировать ошибку.
                if (throwEx)
                {
                    // Возникла ошибка, связанная с базой данных! Отказ транзакции...
                    throw new Exception("Sorry! Database error! Transaction failed...");
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
                // Любая ошибка приведет к откату транзакции.
                // Использовать условную операцию для проверки на предмет null.
                transaction?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}