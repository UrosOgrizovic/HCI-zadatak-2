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
    public partial class EditTag : UserControl
    {
		public static MainWindow Window { get; set; }
		private bool descriptionEntered = true;

		public EditTag()
        {
            InitializeComponent();
			DataContext = this;
		}

		private void editTagBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (VerifyInputs())
            {
                Tag t = Window.appContext.SelectedTag;
				if (colorPicker.SelectedColor == null)
				{
					MessageBox.Show("Color is required");
					return;
				}
                t.Color = (Color)colorPicker.SelectedColor;
                t.Description = TagDescriptionTextBox.Text;
                t.IsActive = true;
                MessageBox.Show("Changes saved successfully!");
				FileIO.WriteToFile("appContext.bin", Window.appContext);
			} else
			{
				MessageBox.Show("All fields must be filled");
			}
		}

        private bool VerifyInputs()
        {
			if (!descriptionEntered || string.IsNullOrWhiteSpace(TagDescriptionTextBox.Text)) return false;
            return true;
        }

		private void TagDescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TagDescriptionTextBox.Text))
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
			HelpProvider.ShowHelp("EditTag");
		}
	}
}
