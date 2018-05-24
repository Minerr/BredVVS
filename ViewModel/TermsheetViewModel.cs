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

		public string Workplace { get; set; }

		public Termsheet Termsheet { get; set; }

		private PaymentType termsheetPayment;

		public bool IsFixedPriceChecked
		{
			get
			{
				return (termsheetPayment == PaymentType.FixedPrice);
			}
			set
			{
				if (value)
				{
					termsheetPayment = PaymentType.FixedPrice;
				}
			}
		}

		public bool IsBillChecked
		{
			get
			{
				return (termsheetPayment == PaymentType.Bill);
			}
			set
			{
				if (value)
				{
					termsheetPayment = PaymentType.Bill;
				}
			}
		}

		public bool IsOfferChecked
		{
			get
			{
				return (termsheetPayment == PaymentType.Offer);
			}
			set
			{
				if (value)
				{
					termsheetPayment = PaymentType.Offer;
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

		public void SaveTermsheet()
		{

		}
	}
}
