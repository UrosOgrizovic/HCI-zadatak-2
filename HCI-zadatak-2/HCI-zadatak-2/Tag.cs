using System;
using System.ComponentModel;
using System.Windows.Media;

namespace HCI_zadatak_2
{

    
	public class Tag : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public string _id;
		public Color _color;
		public string _description;
		public bool _isActive;
        public string _textColor;
	    

        public String TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                if (value != _textColor)
                {
                    _textColor = value;
                    OnPropertyChanged("TextColor");
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

		public Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				if (value != _color)
				{
					_color = value;
					OnPropertyChanged("Color");
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
		// if false, tag will not be displayed
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
	}
}