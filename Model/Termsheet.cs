using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Termsheet
    {
        public Customer CustomerInfo {get; set;}
        public DateTime TimeAndDate {get; set;}
        public string WorksheetID {get; set;}
        public string BuilderInfo {get; set;}
        public string Entrepreneur {get; set;}
        public string WorkDescription {get; set;}
        public bool IsDraft {get; set;}
        public string PriceType {get; set;}

        public Termsheet(Customer customerInfo, DateTime dateTime, string worksheetID, string builderInfo, string entrepreneur)
        {
            CustomerInfo = customerInfo;
            TimeAndDate = dateTime;
            WorksheetID = worksheetID;
            BuilderInfo = builderInfo;
            Entrepreneur = entrepreneur;
        }


    }
}
