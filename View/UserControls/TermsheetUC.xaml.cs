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
using View.Windows;

namespace View.UserControls
{
	/// <summary>
	/// Interaction logic for TermsheetUC.xaml
	/// </summary>
	public partial class TermsheetUC : UserControl
	{
		private TermsheetViewModel _termsheetVM;

		public TermsheetUC(TermsheetViewModel viewModel)
		{
			_termsheetVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _termsheetVM;
		}

		private void AddTaskButton_Click(object sender, RoutedEventArgs e)
		{
			AddTaskWindow addTaskView = new AddTaskWindow(_termsheetVM);
			addTaskView.Show();
		}

		private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
		{
			_termsheetVM.RemoveTask();
		}

		private void AddSignature_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(TaskListBox.SelectedItem != null)
			{
				RemoveTaskButton.IsEnabled = true;
			}
			else
			{
				RemoveTaskButton.IsEnabled = false;
			}
		}

		private void SaveTermsheetButton_Click(object sender, RoutedEventArgs e)
		{
			_termsheetVM.SaveTermsheet();
			PageCommands.Instance.GoTo(new FitterWorksheetUC(_termsheetVM.GoBack()));
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			PageCommands.Instance.GoTo(new FitterWorksheetUC(_termsheetVM.GoBack()));

		}
	}
}
