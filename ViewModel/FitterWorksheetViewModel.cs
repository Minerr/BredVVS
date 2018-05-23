using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class FitterWorksheetViewModel : ViewModelBase
	{
		public ObservableCollection<WorkHours> WorkHours { get; set; }
		public ObservableCollection<Material> Materials { get; set; }
		public string WorksheetID { get; set; }
		public string Workplace { get; set; }
		public Customer Customer { get; set; }
		public string StartDateTime { get; set; }
		public string EndDateTime { get; set; }
		
		public FitterWorksheetViewModel(WorksheetViewModel worksheetVM)
		{
			WorkHours = null;
			Materials = null;

			WorksheetID = worksheetVM.Worksheet.ID;
			Workplace = worksheetVM.Workplace;

			Customer = worksheetVM.Customer;

			StartDateTime = worksheetVM.StartDateTime.ToString();
			EndDateTime = worksheetVM.EndDateTime.ToString();

		}

		public TermsheetViewModel CreateNewTermsheet()
		{
			TermsheetViewModel termsheetVM = new TermsheetViewModel();
			termsheetVM.Customer = Customer;
			termsheetVM.Workplace = Workplace;

			return termsheetVM;
		}
	}
}
