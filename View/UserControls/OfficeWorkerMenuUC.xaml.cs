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
    /// Interaction logic for OfficeWorkerMenuUC.xaml
    /// </summary>
    public partial class OfficeWorkerMenuUC : UserControl
    {
		private OfficeWorkerMenuVM _officeWorkerMenuVM;
		public OfficeWorkerMenuUC()
		{
			_officeWorkerMenuVM = new OfficeWorkerMenuVM();
			Init();
		}

		public OfficeWorkerMenuUC(OfficeWorkerMenuVM viewModel)
		{
			_officeWorkerMenuVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _officeWorkerMenuVM;
		}

		private void CreateWorksheetButton_Click(object sender, RoutedEventArgs e)
		{
			PageControlCommands.GoTo(this, new SearchForCustomerUC());
		}
	}
}
