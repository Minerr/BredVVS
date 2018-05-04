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
	    public string Name { get; set; }
	    public string Description { get; set; }

        public Material(string name, string description)
        {
			ID = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
        }
    }
}
