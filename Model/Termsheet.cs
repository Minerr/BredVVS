using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Termsheet
    {
        public Customer CustomerInfo {get; private set;}
        public DateTime TimeAndDate {get; private set;}
        public string WorksheetID {get; private set;}
        public string BuilderInfo {get; private set;}
        public string Entrepreneur {get; private set;}
        public string WorkDescription {get; private set;}
        public bool IsDraft {get; private set;}
        public string PriceType {get; private set;}

        public Termsheet(Customer customerInfo, DateTime dateTime, string worksheetID, string builderInfo, string entrepreneur)
        {
            CustomerInfo = customerInfo;
            DateTime = dateTime;
            WorksheetID = worksheetID;
            BuilderInfo = builderInfo;
            Entrepreneur = entrepreneur;
        }


    }
}
