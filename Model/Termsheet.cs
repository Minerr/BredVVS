using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BredVVS
{
	public class Termsheet
    {
        public Customer customerInfo { get { return customerInfo; } set {} }
        public DateTime dateTime { get { return dateTime; } set {} }
        public string worksheetID { get { return worksheetID; } set {} }
        public string builderInfo { get { return builderInfo; } set {} }
        public string entrepreneur { get { return entrepreneur; } set {} }
        public string workDescription { get { return workDescription; } set {} }
        public bool isDraft { get { return isDraft; } set {} }
        public string priceType { get { return priceType; } set {} }

        public Termsheet(Customer customerInfo, DateTime dateTime, string worksheetID, string builderInfo, string entrepreneur)
        {
            this.customerInfo = customerInfo;
            this.dateTime = dateTime;
            this.worksheetID = worksheetID;
            this.builderInfo = builderInfo;
            this.entrepreneur = entrepreneur;
        }


    }
}
