using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Material
    {
        public string ID { get {return ID;} set {} }
        public string name { get {return name;} set {} }
        public string description { get {return description;} set {} }

        public Material(string ID, string name, string description)
        {
            this.ID = ID;
            this.name = name;
            this.description = description;
        }
    }
}
