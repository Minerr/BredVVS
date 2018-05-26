using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace ViewModel
{
	public class CreateNewCustomerViewModel : ViewModelBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string StreetAddress { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public CreateNewCustomerViewModel()
		{
			
		}

		public WorksheetViewModel CreateNewCustomer()
		{
            CustomerRepository customerRepository = new CustomerRepository();

			Address address = new Address(StreetAddress, ZIPcode, City);
			Name name = new Name(FirstName, LastName);
			Customer customer = customerRepository.Create(new Customer(name, address, PhoneNumber, Email));

			return new WorksheetViewModel(customer);
		}

		public bool IsCustomerDataNotNull()
		{
			bool result = true;
			if(string.IsNullOrEmpty(FirstName) ||
				string.IsNullOrEmpty(LastName) ||
				string.IsNullOrEmpty(StreetAddress) ||
				string.IsNullOrEmpty(ZIPcode) ||
				string.IsNullOrEmpty(City) ||
				string.IsNullOrEmpty(PhoneNumber) ||
				string.IsNullOrEmpty(Email))
			{
				result = false;
			}
			return result;
		}
	}
}
