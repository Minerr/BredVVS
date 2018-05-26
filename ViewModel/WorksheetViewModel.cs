using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;
using DataAccess;
using ViewModel.PDFbuilder;

namespace ViewModel
{
	public class WorksheetViewModel : ViewModelBase
	{

		#region Class variables and propeties...
		private int _worksheetID;
		public int WorksheetID
		{
			get { return _worksheetID; }
			set
			{
				_worksheetID = value;
				OnPropertyChanged("WorksheetID");
			}
		}

		private Customer _customer;
		public Customer Customer
		{
			get { return _customer; }
			set
			{
				_customer = value;
				OnPropertyChanged("Customer");
				OnPropertyChanged("CustomerFullAddress");
			}
		}

		public string CustomerFullAddress
		{
			get
			{
				string fullAddress = "";

				if(Customer != null)
				{
					fullAddress = Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City;
				}

				return fullAddress;
			}
		}

		public List<TimeSpan> Hours { get; }
		public List<TimeSpan> Minutes { get; }

		private TimeSpan _startTime;
		public TimeSpan StartTime
		{
			get
			{
				return _startTime;
			}
			set
			{
				int hour = 0;
				int minute = 0;

				if(value.Hours != 0)
				{
					hour = value.Hours;
					minute = _startTime.Minutes;
				}

				if(value.Minutes != 0)
				{
					hour = _startTime.Hours;
					minute = value.Minutes;
				}

				_startTime = new TimeSpan(hour, minute, 0);
				OnPropertyChanged("StartTime");
				OnPropertyChanged("StartDateTime");
			}
		}

		private TimeSpan _endTime;
		public TimeSpan EndTime
		{
			get
			{
				return _endTime;
			}
			set
			{
				int hour = 0;
				int minute = 0;

				if(value.Hours != 0)
				{
					hour = value.Hours;
					minute = _endTime.Minutes;
				}

				if(value.Minutes != 0)
				{
					hour = _endTime.Hours;
					minute = value.Minutes;
				}

				_endTime = new TimeSpan(hour, minute, 0);
				OnPropertyChanged("EndTime");
				OnPropertyChanged("EndDateTime");

			}
		}

		private DateTime _startDate;
		private DateTime _endDate;
		public DateTime StartDate
		{
			get
			{
				return _startDate;
			}
			set
			{
				_startDate = value;
				OnPropertyChanged("StartDate");
				OnPropertyChanged("StartDateTime");
			}
		}

		public DateTime EndDate
		{
			get
			{
				return _endDate;
			}
			set
			{
				_endDate = value;
				OnPropertyChanged("EndDate");
				OnPropertyChanged("EndDateTime");
			}
		}

		public DateTime StartDateTime
		{
			get
			{
				return _startDate + _startTime;
			}
		}

		public DateTime EndDateTime
		{
			get
			{
				return _endDate + _endTime;
			}
		}

		public string Workplace { get; set; }
		public string WorkDescription { get; set; }


		private Status _status;
		public bool IsWaitingChecked
		{
			get { return (_status == Status.Waiting); }
			set
			{
				if(value)
				{
					_status = Status.Waiting;
				}
			}
		}

		public bool IsOngoingChecked
		{
			get { return (_status == Status.Ongoing); }
			set
			{
				if(value)
				{
					_status = Status.Ongoing;
				}
			}
		}

		public bool IsDoneChecked
		{
			get { return (_status == Status.Done); }
			set
			{
				if(value)
				{
					_status = Status.Done;
				}
			}
		}
		private ObservableCollection<Fitter> _assignedFitters;
		public ObservableCollection<Fitter> AssignedFitters
		{
			get { return _assignedFitters; }
			set
			{
				_assignedFitters = value;
				OnPropertyChanged("AssignedFitters");
			}
		}

		public ObservableCollection<Image> Images { get; set; }
		public ObservableCollection<Material> Materials { get; set; }
		public ObservableCollection<WorkHours> WorkHours { get; set; }

		public bool IsGuarentee { get; set; }
		public bool IsServiceVehicleChecked { get; set; }
		public bool IsAuxiliaryMaterialsChecked { get; set; }
		#endregion

