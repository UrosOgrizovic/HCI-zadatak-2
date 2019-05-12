using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_zadatak_2
{
    class Event
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public EventType Type { get; set; }
		public AlcoholServingCategory Alcohol { get; set; }
		public byte[] Icon { get; set; } 
		public bool IsForHandicapped { get; set; }
		public bool IsSmokingAllowed { get; set; }
		public bool IsOutdoors { get; set; }
		public PriceCategory PriceCategory { get; set; }
		public int ExpectedAudience { get; set; } // perhaps create enum for expected audience instead?
		public DateTime Date { get; set; }
		public List<Tag> Tags { get; set; }
		public bool IsActive { get; set; } // if false, event will not be displayed
		public int OffsetX { get; set; }
		public int OffsetY { get; set; }
	}
}