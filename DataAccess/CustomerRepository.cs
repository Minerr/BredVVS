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

        public void Create(Customer employee)
        {
            SqlCommand command = new SqlCommand("InsertCustomer");

            command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
            command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));
            command.Parameters.Add(new SqlParameter("@Address", employee.Address));
            command.Parameters.Add(new SqlParameter("@City", employee.City));
            command.Parameters.Add(new SqlParameter("@ZIPcode", employee.ZIPcode));
            command.Parameters.Add(new SqlParameter("@PhoneNumber", employee.PhoneNumber));
            command.Parameters.Add(new SqlParameter("@Email", employee.Email));

            DatabaseController.ExecuteNonQuerySP(command);
        }

        public void Delete(Customer type)
        {
            SqlCommand command = new SqlCommand("DeleteCustomer");

            command.Parameters.Add(new SqlParameter("@ID", type.ID));
            DatabaseController.ExecuteNonQuerySP(command);

        }

        public Customer Retrieve(int ID)
        {
	        string error = "";
	        Customer customer = null;

			SqlCommand command = new SqlCommand("RetrieveCustomerByID");			
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

        public void Update(Customer type)
        {
	        SqlCommand command = new SqlCommand("UpdateCustomer");

	        command.Parameters.Add(new SqlParameter("@ID", type.ID));
	        command.Parameters.Add(new SqlParameter("@FirstName", type.Name.FirstName));
	        command.Parameters.Add(new SqlParameter("@LastName", type.Name.LastName));
	        command.Parameters.Add(new SqlParameter("@Address", type.Address));
	        command.Parameters.Add(new SqlParameter("@City", type.City));
	        command.Parameters.Add(new SqlParameter("@ZIPcode", type.ZIPcode));
	        command.Parameters.Add(new SqlParameter("@PhoneNumber", type.PhoneNumber));
	        command.Parameters.Add(new SqlParameter("@Email", type.Email));

	        DatabaseController.ExecuteNonQuerySP(command);
		}
    }
}
