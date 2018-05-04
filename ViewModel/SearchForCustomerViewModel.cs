using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace ViewModel
{
	public class SearchForCustomerViewModel : INotifyPropertyChanged
	{

		#region Singleton code here
		private static SearchForCustomerViewModel _instance;
		public static SearchForCustomerViewModel Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new SearchForCustomerViewModel();
				}
				return _instance;
			}
		}
		#endregion

		private List<Customer> _customers;
		public List<Customer> CustomerList
		{
			get
			{
				return _customers;
			}
			private set
			{
				_customers = value;
				OnPropertyChanged("CustomerList");
			}
		}

		public Customer SelectedCustomer { get; set; }

		private SearchForCustomerViewModel()
		{
			CustomerList = new List<Customer>();
		}

		public void RetrieveCustomers(string keyword)
		{
			List<Customer> customers = new List<Customer>();
			customers.Add(new Customer(new Name("Daniel", "Gierahn"), "Skt. Knudsgade 44", "5000", "Odense", "76543278", "FedtMandSpa@AOL.com"));
			customers.Add(new Customer(new Name("bo", "Hansen"), "Skt. Knudsgade 56", "5000", "Odense", "12343458", "BoHansen@mail.dk"));
			customers.Add(new Customer(new Name("Tim", "Timsen"), "Skt. Knudsgade 111", "5000", "Odense", "12345654", "Timmy@gmail.com"));
			CustomerList = customers;
		}

		public void SelectCustomer()
		{
			WorksheetViewModel.Instance.Customer = SelectedCustomer;
		}







		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
