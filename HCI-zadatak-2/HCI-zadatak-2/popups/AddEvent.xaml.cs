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
using System.Threading;
using System.ComponentModel;
using Microsoft.Win32;
using HCI_zadatak_2.images;

namespace HCI_zadatak_2.popups
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        MainWindow _parent;
        public MainWindow parent
        {
            get { return _parent; }
            set { _parent = value; OnPropertyChanged("parent"); }
        }

        public Event e { get; set; }

        public AddEvent(MainWindow parent, Event e)
        {
            InitializeComponent();
            DataContext = this;
            this.parent = parent;
            this.e = e;
        }

        private void CreateEventBtn_Click(object sender, RoutedEventArgs e)
        {
            this.e.Id = EventIdTextBox.Text;
            this.e.Name = EventNameTextBox.Text;
            this.e.Description = EventDescriptionTextBox.Text;
            this.e.Alcohol = (AlcoholServingCategory) Enum.Parse(typeof(AlcoholServingCategory), EventAlcoholServingCategory.SelectedValue.ToString(), true);
            this.e.IsSmokingAllowed = EventIsSmokingAllowed.SelectedItem.ToString().Equals("True") ? true : false;
            this.e.IsOutdoors = EventIsOutdoors.SelectedItem.ToString().Equals("True") ? true : false;
            this.e.PriceCategory = (PriceCategory) Enum.Parse(typeof(PriceCategory),EventPriceCategory.SelectedValue.ToString(), true);
            this.e.ExpectedAudience =  Int32.Parse(EventExpectedAudienceTextBox.Text);
            this.e.Date = (DateTime) EventDate.SelectedDate;
            if (this.e.IconPath == null)
                this.e.IconPath = this.e.Type.Icon;

			
			this.e.Tags = new List<Tag>();
			System.Collections.IList items = tagsView.SelectedItems;

			var tags = items.Cast<Tag>();
			foreach (var t in tags)
			{
				this.e.Tags.Add(t);
			}


			this.parent.appContext.Events.Add(this.e);

            AppImage icon = new AppImage
            {
                Width = 30,
                Height = 30,
                Name = "marker",
                Source = new BitmapImage(new Uri(this.e.IconPath, UriKind.Absolute))
            };
            icon.Event = this.e;

            this.parent.canvas.Children.Add(icon);
            Canvas.SetTop(icon, this.e.OffsetY);
            Canvas.SetLeft(icon, this.e.OffsetX);

            this.Close();
        }

        private void EventIconBrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                this.e.IconPath = ofd.FileName;
            }
        }

		public AddEvent()
		{
			InitializeComponent();
		}
    }
}
