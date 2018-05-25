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
	public class TermsheetRepository : IRepository<Termsheet>
	{
		public void Create(Termsheet termsheet)
		{
			SqlCommand command = new SqlCommand("spInsertTermsheet");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@WorksheetID", termsheet.WorksheetID));
			command.Parameters.Add(new SqlParameter("@AcceptDate", termsheet.AcceptDate));
			command.Parameters.Add(new SqlParameter("@StartDate", termsheet.StartDate));
			command.Parameters.Add(new SqlParameter("@EndDate", termsheet.EndDate));
			command.Parameters.Add(new SqlParameter("@Entrepreneur", termsheet.Entrepreneur));
			command.Parameters.Add(new SqlParameter("@WorkDescription", termsheet.WorkDescription));
			command.Parameters.Add(new SqlParameter("@PaymentType", termsheet.PaymentType));

			DatabaseController.ExecuteNonQuerySP(command);
		}

		public void Delete(Termsheet type)
		{
			throw new NotImplementedException();
		}

		public Termsheet Retrieve(int ID)
		{
			throw new NotImplementedException();
		}

		public void Update(Termsheet type)
		{
			throw new NotImplementedException();
		}
	}
}
