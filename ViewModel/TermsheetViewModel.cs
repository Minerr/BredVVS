using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace ViewModel
{
	public class TermsheetViewModel : ViewModelBase
	{
		private double _totalPrice;
		private double _VAT;
		private double _priceWithoutVAT;


		private DateTime _acceptDate;
		public DateTime AcceptDate
		{
			get { return _acceptDate; }
			set
			{
				_acceptDate = value;
				OnPropertyChanged("AcceptDate");
			}
		}

		private DateTime _startDate;
		public DateTime StartDate
		{
			get { return _startDate; }
			set
			{
				_startDate = value;
				OnPropertyChanged("StartDate");
			}
		}

		private DateTime _endDate;
		public DateTime EndDate
		{
			get { return _endDate; }
			set
			{
				_endDate = value;
				OnPropertyChanged("EndDate");
			}
		}
		public Customer Customer { get; set; }
		public int WorksheetID { get; set; }
		public string Entrepreneur { get; set; }

		public double TotalPrice
		{
			get
			{
				CalculateVATAndPrice(_totalPrice);
				return _totalPrice;
			}
			set
			{
				_totalPrice = value;
				OnPropertyChanged("TotalPrice");
			}
		}
		public double VAT
		{
			get
			{
				return _VAT;
			}
			set
			{
				_VAT = value;
				OnPropertyChanged("VAT");
			}
		}
		public double PriceWithoutVAT
		{
			get
			{
				CalculateVATAndTotal(_priceWithoutVAT);
				return _priceWithoutVAT;
			}
			set
			{
				_priceWithoutVAT = value;
				OnPropertyChanged("PriceExVAT");
			}
		}

		public string Signature { get; set; }

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

		private PaymentType _termsheetPayment;

		public bool IsEstimateChecked
		{
			get
			{
				return (_termsheetPayment == PaymentType.FixedPrice);
			}
			set
			{
				if (value)
				{
					_termsheetPayment = PaymentType.FixedPrice;
				}

				OnPropertyChanged("IsFixedPriceChecked");
				OnPropertyChanged("IsBillChecked");
				OnPropertyChanged("IsOfferChecked");
			}
		}

		public bool IsBillChecked
		{
			get
			{
				return (_termsheetPayment == PaymentType.Bill);
			}
			set
			{
				if (value)
				{
					_termsheetPayment = PaymentType.Bill;
				}

				OnPropertyChanged("IsFixedPriceChecked");
				OnPropertyChanged("IsBillChecked");
				OnPropertyChanged("IsOfferChecked");
			}
		}

		public bool IsOfferChecked
		{
			get
			{
				return (_termsheetPayment == PaymentType.Offer);
			}
			set
			{
				if (value)
				{
					_termsheetPayment = PaymentType.Offer;
				}

				OnPropertyChanged("IsFixedPriceChecked");
				OnPropertyChanged("IsBillChecked");
				OnPropertyChanged("IsOfferChecked");
			}
		}


		public string SelectedTask { get; set; }

		private Worksheet _worksheet;

		public TermsheetViewModel(Worksheet worksheet)
		{
			_worksheet = worksheet;

			SelectedTasksList = new ObservableCollection<string>();
			_termsheetPayment = PaymentType.FixedPrice;
			Entrepreneur = "";
			AcceptDate = DateTime.Now;
			StartDate = DateTime.Now;
			EndDate = DateTime.Now;
			WorksheetID = worksheet.ID;
			Customer = worksheet.Customer;
			Workplace = worksheet.Workplace;
		}

		public void RemoveTask()
		{
			SelectedTasksList.Remove(SelectedTask);
			SelectedTask = null;
		}

		public void SaveTermsheet()
		{
			bool isDraft = string.IsNullOrEmpty(Signature); // If the termsheet is not signed, then the termsheet is a draft.

			string workDescription = "";
			foreach (string task in SelectedTasksList)
			{
				workDescription = workDescription + task + "\n" ;			
			}
			Termsheet termsheet = new Termsheet(Customer, AcceptDate, StartDate, EndDate, 
				WorksheetID, Entrepreneur, workDescription, _termsheetPayment, isDraft);

			TermsheetRepository termsheetRepository = new TermsheetRepository();
			termsheet = termsheetRepository.Create(termsheet);
		}

		public FitterWorksheetViewModel GoBack()
		{
			return new FitterWorksheetViewModel(_worksheet);
		}
	
		private void CalculateVATAndTotal(double Price)
		{
			CalculateVAT(Price);
			TotalPrice = Price + VAT;
		}

		private void CalculateVATAndPrice(double TotalPrice)
		{
			PriceWithoutVAT = TotalPrice / 1.25;
			CalculateVAT(PriceWithoutVAT);
		}

		private void CalculateVAT(double amount)
		{
			VAT = amount * 0.25;
		}
	}
}
