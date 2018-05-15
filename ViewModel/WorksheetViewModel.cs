﻿using Model;
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
        public static WorksheetViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WorksheetViewModel();
                }
                return _instance;
            }
        }

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

                if (value.Hours != 0)
                {
                    hour = value.Hours;
                    minute = _startTime.Minutes;
                }

                if (value.Minutes != 0)
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

        public string CustomerFullAddress
        {
            get
            {
                string fullAddress = "";

                if (Customer != null)
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
                if (value == true)
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
                if (value == true)
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
                if (value)
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
                if (value)
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
                if (value)
                {
                    Worksheet.Status = Status.Done;
                }
            }
        }

        private WorksheetViewModel()
        {
            // Init start values
            Worksheet = new Worksheet();

            _isServiceVehicleChecked = false;
            _isAuxiliaryMaterialsChecked = false;
            _startTime = new TimeSpan(0, 0, 0);
            _endTime = new TimeSpan(0, 0, 0);


            Hours = new List<TimeSpan>();
            for (int i = 0; i < 24; i++)
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



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
