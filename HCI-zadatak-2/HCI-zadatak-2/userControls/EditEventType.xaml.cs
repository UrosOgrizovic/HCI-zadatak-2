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

namespace HCI_zadatak_2.userControls
{
    /// <summary>
    /// Interaction logic for EditEventType.xaml
    /// </summary>
    public partial class EditEventType : UserControl
    {
		public static MainWindow Window { get; set; }

		public EditEventType()
        {
            InitializeComponent();
			DataContext = this;
		}

		private void BrowseBtn_Click_1(object sender, RoutedEventArgs e)
		{

		}

		private void editEventTypeBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
