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
		public Name Name { get; set; }
		public string Address { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public Customer()
		{
			ID = GenerateID();
			Name = new Name();
		}

		public Customer(Name name, string address, string ZIPcode, string city, string phoneNumer, string email)
		{
			ID = GenerateID();
			Name = name;
			Address = address;
			this.ZIPcode = ZIPcode;
			City = city;
			PhoneNumber = phoneNumer;
			Email = email;
		}

		private string GenerateID()
		{
			return Guid.NewGuid().ToString();
		}
	}
}