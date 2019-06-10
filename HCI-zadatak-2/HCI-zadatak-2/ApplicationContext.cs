using HCI_zadatak_2.images;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Windows.Media.Color;

namespace HCI_zadatak_2
{
    public class ApplicationContext : INotifyPropertyChanged
    {
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<EventType> EventTypes { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }

        public ApplicationContext()
        {
            TestData();
        }

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string info)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
		}

		public ObservableCollection<Tag> _tagsOfSelectedEvent;

		public ObservableCollection<Tag> TagsOfSelectedEvent
		{
			get
			{
				return _tagsOfSelectedEvent;
			}
			set
			{
				_tagsOfSelectedEvent = value;
				OnPropertyChanged("TagsOfSelectedEvent");
			}
		}

		public Event _selectedEvent;

		public Event SelectedEvent
		{
			get
			{
				return _selectedEvent;
			}
			set
			{
				_selectedEvent = value;
				OnPropertyChanged("SelectedEvent");
			}
		}

		public Tag _selectedTag;
		public Tag SelectedTag
		{
			get
			{
				return _selectedTag;
			}
			set
			{
				_selectedTag = value;
				OnPropertyChanged("SelectedTag");
			}
		}

		public EventType _selectedEventType;
		public EventType SelectedEventType
		{
			get
			{
				return _selectedEventType;
			}
			set
			{
				_selectedEventType = value;
				OnPropertyChanged("SelectedEventType");
			}
		}

		public string _exclamPath = @"\images\exclam.png";
		public string ExclamPath
		{
			get
			{
				return _exclamPath;
			}
			set
			{
				_exclamPath = value;
				OnPropertyChanged("ExclamPath");
			}
		}

		public void TestData()
        {
            List<Event> e = new List<Event>();
            List<EventType> let = new List<EventType>();
            List<Tag> lt = new List<Tag>();

            let.Add(new EventType { Type = "Sports", Name = "Football game", Icon = @"\images\4.jpg", Description = "Event type that can be used for any football game." });
            let.Add(new EventType { Type = "Music", Name = "Concert", Icon = @"\images\5.jpg", Description = "Event type that can be used for any concert" });
            let.Add(new EventType { Type = "Art", Name = "Exhibition", Icon = @"\images\6.jpg", Description = "Event type that can be used for any art exhibition." });

            lt.Add(new Tag { Id = "T1", Description = "Involves physical activity", IsActive = true, Color = new Color() });
            lt.Add(new Tag { Id = "T2", Description = "Involves music", IsActive = true, Color = new Color() });
            lt.Add(new Tag { Id = "T3", Description = "Group discount", IsActive = true, Color = new Color() });

            DateTime dt1 = new DateTime(2019, 8, 10, 16, 30, 0);
            DateTime dt2 = new DateTime(2019, 10, 5, 20, 0, 0);
            DateTime dt3 = new DateTime(2019, 11, 11, 19, 0, 0);


			// added three AppImage instances and uncommented events so as to test help for ViewEvents
			AppImage ai1 = new AppImage
			{
				Event = null,
				Path = @"\images\1.jpg"
			};
			AppImage ai2 = new AppImage
			{
				Event = null,
				Path = @"\images\2.jpg"
			};
			AppImage ai3 = new AppImage
			{
				Event = null,
				Path = @"\images\3.jpg"
			};

			//e.Add(new Event { Id = "E1", ImageIcon = ai1, Name = "Crazy Aerosmith concert", Description = "A concert by the legends of rock. Steven Tyler is living proof that one can still rock out at the tender age of 71!", Type = let[1], Alcohol = AlcoholServingCategory.BUY, IsForHandicapped = true, IsSmokingAllowed = true, IsOutdoors = true, PriceCategory = PriceCategory.MID, ExpectedAudience = 10000, Date = dt2, Tags = lt.GetRange(1, 1), IsActive = true, OffsetX = 10, OffsetY = 10, IconPath= @"\images\1.jpg" });
            //e.Add(new Event { Id = "E2", ImageIcon = ai2, Name = "Football game U19", Description = "Everyone who's under the age of 19 is invited to this exhibition game! Great fun is guaranteed!", Type = let[0], Alcohol = AlcoholServingCategory.NONE, IsForHandicapped = false, IsSmokingAllowed = false, IsOutdoors = true, PriceCategory = PriceCategory.FREE, ExpectedAudience = 20, Date = dt1, Tags = lt.GetRange(0, 1), IsActive = true, OffsetX = 100, OffsetY = 200, IconPath = @"\images\2.jpg" });
            //e.Add(new Event { Id = "E3", ImageIcon = ai3, Name = "Picasso's Rose Period", Description = "A look at some of Picasso's pre-cubism works, such as 'Boy Leading a Horse'.", Type = let[2], Alcohol = AlcoholServingCategory.NONE, IsForHandicapped = true, IsSmokingAllowed = false, IsOutdoors = false, PriceCategory = PriceCategory.HIGH, ExpectedAudience = 200, Date = dt3, Tags = lt.GetRange(2, 1), IsActive = true, OffsetX = 250, OffsetY = 50, IconPath = @"\images\3.jpg" });

			//ai1.Event = e.ElementAt(0);
		    //ai2.Event = e.ElementAt(1);
			//ai3.Event = e.ElementAt(2);

			Events = new ObservableCollection<Event>(e);
            EventTypes = new ObservableCollection<EventType>(let);
            Tags = new ObservableCollection<Tag>(lt);
        }


        public ObservableCollection<Event> Search(String query)
        {
            double score = 0;

            List<Tag> tags = new List<Tag>();

            List<double> scores = new List<double>();
            List<Event> events = new List<Event>();
            query = query.ToLower();
            foreach (Event e in Events) {
                score = 0;
                if (e.Name.ToLower().Contains(query))
                    score += 10;
                if (e.Date.ToString().Contains(query))
                    score += 5;
                if (e.Type.Name.ToLower().Contains(query) || e.Type.Type.ToLower().Contains(query))
                    score += 7;
                tags = e.Tags;

                foreach (Tag t in tags)
                {
                    if (t.Id.ToLower().Contains(query))
                        score += 2;
                }

                scores.Add(score);
                events.Add(e);     
            }

            double maxscore = scores.Max();
            for(int i = 0; i < scores.Count; i++) {
                if (scores[i] == 0)
                    events[i].ImageIcon.Opacity = 0.3;
                else
                    events[i].ImageIcon.Opacity = scores[i] / maxscore;
            }
            SortEvents(scores, events);
            return new ObservableCollection<Event>(events);
        }

        private void SortEvents(List<double> scores, List<Event> events)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                for (int j = 0; j < scores.Count - 1; j++)
                {
                    if (scores.ElementAt(i) > scores.ElementAt(j))
                    {
                        var temp = scores[i];
                        scores[i] = scores[j];
                        scores[j] = temp;

                        var tempEvent = events[i];
                        events[i] = events[j];
                        events[j] = tempEvent;
                    }
                }
            }
        }

        public ObservableCollection<Event> Filter(ObservableCollection<Event> events)
        {
            return null;
        }

    }
}
