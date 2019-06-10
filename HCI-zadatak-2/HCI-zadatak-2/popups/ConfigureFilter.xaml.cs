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
            DataContext = this;
            this.filter = filter;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(typeBox.Text))
            {
                filter.useType = true;
                filter.type = typeBox.Text;
            }
			if (!string.IsNullOrWhiteSpace(tagName.Text))
			{
				filter.useTag = true;
				filter.tag = tagName.Text;
			}
			if (!string.IsNullOrWhiteSpace(lowAudiance.Text))
			{
				filter.useAudiLow = true;
				filter.expectedAudianceLow = System.Convert.ToInt32(lowAudiance.Text);
			}
			if (!string.IsNullOrWhiteSpace(highAudiance.Text))
			{
				filter.useAudiHigh = true;
				filter.expectedAudianceHigh = System.Convert.ToInt32(highAudiance.Text);
			}
			if (!alcoholComboBox.SelectedValue.ToString().Equals("None"))
			{
				filter.alcohol = (AlcoholServingCategory)Enum.Parse(typeof(AlcoholServingCategory), alcoholComboBox.SelectedValue.ToString(), true);
				filter.useAlcohol = true;
			}
			if (!priceCategoryComboBox.SelectedValue.ToString().Equals("None"))
			{
				filter.priceCategory = (PriceCategory)Enum.Parse(typeof(PriceCategory), priceCategoryComboBox.SelectedValue.ToString(), true);
				filter.usePriceCat = true;
			}

		
            if (fromDate.SelectedDate != null)
			{
				filter.dateFrom = (DateTime)fromDate.SelectedDate;
				filter.useDateFrom = true;
			}	

            if (toDate.SelectedDate != null)
			{
				filter.dateTo = (DateTime)toDate.SelectedDate;
				filter.useDateTo = true;
			}
                
			
            this.Close();
        }

        private void HelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelp("SearchFilterReset");
        }
    }
}
