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
		public Employee Create(Employee employee)
		{
			SqlCommand command = new SqlCommand();
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
			command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));

			if(employee.GetType() == typeof(Fitter))
			{
				command.CommandText = "spInsertFitter";
				command.Parameters.Add(new SqlParameter("@EmployeeType", "Fitter"));
				command.Parameters.Add(new SqlParameter("@QualificationType", ((Fitter) employee).QualificationType));
			}
			else if(employee.GetType() == typeof(OfficeWorker))
			{
				command.CommandText = "spInsertOfficeWorker";
				command.Parameters.Add(new SqlParameter("@EmployeeType", "OfficeWorker"));
			}

			int employeeID = Convert.ToInt32(DatabaseController.ExecuteScalarSP(command));
			employee.ID = employeeID;

			return employee;
		}

		public Employee Retrieve(int ID)
		{
			//string error = "";
			Employee employee = null;

			SqlCommand command = new SqlCommand("spGetEmployeeByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if(table != null)
			{
				foreach(object[] row in table)
				{
					string employeeType = row[1].ToString();
					string firstName = row[2].ToString();
					string lastName = row[3].ToString();
					string qualificationType = row[4].ToString();

					Name name = new Name(firstName, lastName);

					if(employeeType == "Fitter")
					{
						string qualificationType = row[4].ToString();
						employee = new Fitter(ID, name, qualificationType);
					}
					else if(employeeType == "OfficeWorker")
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

		public List<Fitter> GetAllFitters()
		{
			List<Fitter> fitters = new List<Fitter>();

			SqlCommand command = new SqlCommand("spGetAllFitters");
			command.CommandType = CommandType.StoredProcedure;

			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if (table != null)
			{
				foreach (object[] row in table)
				{
					int ID = Convert.ToInt32(row[0]);
					string firstName = row[1].ToString();
					string lastName = row[2].ToString();
					string employeeType = row[3].ToString();


					Name name = new Name(firstName, lastName);
					fitters.Add(new Fitter(ID, name, employeeType));
				}
			}
			return fitters;
		}
	}
}
