using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for CreateCampaign.xaml
    /// </summary>
    public partial class CreateCampaign : UserControl
    {
        private IAdSetService adSetService;
        private ICampaignService campaignService;
        public CreateCampaign()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049");

            adSetService = new AdSetServiceRest(httpClient);
            campaignService = new CampaignServiceRest(httpClient);

            InitializeComponent();
            itemListBox.SetValue(ItemsControl.ItemsSourceProperty, adSetService.GetAdSetsThatAreNotInCampaign());
        }

        private void CreateCampaignButton_Click(object sender, RoutedEventArgs e)
        {
            List<AdSet> adSets = new List<AdSet>();
            if (itemListBox.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one ad set!");
                return; // Exit the method without performing the update
            }
            foreach (AdSet adSet in itemListBox.SelectedItems)
            {
                adSets.Add(adSet);
            }

            Campaign campaign = new Campaign(nameTextBox.Text, startDatePicker.SelectedDate.Value, int.Parse(durationTextBox.Text), adSets);
            campaignService.AddCampaign(campaign);

            MessageBox.Show("Camapign created with " + adSets.Count + " ad sets", "Camapign Created", MessageBoxButton.OK, MessageBoxImage.Information);

            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the home page
            HomePage homePage = new HomePage();

            // Replace the current user control with the home page
            Window window = Window.GetWindow(this);
            if (window != null && window is LoginInfluencer mainWindow)
            {
                mainWindow.contentContainer.Content = mainWindow.HomePage;
            }
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AdAccountOverview adAccountOverview = new AdAccountOverview();
            this.Content = adAccountOverview;
        }
    }
}
