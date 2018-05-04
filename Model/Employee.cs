using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Employee
    {
        public string ID { get; private set; }
        public Name Name { get; set; }

		public Employee(Name name)
		{
			ID = Guid.NewGuid().ToString();
			Name = name;
		}
    }
}
