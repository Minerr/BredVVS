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
        public Customer Customer { get; set; }
		public List<Image> ImageDocumentation { get; set; }
		public List<Fitter> AssignedFitters { get; set; }
		public string WorkDescription { get; set; }
		public string WorkPlace { get; set; }
		public DateTime EndDateTime { get; set; }
		public DateTime StartDateTime { get; set; }
		public List<Material> Materials { get; set; }
		public List<WorkTime> WorkTime { get; set; }
		public List<Status> Status { get; set; }
		public List<AdditionalMaterials> AdditionalMaterials { get; set; }

		public Worksheet()
        {
			//TODO: Give worksheet an unique ID
        }

        public void AddImage(Image image)
        {

        }

        public void AddFitter(Fitter fitter)
        {

        }

        public void AddMaterial(Material material)
        {
			
        }

        public void AddWorkTime(WorkTime workTime)
        {

        }

		public void AddStatus(Status status)
		{

		}

		public void AddAdditonalMaterial(AdditionalMaterials additionalMaterial)
		{

		}
	}
}
