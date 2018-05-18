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

    public class CustomerRepository : IRepository<Customer>
    {

        public void Create(Customer type)
        {
            SqlCommand command = new SqlCommand("InsertCustomer");

            command.Parameters.Add(new SqlParameter("@FirstName", type.Name.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", type.Name.LastName));
            command.Parameters.Add(new SqlParameter("@Address", type.Address));
            command.Parameters.Add(new SqlParameter("@City", type.City));
            command.Parameters.Add(new SqlParameter("@ZIPcode", type.ZIPcode));
            command.Parameters.Add(new SqlParameter("@PhoneNumber", type.PhoneNumber));
            command.Parameters.Add(new SqlParameter("@Email", type.Email));

            DatabaseController.ExecuteNonQuery(command);
        }

        public void Delete(Customer type)
        {
            SqlCommand command = new SqlCommand("DeleteCustomer", con);

            command.Parameters.Add(new SqlParameter("@ID", type.ID));
            DatabaseController.ExecuteNonQuery(command);

        }

        public Customer Retrieve(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer type)
        {
            throw new NotImplementedException();
        }
    }
}
