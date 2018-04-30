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
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public string Address { get; private set; }
		public string ZIPcode { get; private set; }
		public string City { get; private set; }
		public string PhoneNumber { get; private set; }

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