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
using View.Windows;
using Microsoft.Win32;

namespace View.UserControls
{
	/// <summary>
	/// Interaction logic for WorksheetUC.xaml
	/// </summary>
	public partial class WorksheetUC : UserControl
	{
		private WorksheetViewModel _worksheetVM;

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

		private void SaveWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			_worksheetVM.SaveWorksheet();
		}

		private void AddMaterialsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new OfficeWorkerMenuUC());
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

		private void AddRemoveFitterButton_Click(object sender, RoutedEventArgs e)
		{
			AddFittersWindow addFittersWindow = new AddFittersWindow(_worksheetVM);
			addFittersWindow.Show();
		}

		private void AddPictureButton_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Image Files(*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png | All files (*.*)|*.*";
			fileDialog.RestoreDirectory = true;
			fileDialog.Multiselect = true;

			if(fileDialog.ShowDialog() == true)
			{
				_worksheetVM.AddImages(fileDialog.FileNames);
			}
		}
	}
}
