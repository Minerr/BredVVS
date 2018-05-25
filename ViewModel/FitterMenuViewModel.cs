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

		public Worksheet SelectedWorksheet { get; set; }

		public FitterMenuViewModel()
		{

		}

		public void RetrieveAllEmployeeWorksheets()
		{
			WorksheetRepository repos = new WorksheetRepository();
			List<Worksheet> worksheets = new List<Worksheet>();

			worksheets.AddRange(repos.RetrieveEmployeeWorksheetsByCredentials(ClientInfo.Instance.Employee.ID));
			WorksheetList = worksheets;
		}

		public FitterWorksheetViewModel SelectWorksheet()
		{
			return new FitterWorksheetViewModel(SelectedWorksheet);
		}

		public bool IsWorksheetSelected()
		{
			return (SelectedWorksheet != null);
		}
	}
}
