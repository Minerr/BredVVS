using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class WorkTime
    {
        public string EmployeeID { get; private set; }
		public string Name { get; private set; }
		public double Time { get; private set; }
		public string Type { get; private set; }

		public WorkTime(string ID, string name, double time, string type)
        {
			EmployeeID = ID;
			Name = name;
			Time = time;
			Type = type;
        }
    }
}
