using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
	 public class Customer : RepositoryElement
	{
		public int ID { get; set; }
		public Name Name { get; set; }
		public string Address { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public Customer()
		{
			Name = new Name();
		}
		public Customer(Name name, string address, string ZIPcode, string city, string phoneNumber, string email)
		{
			Name = name;
			Address = address;
			this.ZIPcode = ZIPcode;
			City = city;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public Customer(int ID, Name name, string address, string ZIPcode, string city, string phoneNumer, string email)
		{
			this.ID = ID;
			Name = name;
			Address = address;
			this.ZIPcode = ZIPcode;
			City = city;
			PhoneNumber = phoneNumer;
			Email = email;
		}

		public override string ToString()
		{
			return Name.FullName + "\n" + Address + "\n" + ZIPcode + " " + City + "\n" + PhoneNumber;
		}
	}
}