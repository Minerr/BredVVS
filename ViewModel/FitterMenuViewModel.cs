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
			WorksheetRepository repos = new WorksheetRepository();
			List<Worksheet> worksheets = new List<Worksheet>();

			WorksheetList = repos.RetrieveAssignedWorksheetsByEmployeeID(ClientInfo.Instance.Employee.ID);
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
