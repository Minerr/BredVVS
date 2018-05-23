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

		public static List<object[]> ExecuteReader(SqlCommand command)
		{
			SqlDataReader reader = null;
			List<object[]> table = null;
			if (command.CommandType == CommandType.StoredProcedure)
			{
				using (SqlConnection con = new SqlConnection(_connectionString))
				{
					try
					{
						con.Open();
						command.Connection = con;
						reader = command.ExecuteReader();
						table = ConvertSqlDataToList(reader);
					}
					catch (SqlException e)
					{
						Console.WriteLine("" + e.Message);
					}
				}
			}
			return table;
		}

		private static List<object[]> ConvertSqlDataToList(SqlDataReader reader)
		{
			List<object[]> table = null;

			while (reader.HasRows)
			{
				table = new List<object[]>();

				int numberOfColumns = reader.FieldCount;

				// Insert column names into the table.
				object[] columnNames = new object[numberOfColumns];
				for (int i = 0; i < numberOfColumns; i++)
				{
					columnNames[i] = reader.GetName(i);
				}
				table.Add(columnNames);

				// Insert all rows into table.
				while (reader.Read())
				{
					object[] row = new object[numberOfColumns];
					reader.GetValues(row);
					table.Add(row);
				}

				reader.NextResult();
			}
			return table;
		}
	}
}
