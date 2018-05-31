using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModel;

namespace View
{
	internal class PageCommands
	{
		#region Singleton...
		private static PageCommands _instance;
		public static PageCommands Instance
		{
			get
			{
				if(_instance == null)
				{
					_instance = new PageCommands();
				}

				return _instance;
			}
		}
		#endregion

		private Grid _mainGrid;
		public Window MainWindow
		{
			set { _mainGrid = value.FindName("MainGrid") as Grid; }
		}

		private PageCommands()
		{
		}

		public void GoTo(UserControl newPage)
		{
			if(_mainGrid != null)
			{
				_mainGrid.Children.Clear();
				_mainGrid.Children.Add(newPage);
			}
		}
	}
}
