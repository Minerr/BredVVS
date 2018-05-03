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

		public SearchForCustomerViewModel()
		{
			CustomerList = new List<Customer>();
		}

		public void RetrieveCustomers(string keyword)
		{
			List<Customer> customers = new List<Customer>();
			customers.Add(new Customer("Daniel", "Gierahn", "Skt. Knudsgade 44", "5000", "Odense", "76543278"));
			customers.Add(new Customer("bo", "Hansen", "Skt. Knudsgade 56", "5000", "Odense", "12343458"));
			customers.Add(new Customer("Tim", "Timsen", "Skt. Knudsgade 111", "5000", "Odense", "12345654"));
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
