using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace ViewModel
{
	public class FitterMenuViewModel : ViewModelBase
	{
		public List<Worksheet> WorksheetList { get; set; }

		//public FitterWorksheetViewModel()
		//{

		//}

		public void RetrieveAllEmployeeWorksheets(string employeeID)
		{
			WorksheetRepository repos = new WorksheetRepository();
			List<Worksheet> worksheets = new List<Worksheet>();

			worksheets.AddRange(repos.RetrieveEmployeeWorksheetsByCredentials(employeeID));
			WorksheetList = worksheets;
		}
	}
}
