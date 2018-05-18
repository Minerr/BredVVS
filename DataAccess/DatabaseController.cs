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
        public static void ExecuteNonQuerySP(SqlCommand command)
        {
            if(command.CommandType == CommandType.StoredProcedure)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
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
    }
}
