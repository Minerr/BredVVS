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

		public bool EnableButtons
		{
			get { return (SelectedCustomer != null); }
		}

		private string _keyword;
		public string Keyword
		{
			get { return _keyword; }
			set
			{
				_keyword = value;
				OnPropertyChanged("Keyword");
			}
		}

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

		private Customer _selectedCustomer;
		public Customer SelectedCustomer
		{
			get { return _selectedCustomer; }
			set
			{
				_selectedCustomer = value;
				OnPropertyChanged("SelectedCustomer");
				OnPropertyChanged("EnableButtons");
			}
		}

		public SearchForCustomerViewModel()
		{
			CustomerList = new List<Customer>();
			Keyword = "Søg på kunde";
		}

		public void RetrieveCustomers()
		{
			CustomerRepository repos = new CustomerRepository();
			CustomerList = repos.RetrieveCustomerByKeyword(Keyword);
		}

		public WorksheetViewModel SelectCustomer()
		{
			WorksheetViewModel worksheetVM = new WorksheetViewModel(SelectedCustomer);
			return worksheetVM;
		}
	}
}
