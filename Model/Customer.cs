using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
	public class Customer : RepositoryElement
	{
		public Name Name { get; set; }
		public Address Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }

		public Customer(Name name, Address address, string phoneNumber, string email) : base()
		{
			Name = name;
			Address = address;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public Customer(int ID, Name name, Address address, string phoneNumer, string email) : base(ID)
		{
			Name = name;
			Address = address;
			PhoneNumber = phoneNumer;
			Email = email;
		}

		public override string ToString()
		{
			return Name.FullName + "\n" + Address + "\n" + PhoneNumber;
		}
	}
}