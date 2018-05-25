using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class WorkHours
	{
		public Employee Employee { get; set; }
		public double Hours { get; set; }
		public string Type { get; set; }
		public DateTime Date { get; set; }

		public WorkHours(Employee employee, double hours, string type, DateTime date)
		{
			Employee = employee;
			Hours = hours;
			Type = type;
			Date = date;
		}

		public override string ToString()
		{
			return Employee.ID + ";" +
				Employee.Name.FullName + ";" +
				Hours + ";" +
				Type + ";" +
				Date.ToShortDateString();
		}
	}
}
