﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public abstract class RepositoryElement
	{
		public int ID { get; set; }

		public RepositoryElement()
		{
		}

		public RepositoryElement(int ID)
		{
			this.ID = ID;
		}

	}
}