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

		public Window MainWindow { get; set; }


		private PageCommands()
		{

		}

		public void GoTo(UserControl newPage)
		{
			if(MainWindow != null)
			{
				Grid mainGrid = MainWindow.FindName("MainGrid") as Grid;

				mainGrid.Children.Clear();
				mainGrid.Children.Add(newPage);
			}
		}
	}
}
