using System;
using System.Data;
using System.Data.SqlClient;

namespace InterfaceContamination
{
    public class Database : IDatabase
	{
		private const string connectionString = @"InvalidConnectionString";

		public SqlParameter CalculateInvoicesReport()
		{
			using (var con = new SqlConnection(connectionString))
			{
				con.Open();
				using (var com = new SqlCommand("InvalidSqlStatement", con))
				{
					com.Parameters.AddWithValue("@Param1", null);
					var output = new SqlParameter("@Param2", null)
					{
						Direction = ParameterDirection.Output
					};
					com.ExecuteNonQuery();
					return output;
				}
			}
		}
    }
}
