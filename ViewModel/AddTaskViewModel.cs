using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
	public class AddTaskViewModel : ViewModelBase
	{
		public ObservableCollection<string> TasksList { get; set; }

		public string SelectedTask { get; set; }
		public string SelectedCustomTask { get; set; }

		public AddTaskViewModel()
		{
			TasksList = RetrieveTasks();
		}

		public ObservableCollection<string> RetrieveTasks()
		{
			ObservableCollection<string> tasks = new ObservableCollection<string>();

			tasks.Add("Installer håndvask");
			tasks.Add("Installer toilet");
			tasks.Add("Installer bruser");

			return tasks;
		}

		public void SelectTask(TermsheetViewModel termsheetViewModel)
		{
			termsheetViewModel.SelectedTasksList.Add(SelectedTask);
		}

		public void SelectCustomTask(TermsheetViewModel termsheetViewModel)
		{
			termsheetViewModel.SelectedTasksList.Add(SelectedCustomTask);
		}

	}
}
