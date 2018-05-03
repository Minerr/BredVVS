using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class WorkTime
    {
        public Employee Employee { get; set; }
		public double Time { get; set; }
		public string Type { get; set; }

		public WorkTime(Employee employee, double time, string type)
        {
			Employee = employee;
			Time = time;
			Type = type;
        }
    }
}
