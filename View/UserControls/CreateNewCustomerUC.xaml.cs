﻿using System;
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
	/// Interaction logic for CreateNewCustomerUC.xaml
	/// </summary>
	public partial class CreateNewCustomerUC : UserControl
	{
		private CreateNewCustomerViewModel _createNewCustomerVM;
		public CreateNewCustomerUC()
		{
			_createNewCustomerVM = new CreateNewCustomerViewModel();
			Init();
		}

		public CreateNewCustomerUC(CreateNewCustomerViewModel viewModel)
		{
			_createNewCustomerVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _createNewCustomerVM;
		}

		private void SearchForCustomerButton_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void SaveCustomerButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new WorksheetUC(_createNewCustomerVM.CreateNewCustomer()));
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new SearchForCustomerUC());
		}

		private void TextBoxChanged(object sender, TextChangedEventArgs e)
		{
			SaveCustomerButton.IsEnabled = _createNewCustomerVM.IsCustomerDataNotNull();
		}
	}
}
