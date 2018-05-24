using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Termsheet
    {
        public int ID {get; set;}
        public Customer Customer {get; set; }
		public DateTime DateTime {get; set;}
        public int WorksheetID {get; set;}
        public string Entrepreneur {get; set;}
        public string WorkDescription {get; set;}
        public bool IsDraft {get; set;}
		public PaymentType PaymentType { get; set; }

        public Termsheet(Customer customer, DateTime dateTime, int worksheetID, string entrepreneur, string workDescription, bool isDraft, PaymentType paymentType)
        {
            Customer = customer;
            DateTime = dateTime;
            WorksheetID = worksheetID;
            Entrepreneur = entrepreneur;
			WorkDescription = workDescription;
			IsDraft = isDraft;
			PaymentType = paymentType;
        }


    }
}
