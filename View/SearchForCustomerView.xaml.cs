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
	}
}