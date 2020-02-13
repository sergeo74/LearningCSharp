using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AutoLotDAL.Bulklmport
{
    public static class ProcessBulkImport
    {
        private static SqlConnection _sqlConnection;
        private static string _connectionString =
            @"Data Source = bor-srv-02; Initial Catalog=AutoLot; User ID = sa; Password = Pass01012011";

        private static void OpenConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();
        }

        private static void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection.Close();
            }
        }

        public static void ExecuteBulkImport<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (var connection = _sqlConnection)
            {
                var bulkCopy = new SqlBulkCopy(connection);
                bulkCopy.DestinationTableName = tableName;
                var dataReader = new MyDataReader<T>(records.ToList());
                try
                {
                    bulkCopy.WriteToServer(dataReader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                finally
                {
                    CloseConnection();
                }
            }
        }

    }
}
