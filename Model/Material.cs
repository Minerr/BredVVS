﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Material
    {
        public string ID { get; private set; }
	    public string Name { get; private set; }
	    public string Description { get; private set; }

        public Material(string ID, string name, string description)
        {
            this.ID = ID;
            Name = name;
            Description = description;
        }
    }
}
