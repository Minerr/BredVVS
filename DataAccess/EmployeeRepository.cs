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
	public class EmployeeRepository : IEmployeeRepository
	{
		public Employee Create(Employee employee)
		{
			SqlCommand command = new SqlCommand("spInsertEmployee");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@FirstName", employee.Name.FirstName));
			command.Parameters.Add(new SqlParameter("@LastName", employee.Name.LastName));
			command.Parameters.Add(new SqlParameter("@EmployeeType", employee.Type.ToString()));

			int employeeID = Convert.ToInt32(DatabaseController.ExecuteScalarSP(command));
			employee.ID = employeeID;

			UpdateQualificationsForEmployee(employee);

			return employee;
		}

		private void UpdateQualificationsForEmployee(Employee employee)
		{
			SqlCommand command = new SqlCommand("spDeleteAllEmployeeQualificationsByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@EmployeeID", employee.ID));
			DatabaseController.ExecuteNonQuerySP(command);

			foreach(QualificationType qualificationType in employee.Qualifications)
			{
				CreateEmployeeQualification(employee.ID, qualificationType);
			}
		}

		private void CreateEmployeeQualification(int employeeID, QualificationType qualificationType)
		{
			SqlCommand command = new SqlCommand("spInsertEmployeeQualification");
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
			command.Parameters.Add(new SqlParameter("@QualificationType", qualificationType.ToString()));
			DatabaseController.ExecuteNonQuerySP(command);
		}

		public Employee Retrieve(int ID)
		{
			Employee employee = null;

			SqlCommand command = new SqlCommand("spGetEmployeeByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if(table?.Count > 0) // If the list is not null or empty
			{
				object[] row = table[0];
				EmployeeType employeeType;

				Enum.TryParse(row[1].ToString(), out employeeType);
				string firstName = row[2].ToString();
				string lastName = row[3].ToString();

				List<QualificationType> qualifications = RetrieveEmployeeQualificationsByID(ID);
				Name name = new Name(firstName, lastName);
				employee = new Employee(ID, name, employeeType, qualifications);
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

			UpdateQualificationsForEmployee(employee);

			DatabaseController.ExecuteNonQuerySP(command);
		}

		public void Delete(Employee employee)
		{
			SqlCommand command = new SqlCommand("spDeleteEmployee");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", employee.ID));
			DatabaseController.ExecuteNonQuerySP(command);
		}

		private List<QualificationType> RetrieveEmployeeQualificationsByID(int ID)
		{
			List<QualificationType> qualifications = new List<QualificationType>();

			SqlCommand command = new SqlCommand("spGetEmployeeQualificationsByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if(table?.Count > 0) // If the list is not null or empty
			{
				foreach(object[] row in table)
				{
					QualificationType qualificationType;

					Enum.TryParse(row[1].ToString(), out qualificationType);
					qualifications.Add(qualificationType);
				}
			}

			return qualifications;
		}

		public List<Employee> RetrieveAllEmployeesByType(EmployeeType employeeType)
		{
			List<Employee> employees = new List<Employee>();

			SqlCommand command = new SqlCommand("spGetAllEmployeesByType");
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@EmployeeType", employeeType.ToString()));

			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			if(table?.Count > 0) // If the list is not null or empty
			{
				foreach(object[] row in table)
				{
					int ID = Convert.ToInt32(row[0]);
					string firstName = row[1].ToString();
					string lastName = row[2].ToString();

					Name name = new Name(firstName, lastName);

					List<QualificationType> qualifications = RetrieveEmployeeQualificationsByID(ID);
					Employee employee = new Employee(ID, name, employeeType, qualifications);

					employees.Add(employee);
				}
			}
			return employees;
		}
	}
}
