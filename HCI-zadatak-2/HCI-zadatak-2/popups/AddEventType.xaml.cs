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
using Microsoft.Win32;

namespace HCI_zadatak_2.popups
{
    /// <summary>
    /// Interaction logic for AddEventType.xaml
    /// </summary>
    public partial class AddEventType : Window
    {
        string iconPath = null;
        MainWindow parent { get; set; }
		private bool idEntered = false, nameEntered = false, descriptionEntered = false;

        public AddEventType(MainWindow parent)
        {
            InitializeComponent();
			DataContext = this;
            this.parent = parent;
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                this.iconPath = ofd.FileName;
                previewIcon.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }

		private bool ValidateAddEventType()
		{
			if (!idEntered || !nameEntered || !descriptionEntered) return false;
			else if (string.IsNullOrWhiteSpace(HRMarkTextBox.Text) || string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(DescTextBox.Text)) return false;
			return true;
		}

		private void CreateEventTypeBtn_Click(object sender, RoutedEventArgs e)
        {
			if (ValidateAddEventType())
			{
				var type = HRMarkTextBox.Text;
				var name = NameTextBox.Text;
				var iconPath = this.iconPath;
				if (string.IsNullOrWhiteSpace(iconPath))
				{
					MessageBox.Show("Icon is required");
					return;
				}
				var desc = DescTextBox.Text;


				EventType t = new EventType();
				t.Type = type;
				t.Name = name;
				t.Icon = iconPath;
				t.Description = desc;
				this.parent.appContext.EventTypes.Add(t);
				//this.parent.saveTypes();
				this.Close();

				MessageBox.Show("Event type is successfully created and saved.", "Notification", MessageBoxButton.OK);
				FileIO.WriteToFile("appContext.bin", parent.appContext);
			}
			else
			{
				MessageBox.Show("All fields must be filled");
			}
        }


		private void DescTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(DescTextBox.Text))
			{
				descriptionExclamIcon.Visibility = Visibility.Visible;
				descriptionEntered = false;
			} else
			{
				descriptionExclamIcon.Visibility = Visibility.Hidden;
				descriptionEntered = true;
			}
			
		}

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("AddEventType");
		}

		private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(NameTextBox.Text))
			{
				nameExclamIcon.Visibility = Visibility.Visible;
				nameEntered = false;
			}
			else
			{
				nameExclamIcon.Visibility = Visibility.Hidden;
				nameEntered = true;
			}
		}

		private void HRMarkTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(HRMarkTextBox.Text))
			{
				idExclamIcon.Visibility = Visibility.Visible;
				idEntered = false;
			}
			else
			{
				idExclamIcon.Visibility = Visibility.Hidden;
				idEntered = true;
			}
		}
	}
}
