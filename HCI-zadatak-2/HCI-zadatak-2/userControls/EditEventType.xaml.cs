using HCI_zadatak_2.images;
using Microsoft.Win32;
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
        string iconPath;
        AppImage icon;

        public EditEventType()
        {
            InitializeComponent();
			DataContext = this;
            
		}

		private void BrowseBtn_Click_1(object sender, RoutedEventArgs e)
		{
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                iconPath = ofd.FileName;
                icon = new AppImage
                {
                    Width = 30,
                    Height = 30,
                    Name = "marker",
                    Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute)),
                    Path = iconPath
                };
                previewIcon.Source = icon.Source;
            }
        }

		private void editEventTypeBtn_Click(object sender, RoutedEventArgs e)
		{

            if (verifyInputs())
            {
                EventType et = Window.appContext.SelectedEventType;
                et.Description = DescTextBox.Text;
                et.Icon = iconPath;
                
                


                MessageBox.Show("Changes successfully saved.");
            }
            else
            {
                MessageBox.Show("URKE PORUKA!");
            }
		}

        private bool verifyInputs()
        {
            return true;
        }
	}
}
