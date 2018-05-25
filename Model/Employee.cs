using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Employee
    {
        public int ID { get; set; }
        public Name Name { get; set; }

	    public Employee()
	    {
		    
	    }

		public Employee(Name name)
		{
			Name = name;
		}

		public Employee(int ID, Name name)
		{
			this.ID = ID;
			Name = name;
		}

		public override bool Equals(object other)
		{
			bool result = false;

			if(other is Employee)
			{
				result = (other as Employee).ID == ID;
			}

			return result;
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode() ^ Name.GetHashCode();
		}
	}
}
