﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace ViewModel
{
	class Program
	{
		static void Main(string[] args)
		{
			CustomerRepository repos = new CustomerRepository();
			repos.Create(new Customer(new Name("Karl", "Johansen"), "Ryttergade 17", "5000", "Odense C", "27272727", "KJohansen@mail.dk"));
			Console.ReadKey();
			//repos.Retrieve(10000);
		}
	}
}
