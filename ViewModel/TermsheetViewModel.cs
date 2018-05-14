﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class TermsheetViewModel
	{
		private static TermsheetViewModel _instance;
		public Customer Customer { get; set; }

		public string CustomerFullAddress
		{
			get
			{
				string fullAddress = "";

				if (Customer != null)
				{
					fullAddress = Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City;
				}

				return fullAddress;
			}
		}

		public static TermsheetViewModel Instance
		{
				get
				{
					if (_instance == null)
					{
						_instance = new TermsheetViewModel();
					}

					return _instance;
				}
		}
	}
}