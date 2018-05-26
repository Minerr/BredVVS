using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Material : RepositoryElement
    {
	    public string Type { get; set; }
	    public string Description { get; set; }

        public Material(int ID, string type, string description) : base(ID)
        {
            Type = type;
            Description = description;
        }

		public override string ToString()
		{
			return ID + ";" + Type + ";" + Description;
		}

	}
}
