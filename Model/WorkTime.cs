using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class WorkTime
    {
        public string EmployeeID {get; private set;}
        public string Name {get; private set;}
        public float Time {get; private set;}
        public string Type {get; private set;}

        public WorkTime(string id, string name, string description, string type)
        {

        }
    }
}
