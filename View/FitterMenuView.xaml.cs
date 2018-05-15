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
	/// Interaction logic for FitterMenuView.xaml
	/// </summary>
	public partial class FitterMenuView : Window
	{
		private FitterMenuViewModel _fitterMenuViewModel;
		public FitterMenuView()
		{
			_fitterMenuViewModel = new FitterMenuViewModel();
			InitializeComponent();
			DataContext = _fitterMenuViewModel;
		}

		private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void SearchForWorksheetButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void SelectWorksheetButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void SearchForWorksheetButton_Click_1(object sender, RoutedEventArgs e)
		{

		}
	}
}
