using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;

namespace View
{
	/// <summary>
	/// Interaction logic for TermsheetView.xaml
	/// </summary>
	public partial class TermsheetView : Window
	{
		public TermsheetView(WorksheetViewModel customerInfo)
		{

			InitializeComponent();
			DataContext = TermsheetViewModel.Instance;

			GetFirmInfo();

		}

		private void GetFirmInfo()
		{
			DateTime currentDate = DateTime.Today;

			FirmNameTextBox.Text = "Bred Vvs";
			FirmAddressTextBox.Text = "Nørrevej 45 C" + "\n" + "6340 Kruså";
			FirmPhonenumberTextBox.Text = "74 67 15 12";
			FirmCVRTextBox.Text = "34 22 35 72";
			CurrentDatePicker.Text = currentDate.ToString();
		}


		private void AddTaskButton_Click(object sender, RoutedEventArgs e)
		{
			AddTaskView addTaskView = new AddTaskView();
			addTaskView.Show();
		}

		private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedTask = TaskListBox.SelectedItem;
			TermsheetViewModel.Instance.RemoveTask(selectedTask);
		}

		private void AddSignature_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
