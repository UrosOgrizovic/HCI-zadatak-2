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
        string iconPath = null;
        public static AppImage icon = null;
		private bool nameEntered = true, descriptionEntered = true;

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

            if (VerifyInputs())
            {
                EventType et = Window.appContext.SelectedEventType;
                et.Description = DescTextBox.Text;
                if (iconPath != null)
                {
                    foreach (Event ee in Window.appContext.Events)
                    { 
                        if (ee.ImageIcon != null && !ee.ImageIcon.Path.Equals(iconPath) && et.Icon.Equals(ee.ImageIcon.Path) && et.Name.Equals(ee.Type.Name))
                        {
                            AppImage img = new AppImage
                            {
                                Width = 30,
                                Height = 30,
                                Name = "marker",
                                Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute)),
                                Path = iconPath,
                                Event = ee
                            };

                            Window.canvas.Children.Remove(ee.ImageIcon);
                            ee.ImageIcon = img;
                            Window.canvas.Children.Add(ee.ImageIcon);
                            Canvas.SetTop(ee.ImageIcon, ee.OffsetY);
                            Canvas.SetLeft(ee.ImageIcon, ee.OffsetX);
                        }
                    }

                    et.Icon = iconPath;
                }
                


                MessageBox.Show("Changes successfully saved.");
            }
            else
            {
                MessageBox.Show("All fields must be filled");
            }
		}

        private bool VerifyInputs()
        {
			if (!nameEntered || !descriptionEntered) return false;
			else if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(DescTextBox.Text)) return false;
            return true;
        }

		private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(NameTextBox.Text))
			{
				nameExclamIcon.Visibility = Visibility.Visible;
				nameEntered = false;
			} else
			{
				nameExclamIcon.Visibility = Visibility.Hidden;
				nameEntered = true;
			}
		}

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("EditEventType");
		}

		private void DescTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(DescTextBox.Text))
			{
				descriptionExclamIcon.Visibility = Visibility.Visible;
				descriptionEntered = false;
			}
			else
			{
				descriptionExclamIcon.Visibility = Visibility.Hidden;
				descriptionEntered = true;
			}
		}
	}
}
