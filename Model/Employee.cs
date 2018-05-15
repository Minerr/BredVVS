﻿using System;
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

		public Employee(string ID, Name name)
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