		public WorksheetViewModel(Customer customer)
		{
			// Init start values
			Customer = customer;
			AssignedFitters = new ObservableCollection<Fitter>();
			Images = new ObservableCollection<Image>();
			Materials = new ObservableCollection<Material>();
			WorkHours = new ObservableCollection<WorkHours>();
			WorkDescription = "";
			Workplace = customer.Address + ", " + customer.ZIPcode + " " + customer.City;
			_status = Status.Waiting;

			IsServiceVehicleChecked = false;
			IsAuxiliaryMaterialsChecked = false;

			Hours = new List<TimeSpan>();
			for(int i = 6; i <= 21; i++)
			{
				Hours.Add(new TimeSpan(i, 0, 0));
			}

			Minutes = new List<TimeSpan>();
			for(int i = 0; i < 60; i += 15)
			{
				Minutes.Add(new TimeSpan(0, i, 0));
			}

			StartTime = new TimeSpan(6, 0, 0);
			EndTime = new TimeSpan(6, 0, 0);

			StartDate = DateTime.Today;
			EndDate = DateTime.Today;
		}

		private Worksheet GetWorksheet()
		{
			List<AdditionalMaterials> additionalMaterials = new List<AdditionalMaterials>();
			if(IsAuxiliaryMaterialsChecked)
			{
				additionalMaterials.Add(AdditionalMaterials.AuxiliaryMaterials);
			}
			if(IsServiceVehicleChecked)
			{
				additionalMaterials.Add(AdditionalMaterials.ServiceVehicle);
			}

			return new Worksheet(
					Customer, 
					new List<Image>(Images), 
					new List<Fitter>(AssignedFitters),
					WorkDescription, 
					Workplace, 
					StartDateTime, 
					EndDateTime,
					new List<Material>(Materials), 
					new List<WorkHours>(WorkHours),
					IsGuarentee, 
					_status, 
					additionalMaterials
				);
		}

		public string SaveWorksheet()
		{
			// Save worksheet in Database
			WorksheetRepository worksheetRepository = new WorksheetRepository();

			Worksheet worksheet = worksheetRepository.Create( GetWorksheet() );
			WorksheetID = worksheet.ID;

			//After saving to the database, create a PDF and return its path to view.
			BuildPDF buildPDF = new BuildPDF();
			buildPDF.InsertNewLine(24f, BuildPDF.TextAlignment.Center, "Arbejdsseddel nr.: " + WorksheetID);
			buildPDF.InsertNewLine(16f, "  ");
			buildPDF.InsertNewLine(16f, "Kundeinformationer: ");
			buildPDF.InsertNewSplitLine(14f, Customer.Name.FullName, "Startdato: " + StartDate.ToShortDateString());
			buildPDF.InsertNewSplitLine(14f, Customer.Address, "Starttid: " + StartTime);
			buildPDF.InsertNewSplitLine(14f, Customer.ZIPcode + " " + Customer.City, "Slutdato: " + EndDate.ToShortDateString());
			buildPDF.InsertNewSplitLine(14f, "Tel. nr.: " + Customer.PhoneNumber, "Sluttid: " + EndTime);
			buildPDF.InsertNewSplitLine(14f, "Email: " + Customer.Email, "");
			buildPDF.InsertNewSplitLine(14f, "Kundenr.: " + Customer.ID, "Arbejdssted: " + Workplace);
			buildPDF.InsertNewLine(24f, "");
			buildPDF.InsertNewLine(16f, "Ønskes udført: ");
			buildPDF.InsertNewTextBlock(14f, BuildPDF.TextAlignment.Left, WorkDescription);
			buildPDF.InsertNewLine(24f, "");
			buildPDF.InsertNewLine(16f, "Tilknyttede montører: ");
			buildPDF.InsertNewTable(14f, 2,
					new List<string> { "MedarbejderID", "Navn", "Kvalifikation" },
					AssignedFitters.AsEnumerable()
				);
			buildPDF.InsertNewLine(24f, "");
			buildPDF.InsertNewLine(16f, "Udførte arbejdstimer: ");
			buildPDF.InsertNewTable(14f, 2,
					 new List<string> { "MedarbejderID", "Navn", "Antal timer", "Type", "Dato" },
					 WorkHours.AsEnumerable()
				 );
			buildPDF.InsertNewLine(24f, "");
			buildPDF.InsertNewLine(16f, "Brugte materialer: ");
			buildPDF.InsertNewTable(14f, 2,
					 new List<string> { "Varenummer", "Type", "Beskrivelse" },
					 Materials.AsEnumerable()
				 );

			return buildPDF.Save("Arbejdsseddel_" + WorksheetID + ".pdf");
		}

		public TermsheetViewModel CreateNewTermsheet()
		{
			TermsheetViewModel termsheetVM = new TermsheetViewModel(GetWorksheet());
			return termsheetVM;
		}

		public void AddImages(string[] fileNames)
		{
			//TODO: Add image to database.
		}
	}
}
