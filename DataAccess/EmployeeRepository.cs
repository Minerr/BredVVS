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
    class EmployeeRepository : IRepository<Employee>
    {
        public void Create(Employee employee)
        {
	        SqlCommand command = new SqlCommand("InsertEmployee");

	        command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
	        command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));
	        command.Parameters.Add(new SqlParameter("@EmployeeType", employee.GetType().ToString()));

	        if (employee.GetType() == typeof(Fitter))
	        {
		        command.Parameters.Add(new SqlParameter("@QualificationType", ((Fitter) employee).QualificationType));

				// TODO: Refactor qualificationtype
	        }
	        DatabaseController.ExecuteNonQuerySP(command);
		}

        public void Delete(Employee type)
        {
	        SqlCommand command = new SqlCommand("DeleteEmployee");

	        command.Parameters.Add(new SqlParameter("@ID", type.ID));
	        DatabaseController.ExecuteNonQuerySP(command);
		}

        public Employee Retrieve(int ID)
        {
	        string error = "";
	        Employee employee = null;

	        SqlCommand command = new SqlCommand("DeleteEmployee");
	        command.Parameters.Add(new SqlParameter("@ID", ID));
	        SqlDataReader reader = DatabaseController.ExecuteReader(command);

	        try
	        {
		        string firstName = reader["FirstName"].ToString();
		        string lastName = reader["LastName"].ToString();
				string employeeType = reader["EmployeeType"].ToString();
		        string qualificationType = reader["Qualification"].ToString();

		        Name name = new Name(firstName, lastName);
				if (employeeType == "Fitter")
		        {
					employee = new Fitter(ID.ToString(), name, qualificationType);
		        }
				else if (employeeType == "OfficeWorker")
				{
					employee = new OfficeWorker(ID.ToString(), name);
				}
	        }
	        catch (Exception e)
	        {
		        error = "ERROR! " + e.Message;
	        }

	        return employee;
		}

        public void Update(Employee type)
        {
	        SqlCommand command = new SqlCommand("UpdateEmployee");

	        command.Parameters.Add(new SqlParameter("@ID", type.ID));
	        command.Parameters.Add(new SqlParameter("@FirstName", type.Name.FirstName));
	        command.Parameters.Add(new SqlParameter("@LastName", type.Name.LastName));

	        DatabaseController.ExecuteNonQuerySP(command);
		}

        public Employee GetEmployeeByCredentials(int ID, string pass)
        {
            return null;
        }
    }
}