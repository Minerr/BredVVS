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
	public class EmployeeRepository : IRepository<Employee>
	{
		public void Create(Employee employee)
		{
			SqlCommand command = new SqlCommand("spInsertEmployee");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
			command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));
			command.Parameters.Add(new SqlParameter("@EmployeeType", employee.GetType().ToString()));

			if (employee.GetType() == typeof(Fitter))
			{
				command.Parameters.Add(new SqlParameter("@QualificationType", ((Fitter)employee).QualificationType));

				// TODO: Refactor qualificationtype
			}
			DatabaseController.ExecuteNonQuerySP(command);
		}

		public Employee Retrieve(int ID)
		{
			//string error = "";
			Employee employee = null;

			SqlCommand command = new SqlCommand("spGetEmployeeByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if (table != null)
			{
				foreach (object[] row in table)
				{
					string firstName = row[1].ToString();
					string lastName = row[2].ToString();
					string employeeType = row[3].ToString();
					string qualificationType = row[4].ToString();

					Name name = new Name(firstName, lastName);
					if (employeeType == "Fitter")
					{
						employee = new Fitter(ID, name, qualificationType);
					}
					else if (employeeType == "OfficeWorker")
					{
						employee = new OfficeWorker(ID, name);
					}
				}
			}
			return employee;
		}

		public void Update(Employee employee)
			{
				SqlCommand command = new SqlCommand("spUpdateEmployee");
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add(new SqlParameter("@ID", employee.ID));
				command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
				command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));

				DatabaseController.ExecuteNonQuerySP(command);
			}

			public void Delete(Employee employee)
			{
				SqlCommand command = new SqlCommand("spDeleteEmployee");
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add(new SqlParameter("@ID", employee.ID));
				DatabaseController.ExecuteNonQuerySP(command);
			}

			public Employee GetEmployeeByCredentials(int ID, string pass)
			{
				return null;
			}
		}
	}
