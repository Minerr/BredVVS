using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    class EmployeeRepository : IRepository<Employee>
    {
        public void Create(Employee type)
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertEmployee", con);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@FirstName", type.Name.FirstName));
                    cmd1.Parameters.Add(new SqlParameter("@LastName", type.Name.LastName));
                }
                catch (SqlException e)
                {
                    Console.WriteLine("" + e.Message);
                }
            }
        }

        public void Delete(Employee type)
        {
            throw new NotImplementedException();
        }

        public Employee Retrieve(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee type)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByCredentials(int ID, string pass)
        {
            return;
        }
    }
}
