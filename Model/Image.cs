using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Image
    {
		public DateTime TimeAndDate { get; set; }
        public string GPSLocation { get; set; }
		public string Description { get; set; }
		public string EmployeeID { get; set; }
		public string Type { get; set; }

		public Image(DateTime dateTime, string GPSlocation, string description, string employeeID, string type)
        {
			TimeAndDate = dateTime;
            this.GPSLocation = GPSlocation;
			Description  = description;
			EmployeeID = employeeID;
			Type = type;
        }
    }
}
