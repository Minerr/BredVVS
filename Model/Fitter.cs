﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fitter : Employee
    {
		public string QualificationType { get; set; }

		public Fitter(Name name) : base(name)
		{
		}

		public Fitter(string ID, Name name) : base(ID, name)
		{
		}
	}
}
