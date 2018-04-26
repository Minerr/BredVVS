using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Image
    {
        public DateTime time;
        public DateTime date;
        public string GPSLocation = "";
        public string decription = "";
        public string employeeID = "";

        public Image(DateTime dateTime, string location, string decription, string employeeID)
        {
            date = dateTime;
            time = dateTime;

            GPSLocation = location;
            this.decription  = decription;
            this.employeeID = employeeID;
        }
    }
}
