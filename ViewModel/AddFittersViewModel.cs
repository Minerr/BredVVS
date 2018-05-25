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
		public ObservableCollection<Fitter> AvailableFitters { get; set; }
		public ObservableCollection<Fitter> AssignedFitters { get; set; }

		private Fitter _selectedAvailableFitter;
		public Fitter SelectedAvailableFitter
		{
			get { return _selectedAvailableFitter; }
			set
			{
				_selectedAvailableFitter = value;
				CanSelectFitter = value == null ? false : true;
				OnPropertyChanged("CanSelectFitter");
			}
		}

		private Fitter _selectedAssignedFitter;
		public Fitter SelectedAssignedFitter
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

		public AddFittersViewModel(WorksheetViewModel worksheetVM)
		{
			_worksheetVM = worksheetVM;
			AssignedFitters = CloneAssignedFitters(worksheetVM.AssignedFitters);
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

			allFitters.AddRange(repos.GetAllFitters());

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
