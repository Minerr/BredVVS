﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Name
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;
			}
		}
		public Name()
		{
			FirstName = "";
			LastName = "";
		}

		public Name(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}
