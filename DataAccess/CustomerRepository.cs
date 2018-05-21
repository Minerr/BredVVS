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

        public void Create(Customer customer)
        {
            SqlCommand command = new SqlCommand("spInsertCustomer");
			command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@FirstName", customer.Name.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", customer.Name.LastName));
            command.Parameters.Add(new SqlParameter("@Address", customer.Address));
            command.Parameters.Add(new SqlParameter("@City", customer.City));
            command.Parameters.Add(new SqlParameter("@ZIPcode", customer.ZIPcode));
            command.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
            command.Parameters.Add(new SqlParameter("@Email", customer.Email));

            DatabaseController.ExecuteNonQuerySP(command);
        }

        public Customer Retrieve(int ID)
        {
	        string error = "";
	        Customer customer = null;

			SqlCommand command = new SqlCommand("spGetCustomerByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
	        SqlDataReader reader = DatabaseController.ExecuteReader(command);

	        try
	        {
		        string firstName = reader["FirstName"].ToString();
		        string lastName = reader["LastName"].ToString();
		        string address = reader["Address"].ToString();
		        string city = reader["City"].ToString();
		        string ZIPcode = reader["ZIPcode"].ToString();
		        string phoneNumber = reader["Phonenumber"].ToString();
		        string email = reader["Email"].ToString();

		        Name name = new Name(firstName, lastName);
		        customer = new Customer(ID.ToString(), name, address, city, ZIPcode, phoneNumber, email);
	        }
	        catch (Exception e)
	        {
		        error = "ERROR! " + e.Message;
	        }

	        return customer;
		}

        public void Update(Customer customer)
        {
	        SqlCommand command = new SqlCommand("spUpdateCustomer");
			command.CommandType = CommandType.StoredProcedure;

	        command.Parameters.Add(new SqlParameter("@ID", customer.ID));
	        command.Parameters.Add(new SqlParameter("@FirstName", customer.Name.FirstName));
	        command.Parameters.Add(new SqlParameter("@LastName", customer.Name.LastName));
	        command.Parameters.Add(new SqlParameter("@Address", customer.Address));
	        command.Parameters.Add(new SqlParameter("@City", customer.City));
	        command.Parameters.Add(new SqlParameter("@ZIPcode", customer.ZIPcode));
	        command.Parameters.Add(new SqlParameter("@PhoneNumber", customer.PhoneNumber));
	        command.Parameters.Add(new SqlParameter("@Email", customer.Email));

	        DatabaseController.ExecuteNonQuerySP(command);
		}

		public void Delete(Customer customer)
		{
			SqlCommand command = new SqlCommand("spDeleteCustomer");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", customer.ID));
			DatabaseController.ExecuteNonQuerySP(command);

		}
	}
}
