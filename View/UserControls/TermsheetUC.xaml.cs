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
		public TermsheetUC()
		{
            _termsheetVM = new TermsheetViewModel();
			Init();

		}

		public TermsheetUC(TermsheetViewModel viewModel)
		{
            _termsheetVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _termsheetVM;

			GetFirmInfo();
		}

        private void GetFirmInfo()
        {
            FirmNameTextBox.Text = "Bred Vvs";
            FirmAddressTextBox.Text = "Nørrevej 45 C" + "\n" + "6340 Kruså";
            FirmPhonenumberTextBox.Text = "74 67 15 12";
            FirmCVRTextBox.Text = "34 22 35 72";
            CurrentDateTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
		    if (TaskListBox.SelectedItem != null)
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

		}

		private void PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			_termsheetVM.CalculateVATAndTotal(_termsheetVM.PriceExVAT);
		}

		private void TotalPriceTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			_termsheetVM.CalculateVATAndPrice(_termsheetVM.TotalPrice);
		}
	}
}
