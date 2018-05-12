using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;

namespace ViewModel
{
	public class SearchForCustomerVM : ViewModelBase
	{
		private List<Customer> _customers;
		public List<Customer> CustomerList
		{
			get { return _customers; }
			set { _customers = value; OnPropertyChanged(); }
		}
		public Customer SelectedCustomer { get; set; }

		public SearchForCustomerVM()
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
	}
}
