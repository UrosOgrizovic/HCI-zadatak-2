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
    /// Interaction logic for AddTag.xaml
    /// </summary>
    public partial class AddTag : UserControl
    {
        public AddTag()
        {
            InitializeComponent();
			DataContext = this;
        }

        public static MainWindow parent { get; set; }

		private bool idEntered = false, descriptionEntered = false;

        private void CreateTagBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VerifyInputs())
            {
                Tag tag = new Tag();
                tag.Id = TagIdTextBox.Text;
                //tag.Color
                tag.Description = TagDescriptionTextBox.Text;
                tag.IsActive = true;
                if (VerifyTag(tag))
                {
                    parent.appContext.Tags.Add(tag);
                    MessageBox.Show("Tag is successfully added.");
                }
                else
                {
                    MessageBox.Show("Tag with selected ID already exists.");
                }
            }
            else
            {
				MessageBox.Show("All fields must be filled");
			}   
        }

        private bool VerifyInputs()
        {
			if (!idEntered || !descriptionEntered) return false;
			else if (string.IsNullOrWhiteSpace(TagIdTextBox.Text) || string.IsNullOrWhiteSpace(TagDescriptionTextBox.Text)) return false;
            return true;
        }


        private bool VerifyTag(Tag t)
        {
            foreach (Tag existent in parent.appContext.Tags)
            {
                if (existent.Id.Equals(t.Id))
                    return false;
            }

            return true;
        }

		private void TagIdTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TagIdTextBox.Text))
			{
				idExclamIcon.Visibility = Visibility.Visible;
				idEntered = false;
			} else
			{
				idExclamIcon.Visibility = Visibility.Hidden;
				idEntered = true;
			}
		}

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("AddTag");
		}

		private void TagDescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TagDescriptionTextBox.Text))
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
