using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Image
    {
		public int ID { get; set; }
		public DateTime DateTime { get; set; }
        public string GPSLocation { get; set; }
		public string Description { get; set; }
		public int EmployeeID { get; set; }
		public string WorksheetID { get; set; }
		public string Type { get; set; }

		public Image(int ID, DateTime dateTime, string GPSlocation, string description, int employeeID, string type)
        {
			this.ID = ID;
			DateTime = dateTime;
            this.GPSLocation = GPSlocation;
			Description  = description;
			EmployeeID = employeeID;
			Type = type;
        }
    }
}
