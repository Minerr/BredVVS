using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Material
    {
        public string ID { get; private set; }
	    public string Type { get; set; }
	    public string Description { get; set; }

        public Material(string type, string description)
        {
			ID = Guid.NewGuid().ToString();
            Type = type;
            Description = description;
        }
    }
}
