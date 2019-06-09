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

		public EditTag()
        {
            InitializeComponent();
			DataContext = this;
		}

		private void editTagBtn_Click(object sender, RoutedEventArgs e)
        { 
            if (verifyInputs())
            {
                Tag t = Window.appContext.SelectedTag;
                // COLOR PICKER
                t.Description = TagDescriptionTextBox.Text;
                t.IsActive = true;
            }
		}

        private bool verifyInputs()
        {
            return true;
        }
	}
}
