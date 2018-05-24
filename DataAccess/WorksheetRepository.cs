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
    public class WorksheetRepository : IRepository<Worksheet>
    {
        public void Create(Worksheet worksheet)
        {
            SqlCommand command = new SqlCommand("spSaveWorksheet");
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Customer", worksheet.Customer));
            command.Parameters.Add(new SqlParameter("@StartDateTime", worksheet.StartDateTime));
            command.Parameters.Add(new SqlParameter("@EndDateTime", worksheet.EndDateTime));
            command.Parameters.Add(new SqlParameter("@Workplace", worksheet.Workplace));

            DatabaseController.ExecuteNonQuerySP(command);
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
