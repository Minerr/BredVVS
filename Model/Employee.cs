using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee : RepositoryElement
    {
        public Name Name { get; set; }
        public EmployeeType Type { get; set; }
		public List<QualificationType> Qualifications { get; }

		public Employee(Name name, EmployeeType employeeType, List<QualificationType> qualifications) : base()
		{
			Name = name;
			Type = employeeType;
			Qualifications = qualifications ?? new List<QualificationType>();
		}

		public Employee(int ID, Name name, EmployeeType type, List<QualificationType> qualifications) : base(ID)
		{
			Name = name;
			Type = type;
			Qualifications = qualifications ?? new List<QualificationType>();
		}

		public override string ToString()
		{
			return ID + ";" + Name.FullName + ";" + Type;
		}
	}
}
