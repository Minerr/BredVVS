using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Worksheet : RepositoryElement
	{
		public Customer Customer { get; set; }
		public List<Image> ImageDocumentation { get; }
		public List<Employee> AssignedEmployees { get; }
		public string WorkDescription { get; set; }
		public string Workplace { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public List<Material> Materials { get; }
		public List<WorkHours> WorkHours { get; }
		public bool IsGuarantee { get; set; }
		public Status Status { get; set; }
		public List<AdditionalMaterials> AdditionalMaterials { get; }

		public Worksheet(Customer customer,
			string workDescription, string workplace, DateTime startDateTime, DateTime endDateTime, bool isGuarantee, Status status) : base()
		{
			// Init properties
			Customer = customer;
			ImageDocumentation = new List<Image>();
			AssignedEmployees = new List<Employee>();
			WorkDescription = workDescription;
			Workplace = workplace;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Materials = new List<Material>();
			WorkHours = new List<WorkHours>();
			IsGuarantee = isGuarantee;
			Status = status;
			AdditionalMaterials = new List<AdditionalMaterials>();
		}

		public Worksheet(
				int ID,
				Customer customer,
				string workDescription,
				string workplace,
				DateTime startDateTime,
				DateTime endDateTime,
				bool isGuarantee,
				Status status
			) : base(ID)
		{
			// Init properties
			Customer = customer;
			ImageDocumentation = new List<Image>();
			AssignedEmployees = new List<Employee>();
			WorkDescription = workDescription;
			Workplace = workplace;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Materials = new List<Material>();
			WorkHours = new List<WorkHours>();
			IsGuarantee = isGuarantee;
			Status = status;
			AdditionalMaterials = new List<AdditionalMaterials>();
		}

		public void AddImage(Image image)
		{
			ImageDocumentation.Add(image);
		}

		public void AddEmployee(Employee employee)
		{
			AssignedEmployees.Add(employee);
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
