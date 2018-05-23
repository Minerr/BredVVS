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
	/// Interaction logic for OfficeWorkerMenuUC.xaml
	/// </summary>
	public partial class OfficeWorkerMenuUC : UserControl
	{
		private OfficeWorkerMenuViewModel _officeWorkerMenuVM;
		public OfficeWorkerMenuUC()
		{
			_officeWorkerMenuVM = new OfficeWorkerMenuViewModel();
			Init();
		}

		public OfficeWorkerMenuUC(OfficeWorkerMenuViewModel viewModel)
		{
			_officeWorkerMenuVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _officeWorkerMenuVM;
		}

		private void CreateWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new SearchForCustomerUC());
		}

		private void LogOutButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new LogInUC());
		}
	}
}
