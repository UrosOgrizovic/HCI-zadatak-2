using HCI_zadatak_2.images;
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
using EditEvent = HCI_zadatak_2.userControls.EditEvent;

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


        private AppImage draggedImage;
        private Point mousePosition;



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            appContext = new ApplicationContext();
            cityMap.Source = new BitmapImage(new Uri(@"/images/MapNS.png", UriKind.Relative));
            AddEventType.parent = this;
            userControls.AddTag.parent = this;

            EditEvent.Window = this;
            EditTag.Window = this;
            EditEventType.Window = this;
			

            ViewEvents.Window = this;
            addIconsToMap();
        }


        private void addIconsToMap()
        {
            foreach (Event e in appContext.Events)
            {
                canvas.Children.Add(e.ImageIcon);
                Canvas.SetTop(e.ImageIcon, e.OffsetY);
                Canvas.SetLeft(e.ImageIcon, e.OffsetX);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TabItem t = (TabItem)tabControl.SelectedItem;
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
                    Event ee = appContext.SelectedEvent;
                    canvas.Children.Remove(ee.ImageIcon);
                    appContext.Events.RemoveAt(controlEventsView.eventsView.SelectedIndex);

                }
                else if (t.Header.Equals("Types"))
                {
                    EventType type = controlEventTypesView.eventTypesView.SelectedItem as EventType;


                    foreach (Event ev in appContext.Events)
                    {
                        if (ev.Type.Name.Equals(type.Name))
                        {
                            MessageBox.Show("Type is used by events!");
                            return;
                        }
                    }
                    appContext.EventTypes.RemoveAt(controlEventTypesView.eventTypesView.SelectedIndex);
                }
                else
                {

                    Tag tt = controlTagsView.tagsView.SelectedItem as Tag;
                    foreach (Event ev in appContext.Events)
                    {
                        foreach (Tag tev in ev.Tags)
                            if (tev.Id.Equals(tt.Id))
                            {
                                MessageBox.Show("Tag is used by events!");
                                return;
                            }
                    }
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


        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var image = e.Source as AppImage;

            if (image != null && image.Name != "cityMap" && canvas.CaptureMouse())
            {

                mousePosition = e.GetPosition(canvas);
                Mouse.OverrideCursor = Cursors.Hand;
                draggedImage = image;
                Panel.SetZIndex(draggedImage, 1); // in case of multiple images
            }
        }

        private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
            if (draggedImage != null)
            {
                canvas.ReleaseMouseCapture();
                Point p = Mouse.GetPosition(canvas);
                draggedImage.Event.OffsetX = p.X;
                draggedImage.Event.OffsetY = p.Y;
                Panel.SetZIndex(draggedImage, 0);
                draggedImage = null;
            }
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (draggedImage != null)
            {
                var position = e.GetPosition(canvas);
                var offset = position - mousePosition;
                mousePosition = position;
                Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
                Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);
            }
        }

        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                AddEvent ad = new AddEvent(this, null);
                AppImage img = e.Source as AppImage;
                MessageBox.Show(img.Event.Type.Type.ToString());
            }
        }


        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EventsTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Event selectedEvent = (Event)controlEventsView.eventsView.SelectedItem;
            if (selectedEvent != null)
            {
                appContext.TagsOfSelectedEvent = new ObservableCollection<Tag>(selectedEvent.Tags);
                appContext.SelectedEvent = selectedEvent;
            }

        }

        private void TagsTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tag selectedTag = (Tag)controlTagsView.tagsView.SelectedItem;
            if (selectedTag != null)
            {
                appContext.SelectedTag = selectedTag;
            }
        }

        private void EventTypesTagControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventType selectedEventType = (EventType)controlEventTypesView.eventTypesView.SelectedItem;
            if (selectedEventType != null)
            {
                appContext.SelectedEventType = selectedEventType;
                editEventControl.previewIcon.Source = new BitmapImage(new Uri(appContext.SelectedEventType.Icon, UriKind.RelativeOrAbsolute));

            }
        }

        private void undoBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Undo");
        }

        private void TabItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
    }

}
