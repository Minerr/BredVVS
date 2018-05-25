using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace ViewModel
{
	class Program
	{
		static void Main(string[] args)
		{
			//Fitter fitter = new Fitter(new Name("Tim", "Timsen"), " ");
			//EmployeeRepository repo = new EmployeeRepository();
			//repo.Create(fitter);

			EmployeeRepository repo = new EmployeeRepository();

			//OfficeWorker officeWorker = new OfficeWorker(new Name("Hanne", "Johansen"));
			//repo.Create(officeWorker);

			Employee employee = repo.Retrieve(11000);
			Console.WriteLine(employee);


			Console.ReadKey();
		}
	}
}
