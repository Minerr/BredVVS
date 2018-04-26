using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Image
    {
		public DateTime TimeAndDate { get; private set; }
        public string GPSLocation { get; private set; }
		public string Description { get; private set; }
		public string EmployeeID { get; private set; }

		public Image(DateTime dateTime, string GPSlocation, string description, string employeeID)
        {
			TimeAndDate = dateTime;
            this.GPSLocation = GPSlocation;
			Description  = description;
			EmployeeID = employeeID;
        }
    }
}
