using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;


namespace HCI_zadatak_2
{
	public static class FileIO
	{
		private const string PATH = "../../Data/Entities";
		public static void WriteToFile(string fileName, object items)
		{
			using (Stream stream = File.Open(PATH + "/" + fileName, FileMode.Create))
			{
				var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				bformatter.Serialize(stream, items);
			}
		}

		public static object ReadAppContext(string fName)
		{
			if (File.Exists(PATH + "/" + fName))
			{
				using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
				{
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

					return bformatter.Deserialize(stream);
				}
			}
			return new ApplicationContext();
		}

		public static object ReadEvents(string fileName)
		{
			if (File.Exists(PATH + "/" + fileName))
			{
				using (Stream stream = File.Open(PATH + "/" + fileName, FileMode.Open))
				{
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

					return bformatter.Deserialize(stream);
				}
			}
			return new ObservableCollection<Event>();
		}

		public static object ReadImage(string fileName)
		{
			if (File.Exists(PATH + "/" + fileName))
			{
				return new WriteableBitmap(new BitmapImage(new Uri(PATH + "/" + fileName, UriKind.RelativeOrAbsolute)));
			}
			return null;
		}

		public static object ReadTags(string fName)
		{
			if (File.Exists(PATH + "/" + fName))
			{
				using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
				{
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

					return bformatter.Deserialize(stream);
				}
			}
			return new ObservableCollection<Tag>();
		}

		public static object ReadEventTypes(string fName)
		{
			if (File.Exists(PATH + "/" + fName))
			{
				using (Stream stream = File.Open(PATH + "/" + fName, FileMode.Open))
				{
					var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

					return bformatter.Deserialize(stream);
				}
			}
			return new ObservableCollection<EventType>();
		}

	}
}
