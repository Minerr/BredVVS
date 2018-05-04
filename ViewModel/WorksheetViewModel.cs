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

		public Worksheet Worksheet { get; set; }

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
			Worksheet = new Worksheet();

			List<Fitter> assignedFitters = new List<Fitter>();
			assignedFitters.Add(new Fitter(new Name("Søren", "Hansen")));
			assignedFitters.Add(new Fitter(new Name("Tim", "Timsen")));

			List<Material> materials = new List<Material>();
			materials.Add(new Material("Panometric Tube", "11.5mm Ø, 10500mm L, Plastic."));
			materials.Add(new Material("Enhanced Flail Socket", "35.2mm Ø, 30mm L, Plastic"));
			materials.Add(new Material("Hydrocoptic Ringdisc", "20mm Ø, Rubber"));

			List<WorkTime> workTime = new List<WorkTime>();
			workTime.Add(new WorkTime(assignedFitters[0], 2.5, "Normal time", new DateTime(2018, 04, 23)));
			workTime.Add(new WorkTime(assignedFitters[0], 1.0, "Normal time", new DateTime(2018, 04, 24)));
			workTime.Add(new WorkTime(assignedFitters[1], 3.0, "Normal time", new DateTime(2018, 04, 28)));

			Worksheet.AssignedFitters = assignedFitters;
			Worksheet.Materials = materials;
			Worksheet.WorkTime = workTime;

			//TODO: move OnPropertyChanged into Model layer
			OnPropertyChanged("AssignedFitters");
			OnPropertyChanged("Materials");
			OnPropertyChanged("WorkTime");
		}

		public void CreateWorksheet()
		{
			//TODO: Save worksheet in database
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
