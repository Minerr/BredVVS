using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class TermsheetViewModel : INotifyPropertyChanged
	{
		private static TermsheetViewModel _instance;
		public Customer Customer { get; set; }

		private ObservableCollection<string> _tasks;
		public ObservableCollection<string> SelectedTasksList
		{
			get
			{
				return _tasks;
			}
			set
			{
				_tasks = value;
				OnPropertyChanged("SelectedTasksList");
			}
		}

		public string CustomerInfo
		{
			get
			{
				string customerInfo = "";

				if (Customer != null)
				{
					customerInfo = Customer.Name.FullName + "\n" + Customer.Address + "\n" + Customer.ZIPcode + " " + Customer.City + "\n" + Customer.PhoneNumber;
				}

				return customerInfo;
			}
		}

		public string SelectedTask { get; set; }

		private TermsheetViewModel()
		{
			SelectedTasksList = new ObservableCollection<string>();
		}

		public static TermsheetViewModel Instance
		{
				get
				{
					if (_instance == null)
					{
						_instance = new TermsheetViewModel();
					}

					return _instance;
				}
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

		public void AddTask(string selectedTask)
		{
			SelectedTasksList.Add(selectedTask);
			OnPropertyChanged("SelectedTasksList");
		}

		public void RemoveTask(object selectedTask)
		{
			SelectedTasksList.Remove(SelectedTask);

		}
	}
}
