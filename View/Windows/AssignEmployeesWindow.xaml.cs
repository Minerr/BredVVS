using System;
using System.Collections.Generic;
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

namespace View.Windows
{
	/// <summary>
	/// Interaction logic for AddFitterWindow.xaml
	/// </summary>
	public partial class AssignEmployeesWindow : Window
	{
		private AssignEmployeesViewModel _addFittersVM;

		public AssignEmployeesWindow(AssignEmployeesViewModel viewModel)
		{
			_addFittersVM = viewModel;

			InitializeComponent();
			DataContext = _addFittersVM;
		}

		private void SelectFitterButton_Click(object sender, RoutedEventArgs e)
		{
			_addFittersVM.AddSelectedEmployee();
		}

		private void RemoveFitterButton_Click(object sender, RoutedEventArgs e)
		{
			_addFittersVM.RemoveSelectedEmployee();
		}

		private void SaveAssignedFittersButton_Click(object sender, RoutedEventArgs e)
		{
			_addFittersVM.SaveAssignedEmployees();
			this.Close();
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
