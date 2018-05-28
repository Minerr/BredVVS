using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DataAccess;
using Model;

namespace ViewModel
{
	public class LogInViewModel : ViewModelBase
	{
		private EmployeeRepository _employeeRepository;

		private string _employeeID;
		public string EmployeeID
		{
			get { return _employeeID; }
			set
			{
				_employeeID = value;
				OnPropertyChanged("EmployeeID");
				OnPropertyChanged("ErrorMessage");
			}
		}

		public string ErrorMessage
		{
			get { return "Fejl! Kunne ikke finde ID: " + EmployeeID; }
		}

		public LogInViewModel()
		{
			_employeeRepository = new EmployeeRepository();
		}

		public ViewModelBase LogIn()
		{
			ViewModelBase viewModel = null;
			int employeeID = Convert.ToInt32(EmployeeID);

			Employee employee = _employeeRepository.Retrieve(employeeID);
			ClientInfo.Instance.Employee = employee;

			if(employee != null)
			{
				if(employee.Type == EmployeeType.OfficeWorker)
				{
					viewModel = new OfficeWorkerMenuViewModel();
				}
				else if(employee.Type == EmployeeType.Fitter)
				{
					viewModel = new FitterMenuViewModel();
				}
			}

			return viewModel;
		}
	}
}
