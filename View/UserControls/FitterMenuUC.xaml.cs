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
	/// Interaction logic for FitterMenuUC.xaml
	/// </summary>
	public partial class FitterMenuUC : UserControl
	{
		private FitterMenuViewModel _fitterMenuVM;

		public FitterMenuUC()
		{
			_fitterMenuVM = new FitterMenuViewModel();
			Init();
		}

		public FitterMenuUC(FitterMenuViewModel viewModel)
		{
			_fitterMenuVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _fitterMenuVM;
		}


		private void SelectWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			
			PageCommands.Instance.GoTo(new FitterWorksheetUC( _fitterMenuVM.SelectWorksheet() ));
		}

		private void LogOutButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new LogInUC());
		}

		private void WorksheetListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool isEnabled = _fitterMenuVM.IsWorksheetSelected();
			SelectWorksheetButton.IsEnabled = isEnabled;
		}
	}
}
