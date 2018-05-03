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
	/// Interaction logic for SearchForClientView.xaml
	/// </summary>
	public partial class SearchForCustomerView : Window
	{
        SearchForCustomerViewModel searchForCustomerViewModel;

		public SearchForCustomerView()
		{
            searchForCustomerViewModel = new SearchForCustomerViewModel();
            InitializeComponent();
            DataContext = searchForCustomerViewModel;
		}

		private void SearchForCustomerButton_Click(object sender, RoutedEventArgs e)
		{

            searchForCustomerViewModel.RetrieveCustomers(SearchForCustomerBar.Text);

        }

		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (CustomerListView.SelectedItem != null)
			{
				SelectCustomerButton.IsEnabled = true;
				EditCustomerButton.IsEnabled = true;
			}
			else
			{
				SelectCustomerButton.IsEnabled = false;
				EditCustomerButton.IsEnabled = false;
			}
		}

		private void SelectCustomerButton_Click(object sender, RoutedEventArgs e)
		{

			WorksheetView worksheetView = new WorksheetView();
			
			worksheetView.Show();

			this.Close();
		}

	private void CreateNewCustomerButton_Click(object sender, RoutedEventArgs e)
	{
		CreateNewCustomerViewModel createNewCustomerViewModel = CreateNewCustomerViewModel.Instance;
            CreateNewCustomerView createNewCustomerView = new CreateNewCustomerView();

            createNewCustomerView.Show();
            this.Close();

        }

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			OfficeWorkerMenuView officeWorkerMenuView = new OfficeWorkerMenuView();
			officeWorkerMenuView.Show();
			this.Close();
		}
	}
}
