using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class AddTaskViewModel
	{
		public List<string> TasksList
		{
			get
			{
				return RetrieveTasks();
			}
		}

		public string SelectedTask { get; set; }

		private static AddTaskViewModel _instance;

		public AddTaskViewModel()
		{
		}

		public static AddTaskViewModel Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new AddTaskViewModel();
				}

				return _instance;
			}
		}

		public List<string> RetrieveTasks()
		{
			List<string> tasks = new List<string>();

			tasks.Add("Installer håndvask");
			tasks.Add("Installer toilet");
			tasks.Add("Installer bruser");

			return tasks;
		}

		public void SelectTask()
		{
			TermsheetViewModel.Instance.AddTask(SelectedTask);
		}

	}
}
