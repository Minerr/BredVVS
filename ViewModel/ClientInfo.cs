using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	internal class ClientInfo
	{
		private static ClientInfo _instance;

		public static ClientInfo Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ClientInfo();
				}
				return _instance;
			}
		}

		public Employee Employee { get; set; }

		private ClientInfo()
		{
		}
	}
}
