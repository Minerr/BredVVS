using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Material
    {
        public int ID { get; private set; }
	    public string Type { get; set; }
	    public string Description { get; set; }

        public Material(int ID, string type, string description)
        {
			this.ID = ID;
            Type = type;
            Description = description;
        }

		public override string ToString()
		{
			return ID + ";" + Type + ";" + Description;
		}

	}
}
