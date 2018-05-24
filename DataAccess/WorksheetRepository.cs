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
        public void Create(Worksheet worksheet)
        {
            int worksheetID;

            SqlCommand command = new SqlCommand("spCreateWorksheet");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Customer", worksheet.Customer));
            command.Parameters.Add(new SqlParameter("@StartDateTime", worksheet.StartDateTime));
            command.Parameters.Add(new SqlParameter("@EndDateTime", worksheet.EndDateTime));
            command.Parameters.Add(new SqlParameter("@Workplace", worksheet.Workplace));

            worksheetID = Convert.ToInt32(DatabaseController.ExecuteScalarSP(command));

            foreach (Fitter fitter in worksheet.AssignedFitters)
            {
                SqlCommand command2 = new SqlCommand("spAssignedEmployee");
                command2.CommandType = CommandType.StoredProcedure;

                command2.Parameters.Add(new SqlParameter("@WorkSheetID", Convert.ToInt32(worksheetID)));
                command2.Parameters.Add(new SqlParameter("@Fitter", fitter.ID));

                DatabaseController.ExecuteNonQuerySP(command2);
            }
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
    }
}
