using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class TermsheetViewModel : ViewModelBase
	{
		public Customer Customer { get; set; }

		private ObservableCollection<string> _tasks;
		public ObservableCollection<string> SelectedTasksList
		{
			get
			{
				return _tasks;
			}
			set
			{
				_tasks = value;
				OnPropertyChanged("SelectedTasksList");
			}
		}

		public string CustomerInfo
		{
			get
			{
				string customerInfo = "";

				if (Customer != null)
				{
					customerInfo = Customer.Name.FullName + "\n" + Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City + "\n" + Customer.PhoneNumber;
				}

				return customerInfo;
			}
		}

		public Termsheet Termsheet { get; set; }

		private Payment termsheetPayment;

		public bool IsFixedPriceChecked
		{
			get
			{
				return (termsheetPayment == Payment.FixedPrice);
			}
			set
			{
				if (value)
				{
					termsheetPayment = Payment.FixedPrice;
				}
			}
		}

		public bool IsBillChecked
		{
			get
			{
				return (termsheetPayment == Payment.Bill);
			}
			set
			{
				if (value)
				{
					termsheetPayment = Payment.Bill;
				}
			}
		}

		public bool IsOfferChecked
		{
			get
			{
				return (termsheetPayment == Payment.Offer);
			}
			set
			{
				if (value)
				{
					termsheetPayment = Payment.Offer;
				}
			}
		}


		public string SelectedTask { get; set; }

		public TermsheetViewModel()
		{
			SelectedTasksList = new ObservableCollection<string>();
		}

		public void RemoveTask()
		{
			SelectedTasksList.Remove(SelectedTask);
			SelectedTask = null;
		}
	}
}
