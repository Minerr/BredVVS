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
		public string Workplace { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public List<Material> Materials { get; set; }
		public List<WorkHours> WorkHours { get; set; }
		public bool IsGuarantee { get; set; }
		public Status Status { get; set; }
		public List<AdditionalMaterials> AdditionalMaterials { get; set; }

		public Worksheet()
        {
			// Init properties
			ID = "19237";

			Customer = new Customer();
			ImageDocumentation = new List<Image>();
			AssignedFitters = new List<Fitter>();
			WorkDescription = "";
			Workplace = "";
			StartDateTime = new DateTime();
			EndDateTime = new DateTime();
			Materials = new List<Material>();
			WorkHours = new List<WorkHours>();
			IsGuarantee = false;
			Status = Status.Waiting;
			AdditionalMaterials = new List<AdditionalMaterials>();
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

        public void AddWorkHours(WorkHours workHours)
        {

        }

		public void AddAdditonalMaterial(AdditionalMaterials additionalMaterial)
		{
			if(!AdditionalMaterials.Contains(additionalMaterial))
			{
				AdditionalMaterials.Add(additionalMaterial);
			}
		}

		public void RemoveAdditonalMaterial(AdditionalMaterials additionalMaterial)
		{
			if(AdditionalMaterials.Contains(additionalMaterial))
			{
				AdditionalMaterials.Remove(additionalMaterial);
			}
		}
	}
}
