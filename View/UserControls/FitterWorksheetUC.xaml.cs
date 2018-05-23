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
	/// Interaction logic for FitterWorksheetUC.xaml
	/// </summary>
	public partial class FitterWorksheetUC : UserControl
	{
		private FitterWorksheetViewModel _fitterWorksheetVM;

		public FitterWorksheetUC()
		{
			_fitterWorksheetVM = null;
			Init();
		}

		public FitterWorksheetUC(FitterWorksheetViewModel viewModel)
		{
			_fitterWorksheetVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _fitterWorksheetVM;
		}

		private void AddRemoveMaterialsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddRemoveWorkHoursButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddPictureButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CreateTermsheetButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new TermsheetUC(_fitterWorksheetVM.CreateNewTermsheet()));
		}

		private void ShowTermsheetsButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void GoBackButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new FitterMenuUC());
		}
	}
}
