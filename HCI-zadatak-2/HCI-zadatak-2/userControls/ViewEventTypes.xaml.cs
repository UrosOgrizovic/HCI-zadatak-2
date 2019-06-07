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
    /// Interaction logic for ViewEventTypes.xaml
    /// </summary>
    public partial class ViewEventTypes : UserControl
    {
		public Point startPoint = new Point();

		public ViewEventTypes()
        {
            InitializeComponent();
        }

		private void EventTypesView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			startPoint = e.GetPosition(null);
		}

		private void EventTypesView_MouseMove(object sender, MouseEventArgs e)
		{
			Point mousePos = e.GetPosition(null);
			Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                DataGrid dg = sender as DataGrid;
                DataGridRow row = FindAncestor<DataGridRow>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                if (row != null)
                {
                    EventType et = (EventType)row.DataContext;

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", et);
                    DragDrop.DoDragDrop(row, dragData, DragDropEffects.Move);
                }
            }
		}

		private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
		{
			do
			{
				if (current is T)
				{
					return (T)current;
				}
				current = VisualTreeHelper.GetParent(current);
			}
			while (current != null);
			return null;
		}
	}
}
