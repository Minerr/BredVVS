using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Termsheet : RepositoryElement
	{
        public Customer Customer {get; set; }
		public DateTime AcceptDate {get; set;}
		public DateTime StartDate {get; set;}
		public DateTime EndDate { get; set;}
        public int WorksheetID {get; set; }
		public string Entrepreneur {get; set;}
        public string WorkDescription {get; set;}
		public PaymentType PaymentType { get; set; }
		public bool IsDraft { get; set; }
		public double TotalPrice { get; set; }

		public Termsheet(Customer customer, DateTime acceptDate, DateTime startDate, DateTime endDate, int worksheetID, string entrepreneur, string workDescription, PaymentType paymentType, bool isDraft, double totalPrice) : base()
		{
            Customer = customer;
			AcceptDate = acceptDate;
			StartDate = startDate;
			EndDate = endDate;
            WorksheetID = worksheetID;
            Entrepreneur = entrepreneur;
			WorkDescription = workDescription;
			PaymentType = paymentType;
			IsDraft = isDraft;
			TotalPrice = totalPrice;
		}

		public Termsheet(int ID, Customer customer, DateTime acceptDate, DateTime startDate, DateTime endDate, int worksheetID, string entrepreneur, string workDescription, PaymentType paymentType, bool isDraft, double totalPrice) : base(ID)
		{
			Customer = customer;
			AcceptDate = acceptDate;
			StartDate = startDate;
			EndDate = endDate;
			WorksheetID = worksheetID;
			Entrepreneur = entrepreneur;
			WorkDescription = workDescription;
			PaymentType = paymentType;
			IsDraft = isDraft;
			TotalPrice = totalPrice;
		}

	}
}
