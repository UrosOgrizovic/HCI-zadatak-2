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
using System.Windows.Shapes;
using System.IO;

namespace HCI_zadatak_2
{
	/// <summary>
	/// Interaction logic for HelpView.xaml
	/// </summary>
	public partial class HelpView : Window
	{
		public HelpView(string key)
		{
			InitializeComponent();
			string curDir = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
			string path = string.Format("{0}/Data/Help/{1}.htm", curDir, key);
			if (!File.Exists(path))
			{
				key = "error";
			}
			Uri u = new Uri(string.Format("file:///{0}/Data/Help/{1}.htm", curDir, key));
			wbHelp.Navigate(u);
		}

		private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (wbHelp != null) && wbHelp.CanGoBack;
		}

		private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			wbHelp.GoBack();
		}

		private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (wbHelp != null) && wbHelp.CanGoForward;
		}

		private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			wbHelp.GoForward();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		private void wbHelp_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
		{
		}
	}
}
