using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ViewModel
{
	public class WorksheetViewModel : INotifyPropertyChanged
	{
		private static WorksheetViewModel _instance;
		public Customer Customer { get; set; }

		public string CustomerFullAdress
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

		public Worksheet Worksheet { get; set; }

		public string WorkDescription { get; set; }
		public string WorkPlace { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }
		public List<Fitter> AssignedFitters { get; set; }
		public List<Material> Materials { get; set; }
		public List<WorkTime> WorkTime { get; set; }


		public static WorksheetViewModel Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new WorksheetViewModel();
				}
				return _instance;
			}
		}

		private WorksheetViewModel()
		{
			List<Fitter> assignedFitters = new List<Fitter>();
			assignedFitters.Add(new Fitter(new Name("Søren", "Hansen")));
			assignedFitters.Add(new Fitter(new Name("Tim", "Timsen")));

			List<Material> materials = new List<Material>();
			materials.Add(new Material("1240550", "Panometric Tube", "11.5mm Ø, 10500mm L, Plastic."));
			materials.Add(new Material("4420301", "Enhanced Flail Socket", "35.2mm Ø, 30mm L, Plastic"));
			materials.Add(new Material("8942377", "Hydrocoptic Ringdisc", "20mm Ø, Rubber"));

			List<WorkTime> workTime = new List<WorkTime>();
			workTime.Add(new WorkTime(assignedFitters[0], 2.5, "Normal time"));
			workTime.Add(new WorkTime(assignedFitters[0], 1.0, "Normal time"));
			workTime.Add(new WorkTime(assignedFitters[1], 3.0, "Normal time"));

			AssignedFitters = assignedFitters;
			Materials = materials;
			WorkTime = workTime;
			OnPropertyChanged("AssignedFitters");
			OnPropertyChanged("Materials");
			OnPropertyChanged("WorkTime");
		}

		public void CreateWorksheet()
		{

		}



		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if(handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
