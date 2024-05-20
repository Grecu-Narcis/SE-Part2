using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for CampaignDetails.xaml
    /// </summary>
    public partial class CampaignDetails : UserControl
    {
        private Campaign campaign;
        private ICampaignService campaignService;
        private IAdSetService adSetService;
        private List<AdSet> currentAdSets = new List<AdSet>();
        private List<AdSet> availableAdSets = new List<AdSet>();

        public CampaignDetails(Campaign campaign)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049");

            campaignService = new CampaignServiceRest(httpClient);
            adSetService = new AdSetServiceRest(httpClient);

            InitializeComponent();
            this.campaign = campaignService.GetCampaignByName(campaign);
            this.Populate();
        }

        public void Populate()
        {
            nameTextBox.Text = campaign.CampaignName;
            durationTextBox.Text = campaign.Duration.ToString();
            startDatePicker.SelectedDate = campaign.StartDate;
            availableAdSets = adSetService.GetAdSetsThatAreNotInCampaign();
            currentAdSets = adSetService.GetAdSetsInCampaign(campaign.CampaignId);
            itemListBox2.SetValue(ItemsControl.ItemsSourceProperty, availableAdSets);
            itemListBox1.SetValue(ItemsControl.ItemsSourceProperty, currentAdSets);
        }

        public void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.campaignService.DeleteCampaign(campaign);
                MessageBox.Show("Campaign deleted succesfully");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} \n\n {ex.InnerException}");
            }
        }

        public void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(durationTextBox.Text))
            {
                MessageBox.Show("Target audience and name must not be empty!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the first list!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at most 10 ad sets!");
                return; // Exit the method without performing the update
            }
            if (startDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a start date!");
                return; // Exit the method without performing the update
            }

            try
            {
                Campaign newCampaign = new Campaign(campaign.CampaignId, nameTextBox.Text, startDatePicker.SelectedDate.Value, int.Parse(durationTextBox.Text));
                campaignService.UpdateCampaign(newCampaign);
                foreach (AdSet adset in itemListBox1.Items)
                {
                    this.campaignService.AddAdSetToCampaign(newCampaign, adset);
                }
                foreach (AdSet adset in itemListBox2.Items)
                {
                    this.campaignService.DeleteAdSetFromCampaign(newCampaign, adset);
                }

                MessageBox.Show("Campaign updated");

                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox1.SelectedItem != null)
            {
                // Get the selected item
                int selectedIndex = itemListBox1.SelectedIndex;
                if (selectedIndex != -1)
                {
                    currentAdSets.RemoveAt(selectedIndex);
                }
                AdSet selectedAdSet = (AdSet)itemListBox1.SelectedItem;

                // Remove the selected item from list2
                // Add the selected item to list1
                availableAdSets.Add(selectedAdSet);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = currentAdSets;
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = availableAdSets;
            }
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox2.SelectedItem != null)
            {
                // Get the selected item
                AdSet selectedAdSet = (AdSet)itemListBox2.SelectedItem;

                // Remove the selected item from list1
                int selectedIndex = itemListBox2.SelectedIndex;
                if (selectedIndex != -1)
                {
                    availableAdSets.RemoveAt(selectedIndex);
                }

                // Add the selected item to list2
                currentAdSets.Add(selectedAdSet);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = availableAdSets;
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = currentAdSets;
            }
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
