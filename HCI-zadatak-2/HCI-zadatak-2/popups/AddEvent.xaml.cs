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
using System.Text.RegularExpressions;

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

		private bool idEntered = false, nameEntered = false, descriptionEntered = false, expectedAudienceEntered = false, dateEntered = false;

		private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

		public AddEvent(MainWindow parent, Event e)
        {
            InitializeComponent();
            DataContext = this;
            this.parent = parent;
            this.e = e;
        }

		private static bool IsTextAllowed(string text)
		{
			return !_regex.IsMatch(text);
		}

		// Use the DataObject.Pasting Handler 
		private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(typeof(String)))
			{
				String text = (String)e.DataObject.GetData(typeof(String));
				if (!IsTextAllowed(text))
				{
					e.CancelCommand();
				}
			}
			else
			{
				e.CancelCommand();
			}
		}
		
		private void CreateEventBtn_Click(object sender, RoutedEventArgs e)
        {
			if (!ValidateAddEvent())
			{
				MessageBox.Show("All fields must be filled");
			}
			else
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
					Source = new BitmapImage(new Uri(this.e.IconPath, UriKind.RelativeOrAbsolute))
				};
				icon.Event = this.e;
                this.e.ImageIcon = icon;

				this.parent.canvas.Children.Add(icon);
				Canvas.SetTop(icon, this.e.OffsetY);
				Canvas.SetLeft(icon, this.e.OffsetX);

				this.Close();

				MessageBox.Show("Event created successfully");
			}
		}

		private bool ValidateAddEvent()
		{
			if (!idEntered || !nameEntered || !descriptionEntered || !expectedAudienceEntered || !dateEntered)
				return false;
			else if (string.IsNullOrWhiteSpace(EventIdTextBox.Text) || string.IsNullOrWhiteSpace(EventNameTextBox.Text) || string.IsNullOrWhiteSpace(EventDescriptionTextBox.Text) || string.IsNullOrWhiteSpace(EventExpectedAudienceTextBox.Text) || string.IsNullOrWhiteSpace(EventDate.Text))
				return false;
			return true;
		}

		private void EventDescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventDescriptionTextBox.Text))
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

		private void EventExpectedAudienceTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventExpectedAudienceTextBox.Text))
			{
				expectedAudienceExclamIcon.Visibility = Visibility.Visible;
				expectedAudienceEntered = false;
			}
			else
			{
				expectedAudienceExclamIcon.Visibility = Visibility.Hidden;
				expectedAudienceEntered = true;
			}
		}

		private void EventDate_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventDate.Text) && !EventDate.IsDropDownOpen)
			{
				dateExclamIcon.Visibility = Visibility.Visible;
				dateEntered = false;
			}
			else
			{
				dateExclamIcon.Visibility = Visibility.Hidden;
				dateEntered = true;
			}
		}

		private void EventExpectedAudienceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _regex.IsMatch(e.Text);
		}

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("AddEvent");
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

		private void EventIdTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventIdTextBox.Text))
			{
				idExclamIcon.Visibility = Visibility.Visible;
				idEntered = false;
			}
			else
			{
				idExclamIcon.Visibility = Visibility.Hidden;
				idEntered = true;
			}
		}


		private void EventNameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventNameTextBox.Text))
			{
				nameExclamIcon.Visibility = Visibility.Visible;
				nameEntered = false;
			}
			else
			{
				nameExclamIcon.Visibility = Visibility.Hidden;
				nameEntered = true;
			}
		}


	}
}
