using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ViewModel;

namespace View
{
	public static class PageControlCommands
	{
		private static Stack<UserControl> _pageHistory = new Stack<UserControl>();

		public static void GoTo(UserControl currentPage, UserControl newPage)
		{
			_pageHistory.Push(currentPage);
			Grid mainGrid = currentPage.FindName("MainGrid") as Grid;

			mainGrid.Children.Clear();
			mainGrid.Children.Add(newPage);
		}

		public static void GoTo(UserControl currentPage, UserControl newPage, ViewModelBase viewModel)
		{
			_pageHistory.Push(currentPage);
			Grid mainGrid = currentPage.FindName("MainGrid") as Grid;
			newPage.DataContext = viewModel;

			mainGrid.Children.Clear();
			mainGrid.Children.Add(newPage);
		}

		public static void GoBack(UserControl currentPage)
		{
			Grid mainGrid = currentPage.FindName("MainGrid") as Grid;

			mainGrid.Children.Clear();
			UserControl lastPage = _pageHistory.Pop();
			mainGrid.Children.Add(Activator.CreateInstance(lastPage.GetType()) as UserControl);
		}

		private static bool IsPageTypeValid(Type pageType)
		{
			bool result = true;
			if(pageType != typeof(UserControl))
			{
				result = false;
			}
			return result;
		}
	}
}
