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
    /// Interaction logic for ViewTags.xaml
    /// </summary>
    public partial class ViewTags : UserControl
    {
        public ViewTags()
        {
            InitializeComponent();
            


        }

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("ViewTags");
		}

		private void DataGrid_Loaded(object sender, RoutedEventArgs e)
		{
			DataGrid dataGrid = sender as DataGrid;
			dataGrid.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
		}
	}
}
