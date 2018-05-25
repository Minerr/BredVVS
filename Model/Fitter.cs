using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fitter : Employee
    {
		public string QualificationType { get; set; }

		public Fitter(Name name) : base(name)
		{
		}

		public Fitter(int ID, Name name, string qualificationType) : base(ID, name)
		{
			QualificationType = qualificationType;
		}

		public override string ToString()
		{
			return ID + ";" +
				Name.FullName + ";" +
				QualificationType;
		}
	}
}
