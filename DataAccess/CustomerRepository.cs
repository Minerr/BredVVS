﻿using System;
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
	        List<object[]> table = DatabaseController.ExecuteReader(command);

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
			        customer = new Customer(ID.ToString(), name, address, ZIPcode, city, phoneNumber, email);
				}
			}
	        return customer;
		}

	    //string firstName = table["FirstName"].ToString();
	    //string lastName = table["LastName"].ToString();
	    //string address = table["Address"].ToString();
	    //string city = table["City"].ToString();
	    //string ZIPcode = table["ZIPcode"].ToString();
	    //string phoneNumber = table["Phonenumber"].ToString();
	    //string email = table["Email"].ToString();

		public void Update(Customer customer)
        {
	        SqlCommand command = new SqlCommand("spUpdateCustomer");
			command.CommandType = CommandType.StoredProcedure;

	        command.Parameters.Add(new SqlParameter("@ID", customer.CustomerID));
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

			command.Parameters.Add(new SqlParameter("@ID", customer.CustomerID));
			DatabaseController.ExecuteNonQuerySP(command);

		}

	    public Customer RetrieveCustomerByKeyword(string keyword)
	    {
		    string error = "";
		    Customer customer = null;

		    SqlCommand command = new SqlCommand("spGetCustomerByKeyword");
		    command.CommandType = CommandType.StoredProcedure;

		    command.Parameters.Add(new SqlParameter("@Keyword", keyword));
		    List<object[]> table = DatabaseController.ExecuteReader(command);

		    if (table != null)
		    {
			    foreach (object[] row in table)
			    {
				    string ID = row[0].ToString();
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
	}
}
