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

        public Customer Create(Customer customer)
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

			int customerID = Convert.ToInt32(DatabaseController.ExecuteScalarSP(command));
			customer.ID = customerID;

			return customer;
		}

        public Customer Retrieve(int ID)
        {
	        Customer customer = null;

			SqlCommand command = new SqlCommand("spGetCustomerByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
	        List<object[]> table = DatabaseController.ExecuteReaderSP(command);

	        if (table != null)
	        {
		        foreach (object[] row in table)
		        {
					string firstName = row[1].ToString();
					string lastName = row[2].ToString();
					string address = row[3].ToString();
			        string ZIPcode = row[4].ToString();
					string city = row[5].ToString();
					string phoneNumber = row[6].ToString();
					string email = row[7].ToString();

			        Name name = new Name(firstName, lastName);
			        customer = new Customer(ID, name, address, ZIPcode, city, phoneNumber, email);
				}
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

	    public List<Customer> RetrieveCustomerByKeyword(string keyword)
	    {
		    //string error = "";
			List<Customer> customers = new List<Customer>();

		    SqlCommand command = new SqlCommand("spGetCustomerByKeyword");
		    command.CommandType = CommandType.StoredProcedure;

		    command.Parameters.Add(new SqlParameter("@Keyword", "%" + keyword + "%"));
		    List<object[]> table = DatabaseController.ExecuteReaderSP(command);

		    if (table != null)
		    {
			    foreach (object[] row in table)
			    {
				    int ID = Convert.ToInt32(row[0]);
				    string firstName = row[1].ToString();
				    string lastName = row[2].ToString();
				    string address = row[3].ToString();
				    string ZIPcode = row[4].ToString();
				    string city = row[5].ToString();
				    string phoneNumber = row[6].ToString();
				    string email = row[7].ToString();

				    Name name = new Name(firstName, lastName);
				    customers.Add(new Customer(ID, name, address, ZIPcode, city, phoneNumber, email));
			    }
		    }
			return customers;
		}
	}
}
