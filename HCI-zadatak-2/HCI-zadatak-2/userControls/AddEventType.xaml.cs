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
    /// Interaction logic for AddEventType.xaml
    /// </summary>
    public partial class AddEventType : UserControl
    {
        string iconPath = null;
        public static MainWindow parent { get; set; }

        public AddEventType()
        {
            InitializeComponent();
        }

        private void CreateEventTypeBtn_Click(object sender, RoutedEventArgs e)
        {
            var type = HRMarkTextBox.Text;
            var name = NameTextBox.Text;
            var iconPath = this.iconPath;
            var desc = DescTextBox.Text;

            if (EventTypeInputValidation(type, name, iconPath, desc))
            {
                EventType t = new EventType();
                t.Type = type;
                t.Name = name;
                t.Icon = iconPath;
                t.Description = desc;
                parent.appContext.EventTypes.Add(t);
                //this.parent.saveTypes();

                MessageBox.Show("Event type is successfully created and saved.", "Notification", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Some fields are empty or consists of white spaces, please fill them.", "Notiication", MessageBoxButton.OK);
            }
        }

        private Boolean EventTypeInputValidation(String type, String name, String iconPath, String desc)
        {
            if (String.IsNullOrWhiteSpace(type) || String.IsNullOrWhiteSpace(type) || String.IsNullOrWhiteSpace(type) || String.IsNullOrWhiteSpace(type))
                return false;
            return true;
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
                this.iconPath = ofd.FileName;
                previewIcon.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
    }



}
