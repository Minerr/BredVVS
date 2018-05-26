using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Address
	{
		public string Street { get; set; }
		public string ZIPcode { get; set; }
		public string City { get; set; }

		public Address(string street, string ZIPcode, string city)
		{
			Street = street;
			this.ZIPcode = ZIPcode;
			City = city;
		}

		public override string ToString()
		{
			return Street + ", " + ZIPcode + " " + City;
		}
	}
}
