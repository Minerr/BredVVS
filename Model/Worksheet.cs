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

		public Worksheet(
				Customer customer,
				string workDescription,
				string workplace,
				DateTime startDateTime,
				DateTime endDateTime,
				bool isGuarantee,
				Status status,
				List<Image> images,
				List<Employee> assignedEmployees,
				List<Material> materials,
				List<WorkHours> workHours,
				List<AdditionalMaterials> additionalMaterials
			) : base()
		{
			// Init properties
			Customer = customer;
			ImageDocumentation = images;
			AssignedEmployees = assignedEmployees;
			WorkDescription = workDescription;
			Workplace = workplace;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Materials = materials;
			WorkHours = workHours;
			IsGuarantee = isGuarantee;
			Status = status;
			AdditionalMaterials = additionalMaterials;
		}

		public Worksheet(
				int ID,
				Customer customer,
				string workDescription,
				string workplace,
				DateTime startDateTime,
				DateTime endDateTime,
				bool isGuarantee,
				Status status,
				List<Image> images,
				List<Employee> assignedEmployees,
				List<Material> materials,
				List<WorkHours> workHours,
				List<AdditionalMaterials> additionalMaterials
			) : base(ID)
		{
			// Init properties
			Customer = customer;
			ImageDocumentation = images;
			AssignedEmployees = assignedEmployees;
			WorkDescription = workDescription;
			Workplace = workplace;
			StartDateTime = startDateTime;
			EndDateTime = endDateTime;
			Materials = materials;
			WorkHours = workHours;
			IsGuarantee = isGuarantee;
			Status = status;
			AdditionalMaterials = additionalMaterials;
		}
	}
}
