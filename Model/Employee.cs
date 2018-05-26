using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Employee : RepositoryElement
    {
        public Name Name { get; set; }
        public EmployeeType Type { get; set; }
		public List<QualificationType> Qualifications { get; }

		public Employee(Name name, EmployeeType employeeType) : base()
		{
			Name = name;
			Type = employeeType;
			Qualifications = new List<QualificationType>();
		}

		public Employee(int ID, Name name, EmployeeType type) : base(ID)
		{
			Name = name;
			Type = type;
			Qualifications = new List<QualificationType>();
		}

		public void AddQualificationType(QualificationType qualificationType)
		{
			Qualifications.Add(qualificationType);
		}

		public override bool Equals(object other)
		{
			bool result = false;

			if(other is Employee)
			{
				result = (other as Employee).ID == ID;
			}

			return result;
		}

		public override int GetHashCode()
		{
			return ID.GetHashCode() ^ Name.GetHashCode();
		}

		public override string ToString()
		{
			return ID + ";" + Name.FullName + ";" + Type;
		}
	}
}
