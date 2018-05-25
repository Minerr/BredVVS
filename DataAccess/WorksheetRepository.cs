using System;
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

			int worksheetID = Convert.ToInt32((DatabaseController.ExecuteScalarSP(command)));

            foreach (Fitter fitter in worksheet.AssignedFitters)
            {
                SqlCommand command2 = new SqlCommand("spInsertAssignedEmployee");
                command2.CommandType = CommandType.StoredProcedure;

                command2.Parameters.Add(new SqlParameter("@WorksheetID", worksheetID));
                command2.Parameters.Add(new SqlParameter("@Fitter", fitter.ID));

				DatabaseController.ExecuteNonQuerySP(command2);
			}

			worksheet.ID = worksheetID;

			return worksheet;
		}

        public void Delete(Worksheet type)
        {
            throw new NotImplementedException();
        }

        public Worksheet Retrieve(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Worksheet type)
        {
            throw new NotImplementedException();
        }

	    public List<Worksheet> RetrieveEmployeeWorksheetsByCredentials(int employeeID)
	    {
		    List<Worksheet> worksheets = new List<Worksheet>();

		    SqlCommand command = new SqlCommand("spGetFitterWorksheetsByCredentials");
		    command.CommandType = CommandType.StoredProcedure;

		    command.Parameters.Add(new SqlParameter("@EmployeeID", employeeID));
		    List<object[]> table = DatabaseController.ExecuteReaderSP(command);

		    if (table != null)
		    {
			    foreach (object[] row in table)
			    {
				    string ID = row[0].ToString();
				    string workplace = row[1].ToString();
				    string firstName = row[2].ToString();
				    string lastName = row[3].ToString();

					Name name = new Name(firstName, lastName);
					worksheets.Add(new Worksheet(int.Parse(ID), workplace, name));
			    }
		    }
		    return worksheets;
	    }
	}
}
