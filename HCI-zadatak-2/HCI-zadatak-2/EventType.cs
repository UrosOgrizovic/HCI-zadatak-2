using System;
using System.ComponentModel;
using System.Windows.Media;

namespace HCI_zadatak_2
{
	public class EventType : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private string _type;
		private string _name;
		private byte[] _icon;
		private string _description;
		
		public string Type
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

		public byte[] Icon
		{
			get
			{
				return _icon;
			}
			set
			{
				if (value != _icon)
				{
					_icon = value;
					OnPropertyChanged("Icon");
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
	}
}