using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCI_zadatak_2
{
    public class EventFilter
    {
        public string type { get; set; }
        public bool useType { get; set; }

        public AlcoholServingCategory alcohol { get; set; }
        public bool useAlcohol { get; set; }

        public bool isForHandicapped { get; set; }
        public bool useHandi { get; set; }

        public bool isSmokingAllowed { get; set; }
        public bool useSmoke { get; set; }

        public bool isOutdoors { get; set; }
        public bool useOut { get; set; }

        public PriceCategory priceCategory { get; set; }
        public bool usePriceCat { get; set; }

        public DateTime dateFrom { get; set; }
        public bool useDateFrom { get; set; }

        public DateTime dateTo { get; set; }
        public bool useDateTo { get; set; }

        public int expectedAudianceLow { get; set; }
        public bool useAudiLow { get; set; }

        public int expectedAudianceHigh { get; set; }
        public bool useAudiHigh { get; set; }

        public String tag { get; set; }
        public bool useTag { get; set; }

        public EventFilter()
        {
            useAlcohol = false;
            useType = false;
            useTag = false;
            useAudiHigh = false;
            useAudiLow = false;
            useDateTo = false;
            useDateFrom = false;
            useOut = false;
            useSmoke = false;
            useHandi = false;
            usePriceCat = false;
        }

    }
}
