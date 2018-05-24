using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAccess;
using Model;

namespace ViewModel
{
	public class LogInViewModel : ViewModelBase
	{
		private EmployeeRepository _employeeRepository;

		public string EmployeeID { get; set; }

		public LogInViewModel()
		{
			_employeeRepository = new EmployeeRepository();

		}

		public ViewModelBase LogIn()
		{
			EmployeeID = "10000"; // TODO: remove this before final release.

			ViewModelBase viewModel = null;

			// TODO: uncomment retrieve method call (before final release).
			Employee employee = null; // = _employeeRepository.Retrieve(Convert.ToInt32(EmployeeID));

			if(employee != null)
			{
				if(employee.GetType() == typeof(OfficeWorker))
				{
					viewModel = new OfficeWorkerMenuViewModel();
				}
				else if(employee.GetType() == typeof(Fitter))
				{
					viewModel = new FitterMenuViewModel();
				}
			}
			else //TODO: Remove this before final release
			{
				if(EmployeeID == "10000")
				{
					viewModel = new OfficeWorkerMenuViewModel();
				}
				else if(EmployeeID == "10001")
				{
					viewModel = new FitterMenuViewModel();
				}
			}

			return viewModel;
		}
	}
}
