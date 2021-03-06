﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DataAccess
{

	public class WorksheetRepository : IRepository<Worksheet>
	{
		public Worksheet Create(Worksheet worksheet)
		{
			SqlCommand command = new SqlCommand("spInsertWorksheet");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@CustomerID", worksheet.Customer.ID));
			command.Parameters.Add(new SqlParameter("@Workplace", worksheet.Workplace));
			command.Parameters.Add(new SqlParameter("@StartDateTime", worksheet.StartDateTime));
			command.Parameters.Add(new SqlParameter("@EndDateTime", worksheet.EndDateTime));
			command.Parameters.Add(new SqlParameter("@WorkDescription", worksheet.WorkDescription));
			command.Parameters.Add(new SqlParameter("@IsGuarantee", worksheet.IsGuarantee));
			command.Parameters.Add(new SqlParameter("@StatusType", worksheet.Status.ToString()));

			int worksheetID = Convert.ToInt32((DatabaseController.ExecuteScalarSP(command)));
			worksheet.ID = worksheetID;

			UpdateAssignedEmployees(worksheet);

			return worksheet;
		}

		public void Delete(Worksheet worksheet)
		{
			SqlCommand command = new SqlCommand("spDeleteWorksheet");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", worksheet.ID));
			DatabaseController.ExecuteNonQuerySP(command);
		}

		public Worksheet Retrieve(int ID)
		{
			Worksheet worksheet = null;

			SqlCommand command = new SqlCommand("spGetWorksheetByID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@ID", ID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);

			CustomerRepository customerRepository = new CustomerRepository();

			if(table?.Count > 0) // If the list is not null or empty
			{
				worksheet = ConvertRowToWorksheet(table[0]);
			}

			return worksheet;
		}

		public void Update(Worksheet worksheet)
		{
			SqlCommand command = new SqlCommand("spUpdateWorksheet");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@WorksheetID", worksheet.ID));
			command.Parameters.Add(new SqlParameter("@CustomerID", worksheet.Customer.ID));
			command.Parameters.Add(new SqlParameter("@Workplace", worksheet.Workplace));
			command.Parameters.Add(new SqlParameter("@StartDateTime", worksheet.StartDateTime));
			command.Parameters.Add(new SqlParameter("@EndDateTime", worksheet.EndDateTime));
			command.Parameters.Add(new SqlParameter("@WorkDescription", worksheet.WorkDescription));
			command.Parameters.Add(new SqlParameter("@IsGuarantee", worksheet.IsGuarantee));
			command.Parameters.Add(new SqlParameter("@StatusType", worksheet.Status.ToString()));

			UpdateAssignedEmployees(worksheet);

			DatabaseController.ExecuteNonQuerySP(command);
		}


		private void UpdateAssignedEmployees(Worksheet worksheet)
		{
			DeleteAllAssignedEmployeesByWorksheetID(worksheet.ID);

			foreach(Employee employee in worksheet.AssignedEmployees)
			{
				CreateAssignedEmployee(employee.ID, worksheet.ID);
			}
		}

		private void DeleteAllAssignedEmployeesByWorksheetID(int worksheetID)
		{
			SqlCommand command = new SqlCommand("spDeleteAllAssignedEmployeesByWorksheetID");
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@WorksheetID", worksheetID));
			DatabaseController.ExecuteNonQuerySP(command);
		}

		private void CreateAssignedEmployee(int employeeID, int worksheetID)
		{
			SqlCommand command = new SqlCommand("spInsertAssignedEmployee");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@WorksheetID", worksheetID));
			command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));

			DatabaseController.ExecuteNonQuerySP(command);
		}

		public List<Worksheet> RetrieveAssignedWorksheetsByEmployeeID(int employeeID)
		{
			List<Worksheet> worksheets = new List<Worksheet>();

			SqlCommand command = new SqlCommand("spGetAssignedWorksheetsByEmployeeID");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
			List<object[]> table = DatabaseController.ExecuteReaderSP(command);


			if(table?.Count > 0) // If the list is not null or empty
			{
				foreach(object[] row in table)
				{
					worksheets.Add(ConvertRowToWorksheet(row));
				}
			}

			return worksheets;
		}


		private Worksheet ConvertRowToWorksheet(object[] row)
		{
			CustomerRepository customerRepository = new CustomerRepository();

			int worksheetID = Convert.ToInt32(row[0]);
			int customerID = Convert.ToInt32(row[1]);
			string workplace = row[2].ToString();
			string workDescription = row[3].ToString();
			DateTime startDateTime = Convert.ToDateTime(row[4]);
			DateTime endDateTime = Convert.ToDateTime(row[5]);
			bool isGuarantee = Convert.ToBoolean(row[6]);
			Status status;
			Enum.TryParse(row[7].ToString(), out status);

			Customer customer = customerRepository.Retrieve(customerID);

			List<Image> images = new List<Image>(); //TODO: Get imageDocumentation
			List<Employee> assignedEmployees = new List<Employee>(); // TODO: Get Assigned employees
			List<Material> materials = new List<Material>(); // TODO: Get materials
			List<WorkHours> workHours = new List<WorkHours>(); // TODO: Get workhours
			List<AdditionalMaterials> additionalMaterials = new List<AdditionalMaterials>(); // TODO: Get additional materials

			Worksheet worksheet = 
				new Worksheet(
					worksheetID,
					customer,
					workDescription,
					workplace,
					startDateTime,
					endDateTime,
					isGuarantee,
					status,
					images,
					assignedEmployees,
					materials,
					workHours,
					additionalMaterials
				);

			return worksheet;
		}
	}
}
