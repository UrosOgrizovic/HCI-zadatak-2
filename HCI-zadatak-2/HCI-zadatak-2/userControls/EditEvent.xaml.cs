using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
	/// Interaction logic for EditEvent.xaml
	/// </summary>
	public partial class EditEvent : UserControl
	{

		public static MainWindow Window { get; set; }
		
		

		public EditEvent()
        {
			
			InitializeComponent();
			DataContext = this;
		}

		

		private void EditEventBtn_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("cao");
		}

		private void RemoveTagBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddTagToTagsOfEventBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
