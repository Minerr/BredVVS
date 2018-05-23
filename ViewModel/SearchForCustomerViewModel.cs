using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;
using DataAccess;

namespace ViewModel
{
	public class SearchForCustomerViewModel : ViewModelBase
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
			CustomerRepository repos = new CustomerRepository();
			
			List<Customer> customers = new List<Customer>();
			customers.AddRange(repos.RetrieveCustomerByKeyword(keyword));
			CustomerList = customers;

			//customers.Add(new Customer(new Name("Daniel", "Gierahn"), "Skt. Knudsgade 44", "5000", "Odense", "76543278", "FedtMandSpa@AOL.com"));
			//customers.Add(new Customer(new Name("bo", "Hansen"), "Skt. Knudsgade 56", "5000", "Odense", "12343458", "BoHansen@mail.dk"));
			//customers.Add(new Customer(new Name("Tim", "Timsen"), "Skt. Knudsgade 111", "5000", "Odense", "12345654", "Timmy@gmail.com"));
		}

		public WorksheetViewModel SelectCustomer()
		{
			WorksheetViewModel worksheetVM = new WorksheetViewModel();
			worksheetVM.Customer = SelectedCustomer;
			return worksheetVM;
		}
	}
}
