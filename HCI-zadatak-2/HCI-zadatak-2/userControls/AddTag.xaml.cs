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
        }

        public static MainWindow parent { get; set; }



        private void CreateTagBtn_Click(object sender, RoutedEventArgs e)
        {
            if (verifyInputs())
            {
                Tag tag = new Tag();
                tag.Id = TagIdTextBox.Text;
                //tag.Color
                tag.Description = TagDescriptionTextBox.Text;
                tag.IsActive = true;
                if (verifyTag(tag))
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
                MessageBox.Show("URKE STAVI PORUKU");
            }   
        }


        private bool verifyInputs()
        {
            return true;
        }


        private bool verifyTag(Tag t)
        {
            foreach (Tag existent in parent.appContext.Tags)
            {
                if (existent.Id.Equals(t.Id))
                    return false;
            }

            return true;
        }
    }
}
