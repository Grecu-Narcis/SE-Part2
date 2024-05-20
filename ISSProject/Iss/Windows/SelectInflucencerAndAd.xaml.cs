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

using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for SelectInflucencerAndAd.xaml
    /// </summary>
    public partial class SelectInflucencerAndAd : UserControl
    {
        public AdAccountService AdAccountService = new AdAccountService();
        public InfluencerService InfluencerService = new InfluencerService();
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
            List<Ad> currentAds = AdAccountService.GetAdsForCurrentUser();
            adListBox.Items.Clear();
            foreach (var ad in currentAds)
            {
                adListBox.Items.Add(ad);
            }
        }

        private void SearchInfluencerButton_Click(object sender, RoutedEventArgs e)
        {
            List<Influencer> currentInfluencers = InfluencerService.GetInfluencers();
            influencerListBox.Items.Clear();
            foreach (Influencer influencer in currentInfluencers)
            {
                if (influencer.InfluencerName.Contains(searchInfluencerBox.Text))
                {
                    influencerListBox.Items.Add(influencer);
                }
            }
        }

        private void SearchAdTextButton_Click(object sender, RoutedEventArgs e)
        {
            List<Ad> currentAds = AdAccountService.GetAdsForCurrentUser();
            adListBox.Items.Clear();
            foreach (Ad ad in currentAds)
            {
                if (ad.ProductName.Contains(searchAdTextBox.Text))
                {
                    adListBox.Items.Add(ad);
                }
            }
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            Ad selectedAd = (Ad)adListBox.SelectedItem;
            Influencer selectedInfluencer = (Influencer)influencerListBox.SelectedItem;

            MakeRequest makeRequest = new MakeRequest(selectedInfluencer, selectedAd);
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = makeRequest;
            }
        }
    }
}
