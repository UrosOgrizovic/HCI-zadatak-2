using HCI_zadatak_2.images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_zadatak_2
{
	[Serializable]
    public class Event : INotifyPropertyChanged
	{
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private string _id;
		private string _name;
		private string _description;
		private EventType _type;
		private AlcoholServingCategory _alcohol;
		private bool _isForHandicapped;
		private bool _isSmokingAllowed;
		private bool _isOutdoors;
		private PriceCategory _priceCategory;
		private int _expectedAudience;
		private DateTime _date;
		private List<Tag> _tags;
		private bool _isActive;
		private double _offsetX;
		private double _offsetY;
        private string _iconPath;
		[NonSerialized]
		private AppImage _image;

        public AppImage ImageIcon
        {
            get
            {
                return _image;
            }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged("ImageIcon");
                }
            }
        }


        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                if (value != _iconPath)
                {
                    _iconPath = value;
                    OnPropertyChanged("IconPath");
                }
            }
        }


		
		public string Id
		{
			get
			{
				return _id;
			}
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("Id");
				}
			}
		}
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (value != _name)
				{
					_name = value;
					OnPropertyChanged("Name");
				}
			}
		}
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				if (value != _description)
				{
					_description = value;
					OnPropertyChanged("Description");
				}
			}
		}
		public EventType Type
		{
			get
			{
				return _type;
			}
			set
			{
				if (value != _type)
				{
					_type = value;
					OnPropertyChanged("Type");
				}
			}
		}
		public AlcoholServingCategory Alcohol
		{
			get
			{
				return _alcohol;
			}
			set
			{
				if (value != _alcohol)
				{
					_alcohol = value;
					OnPropertyChanged("Alcohol");
				}
			}
		}

		public bool IsForHandicapped
		{
			get
			{
				return _isForHandicapped;
			}
			set
			{
				if (value != _isForHandicapped)
				{
					_isForHandicapped = value;
					OnPropertyChanged("IsForHandicapped");
				}
			}
		}
		public bool IsSmokingAllowed
		{
			get
			{
				return _isSmokingAllowed;
			}
			set
			{
				if (value != _isSmokingAllowed)
				{
					_isSmokingAllowed = value;
					OnPropertyChanged("IsSmokingAllowed");
				}
			}
		}
		public bool IsOutdoors
		{
			get
			{
				return _isOutdoors;
			}
			set
			{
				if (value != _isOutdoors)
				{
					_isOutdoors = value;
					OnPropertyChanged("IsOutdoors");
				}
			}
		}
		public PriceCategory PriceCategory
		{
			get
			{
				return _priceCategory;
			}
			set
			{
				if (value != _priceCategory)
				{
					_priceCategory = value;
					OnPropertyChanged("PriceCategory");
				}
			}
		}
		
		public int ExpectedAudience
		{
			get
			{
				return _expectedAudience;
			}
			set
			{
				if (value != _expectedAudience)
				{
					_expectedAudience = value;
					OnPropertyChanged("ExpectedAudience");
				}
			}
		}
		public DateTime Date
		{
			get
			{
				return _date;
			}
			set
			{
				if (value != _date)
				{
					_date = value;
					OnPropertyChanged("Date");
				}
			}
		}
		public List<Tag> Tags
		{
			get
			{
				return _tags;
			}
			set
			{
				if (value != _tags)
				{
					_tags = value;
					OnPropertyChanged("Tags");
				}
			}
		}
		// if false, event will not be displayed
		public bool IsActive
		{
			get
			{
				return _isActive;
			}
			set
			{
				if (value != _isActive)
				{
					_isActive = value;
					OnPropertyChanged("IsActive");
				}
			}
		}
		public double OffsetX
		{
			get
			{
				return _offsetX;
			}
			set
			{
				if (value != _offsetX)
				{
					_offsetX = value;
					OnPropertyChanged("OffsetX");
				}
			}
		}

		public double OffsetY
		{
			get
			{
				return _offsetY;
			}
			set
			{
				if (value != _offsetY)
				{
					_offsetY = value;
					OnPropertyChanged("OffsetY");
				}
			}
		}
	}
}