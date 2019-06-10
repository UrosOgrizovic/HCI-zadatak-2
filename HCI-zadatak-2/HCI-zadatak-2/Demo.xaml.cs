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

namespace HCI_zadatak_2
{
	/// <summary>
	/// Interaction logic for Demo.xaml
	/// </summary>
	public partial class Demo : Window
	{
		public Demo()
		{
			InitializeComponent();
			demoMedia.Play();
		}

		private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
		{
			demoMedia.Position = new TimeSpan(0, 0, 1);
			demoMedia.Play();
		}

	}
}
