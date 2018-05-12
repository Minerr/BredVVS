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
	public class WorksheetVM : ViewModelBase
	{
		public Customer Customer { get; set; }

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
                
                if(value.Minutes !=0)
                {
                    hour = _startTime.Hours;
                    minute = value.Minutes;
                }

                _startTime = new TimeSpan(hour, minute, 0);
                OnPropertyChanged("StartTime");
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

		public WorkHours SelectedWorkHours { get; set; }

		private bool _isServiceVehicleChecked;
		public bool IsServiceVehicleChecked
		{
			get { return _isServiceVehicleChecked; }
			set
			{
				if(value == true)
				{
					Worksheet.AddAdditonalMaterial(AdditionalMaterials.ServiceVehicle);
				}
				else
				{
					Worksheet.RemoveAdditonalMaterial(AdditionalMaterials.ServiceVehicle);
				}
				_isServiceVehicleChecked = value;
			}
		}

		private bool _isAuxiliaryMaterialsChecked;
		public bool IsAuxiliaryMaterialsChecked
		{
			get { return _isServiceVehicleChecked; }
			set
			{
				if(value == true)
				{
					Worksheet.AddAdditonalMaterial(AdditionalMaterials.AuxiliaryMaterials);
				}
				else
				{
					Worksheet.RemoveAdditonalMaterial(AdditionalMaterials.AuxiliaryMaterials);
				}

				_isAuxiliaryMaterialsChecked = value;
			}
		}

		public bool IsWaitingChecked
		{
			get
			{
				return (Worksheet.Status == Status.Waiting);
			}
			set
			{
				if(value)
				{
					Worksheet.Status = Status.Waiting;
				}
			}
		}

		public bool IsOngoingChecked
		{
			get
			{
				return (Worksheet.Status == Status.Ongoing);
			}
			set
			{
				if(value)
				{
					Worksheet.Status = Status.Ongoing;
				}
			}
		}

		public bool IsDoneChecked
		{
			get
			{
				return (Worksheet.Status == Status.Done);
			}
			set
			{
				if(value)
				{
					Worksheet.Status = Status.Done;
				}
			}
		}

		public WorksheetVM()
		{
			// Init start values
			Worksheet = new Worksheet();

			_isServiceVehicleChecked = false;
			_isAuxiliaryMaterialsChecked = false;
			_startTime = new TimeSpan(0,0,0);
            _endTime = new TimeSpan(0,0,0);

			Hours = new List<TimeSpan>();
            for(int i=0; i < 24; i++)
            {
				Hours.Add(new TimeSpan(i, 0, 0));
            }

			Minutes = new List<TimeSpan>();
            for (int i = 0; i < 60; i += 15)
            {
				Minutes.Add(new TimeSpan(0, i, 0));
            }
        }

        public void CreateWorksheet()
		{
			//TODO: Save worksheet in database
		}
	}
}
