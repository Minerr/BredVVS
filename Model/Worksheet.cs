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
        public Customer Customerinfo { get; private set; }
		public List<Image> ImageDocumentation { get; private set; }
		public List<Fitter> AssignedFitters { get; private set; }
		public List<HeadFitter> AssignedHeadFitter { get; private set; }
		public string WorkDescription { get; private set; }
		public string WorkPlace { get; private set; }
		public DateTime EndDateTime { get; private set; }
		public DateTime StartDateTime { get; private set; }
		public List<Material> Materials { get; private set; }
		public List<WorkTime> WorkTime { get; private set; }

		public Worksheet(Customer customerinfo, string workDescription, string workPlace, DateTime startDateTime, DateTime endDateTime)
        {
            Customerinfo = customerinfo;
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
