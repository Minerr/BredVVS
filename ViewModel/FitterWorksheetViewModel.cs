using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class FitterWorksheetViewModel : ViewModelBase
	{

		public Worksheet Worksheet { get; set; }
		public string CustomerInfo { get; set; }
		public string StartDateTime { get; set; }
		public string EndDateTime { get; set; }
		
		public FitterWorksheetViewModel(WorksheetViewModel worksheetVM)
		{
			Worksheet = worksheetVM.Worksheet;

			StartDateTime = Worksheet.StartDateTime.ToString();
			EndDateTime = Worksheet.EndDateTime.ToString();

			CustomerInfo =	Worksheet.Customer.Name.FullName + "\n" +
							Worksheet.Customer.Address + "\n" +
							Worksheet.Customer.ZIPcode + " " + Worksheet.Customer.City + "\n" +
							Worksheet.Customer.PhoneNumber;
		}

		public TermsheetViewModel CreateNewTermsheet()
		{
			TermsheetViewModel termsheetVM = new TermsheetViewModel();
			termsheetVM.Customer = Worksheet.Customer;

			return termsheetVM;
		}
	}
}
