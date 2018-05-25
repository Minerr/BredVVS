
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class OfficeWorker: Employee
    {
		public OfficeWorker(Name name) : base(name)
		{
		}

		public OfficeWorker(int ID, Name name) : base(ID, name)
		{
		}
	}
}
