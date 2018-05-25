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

			//TODO: Remove fake data before final release
			//customers.Add(new Customer(new Name("Tim", "Timsen"), "Skt. Knudsgade 111", "5000", "Odense", "12345654", "Timmy@gmail.com"));

			customers.AddRange(repos.RetrieveCustomerByKeyword(keyword));
			CustomerList = customers;
		}

		public WorksheetViewModel SelectCustomer()
		{
			WorksheetViewModel worksheetVM = new WorksheetViewModel();
			worksheetVM.Customer = SelectedCustomer;
			return worksheetVM;
		}
	}
}
