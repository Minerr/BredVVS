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
	class TermsheetRepository : IRepository<Termsheet>
	{
		public void Create(Termsheet type)
		{
			SqlCommand command = new SqlCommand("spInsertTermsheet");
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@FirstName", termsheet.Name.FirstName));
			command.Parameters.Add(new SqlParameter("@LastName", termsheet.Name.LastName));
			command.Parameters.Add(new SqlParameter("@Address", termsheet.Address));
			command.Parameters.Add(new SqlParameter("@City", termsheet.City));
			command.Parameters.Add(new SqlParameter("@ZIPcode", termsheet.ZIPcode));
			command.Parameters.Add(new SqlParameter("@PhoneNumber", termsheet.PhoneNumber));
			command.Parameters.Add(new SqlParameter("@Email", termsheet.Email));

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
