using HCI_zadatak_2.images;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Interaction logic for EditEvent.xaml
	/// </summary>
	public partial class EditEvent : UserControl
	{

		public static MainWindow Window { get; set; }
		public static AppImage icon = null;

		private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

		
		private bool nameEntered = true, descriptionEntered = true, expectedAudienceEntered = true, dateEntered = true;

		public EditEvent()
        {
			
			InitializeComponent();
			DataContext = this;

		}

		private static bool IsTextAllowed(string text)
		{
			return !_regex.IsMatch(text);
		}

		// Use the DataObject.Pasting Handler 
		private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
		{
			if (e.DataObject.GetDataPresent(typeof(string)))
			{
				string text = (string)e.DataObject.GetData(typeof(string));
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

		private void EditEventBtn_Click(object sender, RoutedEventArgs e)
		{
			if (!ValidateEditEvent())
			{
				MessageBox.Show("All fields must be filled");
			} else
			{
                Event ee = Window.appContext.SelectedEvent;
                ee.Name = EventNameTextBox.Text;
                ee.Description = EventDescriptionTextBox.Text;
                ee.Alcohol = (AlcoholServingCategory)Enum.Parse(typeof(AlcoholServingCategory), EventAlcoholServingCategory.SelectedValue.ToString(), true);
                ee.IsSmokingAllowed = EventIsSmokingAllowed.SelectedItem.ToString().Equals("True") ? true : false;
                ee.IsOutdoors = EventIsOutdoors.SelectedItem.ToString().Equals("True") ? true : false;
                ee.PriceCategory = (PriceCategory)Enum.Parse(typeof(PriceCategory), EventPriceCategory.SelectedValue.ToString(), true);
                ee.ExpectedAudience = Int32.Parse(EventExpectedAudienceTextBox.Text);
                ee.Date = (DateTime)EventDate.SelectedDate;
                if (iconPath != null)
                {
                    Window.canvas.Children.Remove(ee.ImageIcon);

                    ee.IconPath = iconPath;
                    AppImage icon = new AppImage
                    {
                        Width = 30,
                        Height = 30,
                        Name = "marker",
                        Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute)),
                        Path = iconPath
                    };
                    ee.ImageIcon = icon;
                    icon.Event = ee;

                    Window.canvas.Children.Add(ee.ImageIcon);
                    Canvas.SetTop(ee.ImageIcon, ee.OffsetY);
                    Canvas.SetLeft(ee.ImageIcon, ee.OffsetX);
                }
				FileIO.WriteToFile("appContext.bin", Window.appContext);
            }
		}

		private bool ValidateEditEvent()
		{
			if (!nameEntered || !descriptionEntered || !expectedAudienceEntered || !dateEntered)
				return false;
			else if (string.IsNullOrWhiteSpace(EventNameTextBox.Text) || string.IsNullOrWhiteSpace(EventDescriptionTextBox.Text) || string.IsNullOrWhiteSpace(EventExpectedAudienceTextBox.Text) || string.IsNullOrWhiteSpace(EventDate.Text))
				return false;
			return true;
		}

		private void RemoveTagBtn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddTagToTagsOfEventBtn_Click(object sender, RoutedEventArgs e)
		{
            
		}

		private void EventNameTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(EventNameTextBox.Text))
			{
				nameExclamIcon.Visibility = Visibility.Visible;
				nameEntered = false;
			} else
			{
				nameExclamIcon.Visibility = Visibility.Hidden;
				nameEntered = true;
			}
				
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
			} else
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
			} else
			{
				dateExclamIcon.Visibility = Visibility.Hidden;
				dateEntered = true;
			}
		}

		private void EventExpectedAudienceTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			e.Handled = _regex.IsMatch(e.Text);
		}


        string iconPath;

		private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
		{
			HelpProvider.ShowHelp("EditEvent");
		}


		private void BrowseBtn_Click_1(object sender, RoutedEventArgs e)
		{
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                iconPath = ofd.FileName;
				icon = new AppImage
				{
					Width = 30,
					Height = 30,
					Name = "marker",
					Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute)),
					Path = iconPath
				};
				previewIcon.Source = icon.Source;
			}


        }

		private void EventTypesView_MouseMove(object sender, MouseEventArgs e)
		{

		}

		private void EventTypesView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}

	}
}
