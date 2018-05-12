using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class CreateNewCustomerVM : ViewModelBase
	{
		public string PhoneNumber { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }

		public CreateNewCustomerVM()
		{
		}

		public void CreateNewCustomer(WorksheetVM worksheetVM)
		{
			worksheetVM.Customer = new Customer(new Name(FirstName, LastName), Address, ZIPcode, City, PhoneNumber, Email);
		}

		public bool IsCustomerDataNotNull()
		{
			bool result = true;
			if(string.IsNullOrEmpty(FirstName) ||
				string.IsNullOrEmpty(LastName) ||
				string.IsNullOrEmpty(Address) ||
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
