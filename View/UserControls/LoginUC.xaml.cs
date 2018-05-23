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
	/// Interaction logic for LoginUC.xaml
	/// </summary>
	public partial class LoginUC : UserControl
	{
		private LoginViewModel _loginVM;
		public LoginUC()
		{
			_loginVM = new LoginViewModel();
			Init();
		}

		public LoginUC(LoginViewModel viewModel)
		{
			_loginVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _loginVM;
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			ViewModelBase viewModel = _loginVM.LogIn();

			if(viewModel != null)
			{
				if(viewModel.GetType() == typeof(OfficeWorkerMenuViewModel))
				{
					PageCommands.Instance.GoTo(new OfficeWorkerMenuUC());
				}
				else if(viewModel.GetType() == typeof(FitterMenuViewModel))
				{
					PageCommands.Instance.GoTo(new FitterMenuUC());
				}
			}
			else
			{
				ErrorMessageLabel.Visibility = Visibility.Visible;
			}
		}

		private void TextBoxes_SelectionChanged(object sender, RoutedEventArgs e)
		{
			ErrorMessageLabel.Visibility = Visibility.Hidden;
		}
	}
}
