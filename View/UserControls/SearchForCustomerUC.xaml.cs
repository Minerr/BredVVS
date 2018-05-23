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
    /// Interaction logic for SearchForCustomerUC.xaml
    /// </summary>
    public partial class SearchForCustomerUC : UserControl
    {
        private SearchForCustomerViewModel _searchForCustomerVM;
        public SearchForCustomerUC()
        {
            _searchForCustomerVM = new SearchForCustomerViewModel();
            Init();
        }

        public SearchForCustomerUC(SearchForCustomerViewModel viewModel)
        {
            _searchForCustomerVM = viewModel;
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            DataContext = _searchForCustomerVM;
        }

        private void SearchForCustomerButton_Click(object sender, RoutedEventArgs e)
        {

			_searchForCustomerVM.RetrieveCustomers(SearchForCustomerTextBox.Text);

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
			PageCommands.Instance.GoTo(new WorksheetUC(_searchForCustomerVM.SelectCustomer()));
        }

        private void CreateNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
			PageCommands.Instance.GoTo(new CreateNewCustomerUC());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
			PageCommands.Instance.GoTo(new OfficeWorkerMenuUC());

		}
    }
}
