using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
	public static class DatabaseController
	{
		private static string _connectionString =
			"Server=EALSQL1.eal.local; " +
			"Database=DB2017_B05; " +
			"User Id=USER_B05; " +
			"Password=SesamLukOp_05;";

		public static void ExecuteNonQuerySP(SqlCommand command)
		{
			if (command.CommandType == CommandType.StoredProcedure)
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					try
					{
						con.Open();
						command.Connection = con;
						command.ExecuteNonQuery();
					}
					catch (SqlException e)
					{
						Console.WriteLine("" + e.Message);
					}
				}
			}
		}

		public static SqlDataReader ExecuteReader(SqlCommand command)
		{
			SqlDataReader table = null;
			if (command.CommandType == CommandType.StoredProcedure)
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					try
					{
						con.Open();
						command.Connection = con;
						table = command.ExecuteReader();						
					}
					catch (SqlException e)
					{
						Console.WriteLine("" + e.Message);
					}
				}
			}
			return table;
		}
	}
}
