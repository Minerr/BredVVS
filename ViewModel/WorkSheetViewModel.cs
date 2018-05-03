using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
	public class WorksheetViewModel
	{
		private static WorksheetViewModel _instance;
		public Customer Customer { get; set; }
		public string CustomerFullName
		{
			get
			{
				string fullName = "";
				fullName = Customer.FirstName + " " + Customer.LastName;
				return fullName;
			}
			set { }
		}

		public string CustomerFullAdress
		{
			get
			{
				string fullAddress = "";
				fullAddress = Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City;
				return fullAddress;
			}
			set { }
		}

		public Worksheet Worksheet { get; set; }

		public static WorksheetViewModel Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new WorksheetViewModel();
				}
				return _instance;
			}
		}

		private WorksheetViewModel()
		{

		}

		public void CreateWorksheet()
		{

		}
	}
}
