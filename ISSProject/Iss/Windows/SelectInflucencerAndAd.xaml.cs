using Iss.Entity;
using Iss.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for SelectInflucencerAndAd.xaml
    /// </summary>
    public partial class SelectInflucencerAndAd : UserControl
    {
        AdAccountService AdAccountService = new AdAccountService();
        InfluencerService InfluencerService = new InfluencerService();
        public SelectInflucencerAndAd()
        {
            InitializeComponent();
            PopulateInfluencers();
            PopulateAds();
        }

        private void PopulateInfluencers()
        {
            List<Influencer> currentInfluencers = InfluencerService.GetInfluencers();
            influencerListBox.Items.Clear();
            foreach (var influencer in currentInfluencers)
            {
                influencerListBox.Items.Add(influencer);
            }
        }

        private void PopulateAds()
        {
            List<Ad> currentAds = AdAccountService.getAdsForCurrentUser();
            adListBox.Items.Clear();
            foreach (var ad in currentAds)
            {
                adListBox.Items.Add(ad);
            }
        }

        private void searchInfluencerButton_Click(object sender, RoutedEventArgs e)
        {
            List<Influencer> currentInfluencers = InfluencerService.GetInfluencers();
            influencerListBox.Items.Clear();
            foreach (Influencer influencer in currentInfluencers)
            {
                if (influencer.influencerName.Contains(searchInfluencerBox.Text))
                {
                    influencerListBox.Items.Add(influencer);
                }
            }
        }

        private void searchAdTextButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ad> currentAds = AdAccountService.getAdsForCurrentUser();
            adListBox.Items.Clear();
            foreach (Ad ad in currentAds)
            {
                if (ad.ProductName.Contains(searchAdTextBox.Text))
                {
                    adListBox.Items.Add(ad);
                }
            }
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            Ad selectedAd = (Ad)adListBox.SelectedItem;
            Influencer selectedInfluencer = (Influencer)influencerListBox.SelectedItem;

            MakeRequest makeRequest = new MakeRequest(selectedInfluencer, selectedAd);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = makeRequest;
            }
        }
    }
}
