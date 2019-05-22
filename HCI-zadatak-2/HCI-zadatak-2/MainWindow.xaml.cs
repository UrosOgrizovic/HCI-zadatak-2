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



namespace HCI_zadatak_2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

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

		public ObservableCollection<Event> Events { get; set; }
		public ObservableCollection<EventType> EventTypes { get; set; }
		public ObservableCollection<Tag> Tags { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			cityMap.Source = new BitmapImage(new Uri("/images/MapNS.png", UriKind.Relative));
			DataContext = this;
			List<Event> e = new List<Event>();
			List<EventType> let = new List<EventType>();
			List<Tag> lt = new List<Tag>();

			let.Add(new EventType { Type = "Sports", Name = "Football game", Icon = null, Description = "Event type that can be used for any football game." });
			let.Add(new EventType { Type = "Music", Name = "Concert", Icon = null, Description = "Event type that can be used for any concert" });
			let.Add(new EventType { Type = "Art", Name = "Exhibition", Icon = null, Description = "Event type that can be used for any art exhibition." });

			lt.Add(new Tag { Id = "T1", Color = "Red", Description = "Involves physical activity", IsActive = true });
			lt.Add(new Tag { Id = "T2", Color = "Blue", Description = "Involves music", IsActive = true });
			lt.Add(new Tag { Id = "T3", Color = "Green", Description = "Group discount", IsActive = true });

			DateTime dt1 = new DateTime(2019, 8, 10, 16, 30, 0);
			DateTime dt2 = new DateTime(2019, 10, 5, 20, 0, 0);
			DateTime dt3 = new DateTime(2019, 11, 11, 19, 0, 0);

			e.Add(new Event {Id = "E1", Name = "Crazy Aerosmith concert", Description = "A concert by the legends of rock. Steven Tyler is living proof that one can still rock out at the tender age of 71!", Type = let[1], Alcohol = AlcoholServingCategory.BUY, Icon = null, IsForHandicapped = false, IsSmokingAllowed = true, IsOutdoors = true, PriceCategory = PriceCategory.MID, ExpectedAudience = 10000, Date = dt2, Tags = lt.GetRange(1, 1), IsActive = true, OffsetX = 200, OffsetY = 150 });

			e.Add(new Event {Id = "E2",  Name = "Football game U19", Description = "Everyone who's under the age of 19 is invited to this exhibition game! Great fun is guaranteed!", Type = let[0], Alcohol = AlcoholServingCategory.NONE, Icon = null, IsForHandicapped = false, IsSmokingAllowed = false, IsOutdoors = true, PriceCategory = PriceCategory.FREE, ExpectedAudience = 20, Date = dt1, Tags = lt.GetRange(0,1), IsActive = true, OffsetX = 100, OffsetY = 200 });

			e.Add(new Event {Id = "E3", Name = "Picasso's Rose Period", Icon = null, Description = "A look at some of Picasso's pre-cubism works, such as 'Boy Leading a Horse'.",  Type = let[2], Alcohol = AlcoholServingCategory.NONE, IsForHandicapped = true, IsSmokingAllowed = false, IsOutdoors = false, PriceCategory = PriceCategory.HIGH, ExpectedAudience = 200, Date = dt3, Tags = lt.GetRange(2,1), IsActive = true, OffsetX = 250, OffsetY = 50});

			Events = new ObservableCollection<Event>(e);
			EventTypes = new ObservableCollection<EventType>(let);
			Tags = new ObservableCollection<Tag>(lt);



			View = CollectionViewSource.GetDefaultView(Events);

		}

	}
}
