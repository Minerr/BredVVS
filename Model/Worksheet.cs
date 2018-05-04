using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Worksheet
    {
        public string ID { get; private set; }
        public Customer Customerinfo { get; set; }
		public List<Image> ImageDocumentation { get; set; }
		public List<Fitter> AssignedFitters { get; set; }
		public string WorkDescription { get; set; }
		public string WorkPlace { get; set; }
		public DateTime EndDateTime { get; set; }
		public DateTime StartDateTime { get; set; }
		public List<Material> Materials { get; set; }
		public List<WorkTime> WorkTime { get; set; }

		public Worksheet(Customer customerInfo, string workDescription, string workPlace, DateTime startDateTime, DateTime endDateTime)
        {
            Customerinfo = customerInfo;
            WorkDescription = workDescription;
            WorkPlace = workPlace;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }

        public void AddImage(Image image)
        {

        }

        public void AddFitter(Fitter fitter)
        {

        }

        public void AddHeadFitter(HeadFitter head)
        {

        }

        public void AddMaterial(Material material)
        {

        }

        public void AddWork(float time, string employeeID, string name, string type)
        {

        }
    }
}
