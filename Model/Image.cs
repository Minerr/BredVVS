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
		public string Decription { get; private set; }
		public string EmployeeID { get; private set; }

		public Image(DateTime dateTime, string location, string decription, string employeeID)
        {
			TimeAndDate = dateTime;
            GPSLocation = location;
			Decription  = decription;
			EmployeeID = employeeID;
        }
    }
}
