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
		private Customer _customer;
		private Worksheet _worksheet;

		public ObservableCollection<WorkHours> WorkHours { get; set; }
		public ObservableCollection<Material> Materials { get; set; }
		public int WorksheetID { get; set; }
		public string Workplace { get; set; }
		public string WorkDescription { get; set; }
		public string CustomerInfo
		{
			get
			{
				return _customer.Name.FullName + "\n" +
					_customer.Address + "\n" +
					"Tlf. nr.: " + _customer.PhoneNumber + "\n" +
					"Email: " + _customer.Email;
			}
		}
		public string StartDateTime { get; set; }
		public string EndDateTime { get; set; }

		public FitterWorksheetViewModel(Worksheet worksheet)
		{
			_worksheet = worksheet;

			WorkHours = null;
			Materials = null;

			WorksheetID = worksheet.ID;
			Workplace = worksheet.Workplace;
			WorkDescription = worksheet.WorkDescription;

			_customer = worksheet.Customer;

			DateTime startDateTime = worksheet.StartDateTime;
			DateTime endDateTime = worksheet.EndDateTime;
			StartDateTime =	"Startdato: " + startDateTime.Date.ToString("d") + "\n" + 
							"Starttid: " + startDateTime.ToString("hh:mm");
			EndDateTime = "Slutdato: " + endDateTime.Date.ToString("d") + "\n" +
				"Sluttid: " + endDateTime.ToString("hh:mm");
		}

		public TermsheetViewModel CreateNewTermsheet()
		{
			return new TermsheetViewModel(_worksheet);
		}
	}
}
