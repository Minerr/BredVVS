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
    /// Interaction logic for LogInVM.xaml
    /// </summary>
    public partial class LogInUC : UserControl
    {
		private LogInVM _logInVM;

        public LogInUC()
        {
			_logInVM = new LogInVM();
			Init();
		}

		public LogInUC(LogInVM viewModel)
		{
			_logInVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _logInVM;
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			PageControlCommands.GoTo(this, new OfficeWorkerMenuUC());
		}
	}
}
