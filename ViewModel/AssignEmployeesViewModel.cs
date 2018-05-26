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
	public class AssignEmployeesViewModel : ViewModelBase
	{
		public ObservableCollection<Employee> AvailableEmployees { get; }
		public ObservableCollection<Employee> AssignedEmployees { get; }

		private Employee _selectedAvailableEmployee;
		public Employee SelectedAvailableEmployee
		{
			get { return _selectedAvailableEmployee; }
			set
			{
				_selectedAvailableEmployee = value;
				CanSelectEmployee = value == null ? false : true;
			}
		}

		private Employee _selectedAssignedEmployee;
		public Employee SelectedAssignedEmployee
		{
			get { return _selectedAssignedEmployee; }
			set
			{
				_selectedAssignedEmployee = value;
				CanRemoveEmployee = value == null ? false : true;
			}
		}

		private bool _canSelectEmployee;
		public bool CanSelectEmployee
		{
			get { return _canSelectEmployee; }
			set
			{
				_canSelectEmployee = value;
				OnPropertyChanged("CanSelectEmployee");
			}
		}

		private bool _canRemoveEmployee;
		public bool CanRemoveEmployee
		{
			get { return _canRemoveEmployee; }
			set
			{
				_canRemoveEmployee = value;
				OnPropertyChanged("CanRemoveEmployee");
			}
		}

		private EmployeeRepository _employeeRepository;
		private WorksheetViewModel _worksheetVM;

		public AssignEmployeesViewModel(WorksheetViewModel worksheetVM)
		{
			_employeeRepository = new EmployeeRepository();

			_worksheetVM = worksheetVM;
			AssignedEmployees = new ObservableCollection<Employee>(_worksheetVM.AssignedEmployees);
			AvailableEmployees = RetrieveAvailableEmployees();

			CanSelectEmployee = false;
			CanRemoveEmployee = false;
		}

		private ObservableCollection<Employee> RetrieveAvailableEmployees()
		{
			ObservableCollection<Employee> availableEmployees = new ObservableCollection<Employee>();
			List<Employee> allEmployees = _employeeRepository.RetrieveAllEmployeesByType(EmployeeType.Fitter);

			foreach(Employee employee in allEmployees)
			{
				if(!AssignedEmployees.Contains(employee))
				{
					availableEmployees.Add(employee);
				}
			}

			return availableEmployees;
		}

		public void AddSelectedEmployee()
		{
			AssignedEmployees.Add(SelectedAvailableEmployee);
			AvailableEmployees.Remove(SelectedAvailableEmployee);
			SelectedAvailableEmployee = null;
		}

		public void RemoveSelectedEmployee()
		{
			AvailableEmployees.Add(SelectedAssignedEmployee);
			AssignedEmployees.Remove(SelectedAssignedEmployee);
			SelectedAssignedEmployee = null;
		}

		public void SaveAssignedEmployees()
		{
			_worksheetVM.AssignedEmployees = AssignedEmployees;
		}

	}
}
