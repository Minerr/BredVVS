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

namespace View.Windows
{
	/// <summary>
	/// Interaction logic for AddTaskView.xaml
	/// </summary>
	public partial class AddTaskWindow : Window
	{
		private AddTaskViewModel _addTaskViewModel;
		private TermsheetViewModel _termsheetVM;

		public AddTaskWindow(TermsheetViewModel termsheetVM)
		{
			_addTaskViewModel = new AddTaskViewModel();
			_termsheetVM = termsheetVM;

			InitializeComponent();
			DataContext = _addTaskViewModel;
		}

		private void AddTaskButton_Click(object sender, RoutedEventArgs e)
		{
			_addTaskViewModel.SelectTask(_termsheetVM);
			this.Close();
		}

		private void AddCustomTaskButton_Click(object sender, RoutedEventArgs e)
		{
			_addTaskViewModel.SelectCustomTask(_termsheetVM);
			this.Close();
		}
	}
}
