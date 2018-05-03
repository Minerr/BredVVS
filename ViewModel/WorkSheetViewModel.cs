using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
	public class WorksheetViewModel
	{
		public Customer Customer { get; set; }
		public string CustomerFullName { get; set; }
		public string CustomerFullAdress { get; set; }
		public Worksheet Worksheet { get; set; }

		public WorksheetViewModel(object selectedCustomer)
		{
			Customer = selectedCustomer as Customer;
			CustomerFullName = Customer.FirstName + " " + Customer.LastName;
			CustomerFullAdress = Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City;
		}

	}


}
