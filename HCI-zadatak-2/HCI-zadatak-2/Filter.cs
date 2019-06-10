using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCI_zadatak_2
{
    
    class Filter
    {
        private Color color { get; set; }
        private DateTime endDate { get; set; }
        private DateTime startDate { get; set; }
        private String eventType { get; set; }
        private AlcoholServingCategory alcohol { get; set; }
        private bool isForHandicapped { get; set; }
        private bool isSmokingAllowed { get; set; }
        private bool isOutdoors { get; set; }
        private PriceCategory priceCategory { get; set; }
        private int lowExpectedAudience { get; set; }
        private int highExpectedAudience { get; set; }

        public Filter()
        {

        }



    }
}
