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

namespace View
{
	/// <summary>
	/// Interaction logic for WorksheetView.xaml
	/// </summary>
	public partial class WorksheetView : Window
	{
		public WorksheetView()
		{
			WorksheetViewModel worksheetViewModel = WorksheetViewModel.Instance;
			InitializeComponent();

			DataContext = worksheetViewModel;
		}

		private void AddHoursButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CreateTermsheetButton_Click(object sender, RoutedEventArgs e)
		{
			TermsheetView termsheetView = new TermsheetView(WorksheetViewModel.Instance);
			termsheetView.Show();

			this.Close();

		}

		private void SaveWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			WorksheetViewModel.Instance.CreateWorksheet();
		}

		private void AddFitterButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void TakePictureButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddMaterialsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			OfficeWorkerMenuView officeWorkerMenuView = new OfficeWorkerMenuView();
			officeWorkerMenuView.Show();

			this.Close();
		}

		private void RemoveFitterButton_Click(object sender, RoutedEventArgs e)
		{
			// Remove fitter from AssignedFitters.
		}

		private void FitterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// if selected fitter != null
			// Set RemoveFitterButton.IsEnabled = true;
		}

		private void RemoveSelectedHourButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RemoveSelectedMaterialButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void WorkTimeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void MaterialsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
