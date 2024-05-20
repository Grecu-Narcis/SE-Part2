using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AdAccountOverview.xaml
    /// </summary>
    public partial class AdAccountOverview : UserControl
    {
        private IAdAccountService adAccountService;
        public List<Ad> Ads { get; set; }
        public List<AdSet> AdSets { get; set; }
        public List<Campaign> Campaigns { get; set; }

        public AdAccountOverview()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049/");
            adAccountService = new AdAccountServiceRest(httpClient);

            InitializeComponent();
            PopulateAccountDetails();
            PopulateAds();
            PopulateAdSets();
            PopulateCampaigns();
        }

        private void PopulateAds()
        {
            // Get ads for the current user
            Ads = adAccountService.GetAdsForCurrentUser();
            AdsBox.Items.Clear();
            foreach (var ad in Ads)
            {
                AdsBox.Items.Add(ad);
            }
        }

        private void PopulateAdSets()
        {
            AdSets = adAccountService.GetAdSetsForCurrentUser();
            AdSetss.Items.Clear();
            foreach (var adSet in AdSets)
            {
                AdSetss.Items.Add(adSet);
            }
        }

        private void PopulateCampaigns()
        {
            Campaigns = adAccountService.GetCampaignsForCurrentUser();
            CampaignsBox.Items.Clear();
            foreach (var campaign in Campaigns)
            {
                CampaignsBox.Items.Add(campaign);
            }
        }

        private void PopulateAccountDetails()
        {
            // Get the user's account details
            AdAccount userAccount = adAccountService.GetAccount();

            // Populate the text fields
            if (userAccount != null)
            {
                companyName.Text = userAccount.NameOfCompany;
                domainOfActivity.Text = userAccount.DomainOfActivity;
                CIF.Text = userAccount.TaxIdentificationNumber;
                URL.Text = userAccount.SiteUrl;
                address.Text = userAccount.HeadquartersLocation;
                legalInstitution.Text = userAccount.AuthorisingInstituion;
            }
        }

        private void AddAdSetButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the create ad set page
            CreateAdSet createAdSet = new CreateAdSet();
            // Replace the current user control with the create ad set page
            Window window = Window.GetWindow(this);
            if (window != null && window is LoginInfluencer mainWindow)
            {
                mainWindow.contentContainer.Content = createAdSet;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Replace the current user control with the home page
            Window window = Window.GetWindow(this);
            if (window != null && window is LoginInfluencer mainWindow)
            {
                mainWindow.contentContainer.Content = mainWindow.HomePage;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionsPage subscriptionPage = new SubscriptionsPage();
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = subscriptionPage;
            }
        }
        private void AddAd_Click(object sender, RoutedEventArgs e)
        {
            CreateAd createAd = new CreateAd();
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = createAd;
            }
        }

        private void SearchAd_Click(object sender, RoutedEventArgs e)
        {
            Ads = adAccountService.GetAdsForCurrentUser();
            // filter ads by the text box
            AdsBox.Items.Clear();
            foreach (var ad in Ads)
            {
                if (ad.ProductName.Contains(searchAdBox.Text))
                {
                    AdsBox.Items.Add(ad);
                }
            }
        }

        private void SearchAdSet_Click(object sender, RoutedEventArgs e)
        {
            AdSets = adAccountService.GetAdSetsForCurrentUser();
            // filter ad sets by the text box
            AdSetss.Items.Clear();
            foreach (var adSet in AdSets)
            {
                if (adSet.Name.Contains(searchAdSetBox.Text))
                {
                    AdSetss.Items.Add(adSet);
                }
            }
        }

        private void SearchCampaign_Click(object sender, RoutedEventArgs e)
        {
            Campaigns = adAccountService.GetCampaignsForCurrentUser();
            CampaignsBox.Items.Clear();
            foreach (var campaign in Campaigns)
            {
                if (campaign.CampaignName.Contains(searchCampaignBox.Text))
                {
                    CampaignsBox.Items.Add(campaign);
                }
            }
        }

        private void AddCampaign_Click(object sender, RoutedEventArgs e)
        {
            CreateCampaign createCampaign = new CreateCampaign();
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = createCampaign;
            }
        }

        private void Ads_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if an item is selected
            if (AdsBox.SelectedItem != null)
            {
                // Assuming you have a function to navigate to the new screen,
                // pass the selected ad to it
                LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = new AdDetails((Ad)AdsBox.SelectedItem);
                }
            }
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
             SelectInflucencerAndAd selectInflucencerAndAd = new SelectInflucencerAndAd();
             LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
             if (mainWindow != null)
             {
                 mainWindow.contentContainer.Content = selectInflucencerAndAd;
             }
        }

        private void AdSets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if an item is selected
            if (AdSetss.SelectedItem != null)
            {
                // Assuming you have a function to navigate to the new screen
                // pass the selected ad to it
                LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = new AdSetDetails((AdSet)AdSetss.SelectedItem);
                }
            }
        }

        private void Campaign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = new CampaignDetails((Campaign)CampaignsBox.SelectedItem);
            }
        }

        private void SeeActiveCollaborationsButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAdAccount = true;
            CollaborationPage activeCollaborations = new CollaborationPage(isAdAccount);
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = activeCollaborations;
            }
        }
    }
}
