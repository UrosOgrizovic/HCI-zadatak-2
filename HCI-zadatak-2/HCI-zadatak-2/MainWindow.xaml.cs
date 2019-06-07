using HCI_zadatak_2.popups;
using HCI_zadatak_2.userControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
using AddEventType = HCI_zadatak_2.userControls.AddEventType;

namespace HCI_zadatak_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

        public ApplicationContext appContext { get; set; }


		protected void OnPropertyChanged(string info)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
		}

		private ICollectionView _View;

		public ICollectionView View
		{
			get
			{
				return _View;
			}
			set
			{
				_View = value;
				OnPropertyChanged("View");
			}
		}

		public MainWindow()
		{
			InitializeComponent();
            DataContext = this;
            appContext = new ApplicationContext();
            cityMap.Source = new BitmapImage(new Uri(@"/images/MapNS.png", UriKind.Relative));
            AddEventType.parent = this;


            //View = CollectionViewSource.GetDefaultView(appContext.Events);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TabItem t = (TabItem) tabControl.SelectedItem;
            if (t.Header.Equals("Events"))
            {
                popups.AddEvent m = new popups.AddEvent(this, null);
                m.ShowDialog();
            }
            else if (t.Header.Equals("Types"))
            {
                popups.AddEventType m = new popups.AddEventType(this);
                m.ShowDialog();
            } 
            else
            {
                popups.AddTag m = new popups.AddTag();
                m.ShowDialog();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Selected item will be removed. Please confirm.", "Confirmation", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                TabItem t = (TabItem)tabControl.SelectedItem;
                if (t.Header.Equals("Events"))
                {
					//appContext.Events.RemoveAt(eventsView.SelectedIndex);
					appContext.Events.RemoveAt(controlEventsView.eventsView.SelectedIndex);
					
				}
				else if (t.Header.Equals("Types"))
                {
					//appContext.EventTypes.RemoveAt(eventTypesView.SelectedIndex);
					appContext.EventTypes.RemoveAt(controlEventTypesView.eventTypesView.SelectedIndex);
				}
                else
                {
					//appContext.Tags.RemoveAt(tagsView.SelectedIndex);
					appContext.Tags.RemoveAt(controlTagsView.tagsView.SelectedIndex);
				}
            }
        }

        public Point startPoint = new Point();
		
        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            } 
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {        
                Point p = e.GetPosition((IInputElement)e.Source);

                Event ev = new Event();
                ev.OffsetX = p.X;
                ev.OffsetY = p.Y;
                ev.Type = e.Data.GetData("myFormat") as EventType;

                AddEvent addEvent = new AddEvent(this, ev);
               
                addEvent.ShowDialog();
            } 
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        { 
			controlEventsView.eventsView.ItemsSource = appContext.Search(searchTxt.Text);
		}
    }
}
