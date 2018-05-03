using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
	 public class Customer
	{
		public string ID { get; private set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }

		public Customer(string firstName, string lastName, string address, string ZIPcode, string city, string phoneNumer)
		{
            ID = Guid.NewGuid().ToString();
			FirstName = firstName;
			LastName = lastName;
			Address = address;
			this.ZIPcode = ZIPcode;
			City = city;
			PhoneNumber = phoneNumer;
		}
	}
}