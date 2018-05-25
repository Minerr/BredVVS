﻿using System;
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
		public Customer Customer { get; set; }


		public CreateNewCustomerViewModel()
		{
			Customer = new Customer();
		}

		public WorksheetViewModel CreateNewCustomer()
		{
            CustomerRepository customerRepository = new CustomerRepository();
			Customer = customerRepository.Create(Customer);

			return new WorksheetViewModel(Customer);
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
