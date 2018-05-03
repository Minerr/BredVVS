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
	/// Interaction logic for AddNewCustomer.xaml
	/// </summary>
	public partial class CreateNewCustomerView : Window
	{
        private CreateNewCustomerViewModel createNewCustomerViewModel;

		public CreateNewCustomerView()
		{
            createNewCustomerViewModel = CreateNewCustomerViewModel.Instance;
            InitializeComponent();
            DataContext = createNewCustomerViewModel;
		}

		private void SearchForCustomerButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

        private void SaveCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            createNewCustomerViewModel.CreateNewCustomer();

			WorksheetView worksheet = new WorksheetView();
			worksheet.Show();
			this.Close();
        }

        private void TextBoxChanged(object sender, RoutedEventArgs e)
        {
            SaveCustomerButton.IsEnabled = createNewCustomerViewModel.IsCustomerDataNotNull();
        }

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			SearchForCustomerView searchForCustomer = new SearchForCustomerView();
			searchForCustomer.Show();
			this.Close();
		}
	}
}
