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

        public List<TimeSpan> Hours { get; }
        public List<TimeSpan> Minutes { get; }

        private TimeSpan _startTime;
        private TimeSpan _endTime;
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
                
                if(value.Minutes !=0)
                {
                    hour = _startTime.Hours;
                    minute = value.Minutes;
                }

                _startTime = new TimeSpan(hour, minute, 0);
                OnPropertyChanged("StartTime");
            }
        }
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

                if (value.Hours != 0)
                {
                    hour = value.Hours;
                    minute = _endTime.Minutes;
                }

                if (value.Minutes != 0)
                {
                    hour = _endTime.Hours;
                    minute = value.Minutes;
                }

                _endTime = new TimeSpan(hour, minute, 0);
                OnPropertyChanged("EndTime");
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
            
            _startTime = new TimeSpan(0,0,0);
            EndTime = new TimeSpan(0,0,0);
           

            Worksheet = new Worksheet();

			List<Fitter> assignedFitters = new List<Fitter>();
			assignedFitters.Add(new Fitter(new Name("Søren", "Hansen")));
			assignedFitters.Add(new Fitter(new Name("Tim", "Timsen")));

			List<Material> materials = new List<Material>();
			materials.Add(new Material("Panometric Tube", "11.5mm Ø, 10500mm L, Plastic."));
			materials.Add(new Material("Enhanced Flail Socket", "35.2mm Ø, 30mm L, Plastic"));
			materials.Add(new Material("Hydrocoptic Ringdisc", "20mm Ø, Rubber"));

			List<WorkHours> workHours = new List<WorkHours>();
			workHours.Add(new WorkHours(assignedFitters[0], 2.5, "Normal time", new DateTime(2018, 04, 23)));
			workHours.Add(new WorkHours(assignedFitters[0], 1.0, "Normal time", new DateTime(2018, 04, 24)));
			workHours.Add(new WorkHours(assignedFitters[1], 3.0, "Normal time", new DateTime(2018, 04, 28)));

			Worksheet.AssignedFitters = assignedFitters;
			Worksheet.Materials = materials;
			Worksheet.WorkHours = workHours;

			//TODO: move OnPropertyChanged into Model layer
			OnPropertyChanged("AssignedFitters");
			OnPropertyChanged("Materials");
			OnPropertyChanged("WorkTime");

            List<TimeSpan> hours = new List<TimeSpan>();
            for(int i=0; i < 24; i++)
            {
                hours.Add(new TimeSpan(i, 0, 0));
            }

            List<TimeSpan> minutes = new List<TimeSpan>();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add(new TimeSpan(0, i, 0));
            }

            Hours = hours;
            Minutes = minutes;

            OnPropertyChanged("Hours");
            OnPropertyChanged("Minutes");

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
