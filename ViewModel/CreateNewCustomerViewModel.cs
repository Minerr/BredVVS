using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class CreateNewCustomerViewModel
	{
		#region Singleton code here
		private static CreateNewCustomerViewModel _instance;
		public static CreateNewCustomerViewModel Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new CreateNewCustomerViewModel();
				}
				return _instance;
			}
		}
		#endregion

		public Customer Customer { get; set; }


		private CreateNewCustomerViewModel()
		{
		}

		public void CreateNewCustomer()
		{
			WorksheetViewModel.Instance.Customer = Customer;
		}

		public bool IsCustomerDataNotNull()
		{
			bool result = true;
			if(string.IsNullOrEmpty(Customer.Name.FirstName) ||
				string.IsNullOrEmpty(Customer.Name.LastName) ||
				string.IsNullOrEmpty(Customer.Address) ||
				string.IsNullOrEmpty(Customer.ZIPcode) ||
				string.IsNullOrEmpty(Customer.City) ||
				string.IsNullOrEmpty(Customer.PhoneNumber) ||
				string.IsNullOrEmpty(Customer.Email))
			{
				result = false;
			}
			return result;
		}
	}
}
