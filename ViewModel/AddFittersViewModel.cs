using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace ViewModel
{
	public class AddFittersViewModel : ViewModelBase
	{
		public ObservableCollection<Employee> AvailableFitters { get; set; }
		public ObservableCollection<Employee> AssignedFitters { get; set; }

		private Employee _selectedAvailableFitter;
		public Employee SelectedAvailableFitter
		{
			get { return _selectedAvailableFitter; }
			set
			{
				_selectedAvailableFitter = value;
				CanSelectFitter = value == null ? false : true;
				OnPropertyChanged("CanSelectFitter");
			}
		}

		private Employee _selectedAssignedFitter;
		public Employee SelectedAssignedFitter
		{
			get { return _selectedAssignedFitter; }
			set
			{
				_selectedAssignedFitter = value;
				CanRemoveFitter = value == null ? false : true;
				OnPropertyChanged("CanRemoveFitter");
			}
		}

		public bool CanSelectFitter { get; set; }
		public bool CanRemoveFitter { get; set; }

		private WorksheetViewModel _worksheetVM;

		public AddFittersViewModel(List<Employee> assignedEmployees)
		{
			AssignedFitters = CloneAssignedFitters(assignedEmployees);
			AvailableFitters = RetrieveAvailableFitters();

			CanSelectFitter = false;
			CanRemoveFitter = false;
		}

		private ObservableCollection<Fitter> CloneAssignedFitters(ObservableCollection<Fitter> assignedFitters)
		{
			ObservableCollection<Fitter> assignedFitterClone = new ObservableCollection<Fitter>();
			foreach(Fitter fitter in assignedFitters)
			{
				assignedFitterClone.Add(fitter);
			}

			return assignedFitterClone;
		}

		private ObservableCollection<Fitter> RetrieveAvailableFitters()
		{
			ObservableCollection<Fitter> availableFitters = new ObservableCollection<Fitter>();
			List<Fitter> allFitters = new List<Fitter>();
			EmployeeRepository repos = new EmployeeRepository();

			allFitters.AddRange(repos.GetEmployeesByType());

			foreach(Fitter fitter in allFitters)
			{
				if(!AssignedFitters.Contains(fitter))
				{
					availableFitters.Add(fitter);
				}
			}

			return availableFitters;
		}

		public void AddSelectedFitter()
		{
			AssignedFitters.Add(SelectedAvailableFitter);
			AvailableFitters.Remove(SelectedAvailableFitter);
			SelectedAvailableFitter = null;
		}

		public void RemoveSelectedFitter()
		{
			AvailableFitters.Add(SelectedAssignedFitter);
			AssignedFitters.Remove(SelectedAssignedFitter);
			SelectedAssignedFitter = null;
		}

		public void SaveAssignedFitters()
		{
			_worksheetVM.AssignedFitters = AssignedFitters;
		}

	}
}
