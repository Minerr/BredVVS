using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BredVVS
{
	public class Image
    {
        public DateTime time;
        public DateTime date;
        public string GPSLocation = "";
        public string decription = "";
        public string employeeID = "";

        public Image(DateTime datetime, string location, string decription, string employeeID)
        {
            date = datetime.Date;
            time = datetime;

            GPSLocation = location;
            this.decription  = decription;
            this.employeeID = employeeID;
        }
    }
}
