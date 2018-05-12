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
    /// Interaction logic for TermsheetUC.xaml
    /// </summary>
    public partial class TermsheetUC : UserControl
    {
		private TermsheetVM _termsheetVM;
        public TermsheetUC()
        {
			_termsheetVM = new TermsheetVM();
			Init();
		}

		public TermsheetUC(TermsheetVM viewModel)
		{
			_termsheetVM = viewModel;
			Init();
		}

		private void Init()
		{
			InitializeComponent();
			DataContext = _termsheetVM;
		}
	}
}
