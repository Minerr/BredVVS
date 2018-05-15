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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace View.UserControls
{
	/// <summary>
	/// Interaction logic for WorksheetUC.xaml
	/// </summary>
	public partial class WorksheetUC : UserControl
	{
		private WorksheetViewModel _worksheetVM;
		public WorksheetUC()
		{
			_worksheetVM = new WorksheetViewModel();
			Init();
		}

		public WorksheetUC(WorksheetViewModel viewModel)
		{
			_worksheetVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _worksheetVM;
		}

		private void AddHoursButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CreateTermsheetButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.GoTo(this, new TermsheetUC(_worksheetVM.CreateNewTermsheet()));
		}

		private void SaveWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			_worksheetVM.CreateWorksheet();
		}

		private void AddFitterButton_Click(object sender, RoutedEventArgs e)
		{
			AddFitterListBox.Visibility = Visibility.Visible;
		}

		private void TakePictureButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddMaterialsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.GoTo(this, new OfficeWorkerMenuUC()); // TODO: Create categorized GoBack method
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

		private void AddFitterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//_worksheetViewModel.AssignFitter(Fitter)
			AddFitterListBox.Visibility = Visibility.Collapsed;
		}

		private void AddFitterListBox_LostFocus(object sender, RoutedEventArgs e)
		{
			AddFitterListBox.Visibility = Visibility.Collapsed;
		}
	}
}
