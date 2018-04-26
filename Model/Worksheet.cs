using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BredVVS
{
    class Worksheet
    {
        public string ID { get { return ID; } set { } }
        public Customer customerinfo { get { return customerinfo; } set { } }
        public List<Image> imageDocumentation { get { return imageDocumentation; } set { } }
        public List<Fitter> assignedFitters { get { return assignedFitters; } set { } }
        public List<HeadFitter> assignedHeadFitter { get { return assignedHeadFitter; } set { } }
        public string workDescription { get { return workDescription; } set { } }
        public string workPlace { get { return workPlace; } set { } }
        public DateTime endDateTime { get { return endDateTime; } set { } }
        public DateTime startDateTime { get { return startDateTime; } set { } }
        public List<Material> materials { get { return materials; } set { } }
        public List<WorkTime> workTime{ get { return workTime; } set { } }

        public Worksheet(Customer customerinfo, string workDescription, string workPlace, DateTime startDateTime, DateTime endDateTime)
        {
            this.customerinfo = customerinfo;
            this.workDescription = workDescription;
            this.workPlace = workPlace;
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
        }

        public void AddImage(Image image)
        {

        }

        public void AddFitter(Fitter fitter)
        {

        }

        public void AddHeadFitter(HeadFitter head)
        {

        }

        public void AddMaterial(Material material)
        {

        }

        public void AddWork(float time, string employeeID, string name, string type)
        {

        }
    }
}
