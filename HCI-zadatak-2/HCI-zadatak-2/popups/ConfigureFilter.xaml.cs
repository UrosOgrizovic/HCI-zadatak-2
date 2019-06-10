using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_zadatak_2.popups
{
    /// <summary>
    /// Interaction logic for ConfigureFilter.xaml
    /// </summary>
    public partial class ConfigureFilter : Window
    {
        private EventFilter filter;

        public ConfigureFilter(EventFilter filter)
        {
            InitializeComponent();
            this.filter = filter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(typeBox.Text))
            {
                filter.useType = true;
                filter.type = typeBox.Text;
            }

            filter.alcohol = (AlcoholServingCategory)Enum.Parse(typeof(AlcoholServingCategory), alcoholComboBox.SelectedValue.ToString(), true);
            filter.isForHandicapped = (bool)handicaped.IsChecked;
            filter.isSmokingAllowed = (bool)smoking.IsChecked;
            filter.isOutdoors = (bool)outdoors.IsChecked;
            filter.priceCategory = (PriceCategory)Enum.Parse(typeof(PriceCategory), priceCategoryComboBox.SelectedValue.ToString(), true);

            if (fromDate.SelectedDate != null)
                filter.dateFrom = (DateTime)fromDate.SelectedDate;

            if (fromDate.SelectedDate != null)
                filter.dateTo = (DateTime)toDate.SelectedDate;

            var x = lowAudiance.Text.Trim();
            if (!string.IsNullOrEmpty(x))
                filter.expectedAudianceLow = Int32.Parse(x);

            x = highAudiance.Text.Trim();
            if (!string.IsNullOrEmpty(x))
                filter.expectedAudianceHigh = Int32.Parse(x);

            filter.tag = tagName.Text;
            this.Close();
        }
    }
}
