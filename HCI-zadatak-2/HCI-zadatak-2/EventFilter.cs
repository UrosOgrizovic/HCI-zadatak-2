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
        private string type { get; set; }

        private AlcoholServingCategory alcohol { get; set; }

        private bool isForHandicapped { get; set; }

        private bool isSmokingAllowed { get; set; }

        private bool isOutdoors { get; set; }

        private PriceCategory priceCategory { get; set; }

        private DateTime dateFrom { get; set; }

        private DateTime dateTo { get; set; }

        private int expectedAudianceLow { get; set; }

        private int expectedAudianceHigh { get; set; }

        private List<String> tags { get; set; }

    }
}
