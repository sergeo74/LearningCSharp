using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Console;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Data Readers *****\n");

            using (SqlConnection connection = new SqlConnection())

            {
                connection.ConnectionString =
                    "Data Source= bor-srv-02; Initial Catalog=AutoLot; User ID = sa; Password = Pass01012011";
                connection.Open();
                string sql = "SELECT * FROM Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WriteLine($"-> Make: {reader["Make"]}, " +
                            $"PetName: {reader["PetName"]}," +
                            $" Color: {reader["Color"]}");
                    }
                }
            }
            
            ReadLine();
        }
    }
}
