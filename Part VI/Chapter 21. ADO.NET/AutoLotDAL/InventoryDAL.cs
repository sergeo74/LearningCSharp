using System.Data;
using System.Data.SqlClient;


public class InventoryDAL
{
	private readonly string _connectionString;

	public InventoryDAL() : this ("Data Source = bor-srv-02; Initial Catalog = AutoLot;" +
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
}
