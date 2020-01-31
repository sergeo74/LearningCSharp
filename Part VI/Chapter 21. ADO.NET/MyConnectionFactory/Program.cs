using static System.Console;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System;

namespace MyConnectionFactory
{
    enum DataProvider
    { SqlServer, OleDb, Odbc, None }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("**** Very Simple Connection Factory *****\n");
            // Прочитать ключ provider.
            string dataProviderString = ConfigurationManager.AppSettings["provider"];
            // Преобразовать строку в перечисление.
            DataProvider dataProvider = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = 
                    (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);

            }
            else
            {
                WriteLine("Sorry, no provider exists!"); // Поставщики отсутствуют
                ReadLine();
                return;
            }
            IDbConnection connection = GetConnection(dataProvider);
            WriteLine($"Your connection is a {connection.GetType().Name ?? "unrecognized type"}");
            ReadLine();
        }
        static IDbConnection GetConnection(DataProvider dataProvider)
        {
            IDbConnection connection = null;
            switch (dataProvider)
            {
                case DataProvider.SqlServer:
                    connection = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    connection = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    connection = new OleDbConnection();
                    break;
                    //case DataProvider.None:
                    //    break;
                    //default:
                    //    break;
            }

            return connection;
        }
    }

}
