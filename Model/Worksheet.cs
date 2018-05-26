using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Worksheet : RepositoryElement
	{
        public int ID { get; set; }
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

		public Worksheet(Customer customer, List<Image> images, List<Fitter> assignedFitters, 
			string workDescription, string workplace, DateTime startDateTime, DateTime endDateTime, 
			List<Material> materials, List<WorkHours> workHours, bool isGuarentee, Status status, 
			List<AdditionalMaterials> additionalMaterials )
        {
			// Init properties
			Customer = customer;
			ImageDocumentation = images;
			AssignedFitters = assignedFitters;
			WorkDescription = workDescription;
			Workplace = workplace;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Materials = materials;
			WorkHours = workHours;
			IsGuarantee = isGuarentee;
			Status = status;
			AdditionalMaterials = additionalMaterials;
		}

	    public Worksheet(int ID, string workplace, Name name)
	    {
			Customer = new Customer();
		    this.ID = ID;
		    Workplace = workplace;
		    Customer.Name = name;
	    }

        public void AddImage(Image image)
        {
			ImageDocumentation.Add(image);
        }

        public void AddFitter(Fitter fitter)
        {
			AssignedFitters.Add(fitter);
        }

        public void AddMaterial(Material material)
        {
			Materials.Add(material);
        }

        public void AddWorkHours(WorkHours workHours)
        {
			WorkHours.Add(workHours);
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
