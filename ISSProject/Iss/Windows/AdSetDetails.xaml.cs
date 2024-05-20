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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for AdSetDetails.xaml
    /// </summary>
    public partial class AdSetDetails : UserControl
    {
        private IAdService adService;
        private IAdSetService adSetService;
        private AdSet adSet;
        private string id;
        private List<Ad> list1 = new List<Ad>();
        private List<Ad> list2 = new List<Ad>();

        public AdSetDetails(AdSet adSet)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049/");

            adService = new AdServiceRest(httpClient);
            adSetService = new AdSetServiceRest(httpClient);

            InitializeComponent();

            this.adSet = adSet;
            nameTextBox.Text = adSet.Name;
            selectionComboBox.Text = adSet.TargetAudience;

            list2 = adService.GetAdsThatAreNotInAdSet();
            itemListBox2.SetValue(ItemsControl.ItemsSourceProperty, list2);
            PopulateCurrentAds();
        }

        public void PopulateCurrentAds()
        {
            id = adSetService.GetAdSetByName(adSet).AdSetId;
            adSet.AdSetId = id;
            list1 = adService.GetAdsFromAdSet(id);
            itemListBox1.SetValue(ItemsControl.ItemsSourceProperty, list1);
        }

        public void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string targetAudience = selectionComboBox.Text;

            // Get the name from the TextBox
            string name = nameTextBox.Text;

            if (string.IsNullOrEmpty(targetAudience) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Target audience and name must not be empty!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count == 0)
            {
                MessageBox.Show("Please select at least one item from the first list!");
                return; // Exit the method without performing the update
            }

            if (itemListBox1.Items.Count > 5)
            {
                MessageBox.Show("You can select a maximum of 5 ads");
                return; // Exit the method without performing the update
            }

                try
                {
                AdSet newAdSet = new AdSet(adSet.AdSetId, name, targetAudience);
                adSetService.UpdateAdSet(newAdSet);
                foreach (Ad ad in itemListBox1.Items)
                {
                    this.adSetService.AddAdToAdSet(adSet, ad);
                }

                foreach (Ad ad in itemListBox2.Items)
                {
                    this.adSetService.RemoveAdFromAdSet(adSet, ad);
                }
                MessageBox.Show("Ad Set updated successfully!");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.InnerException);
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
                    list1.RemoveAt(selectedIndex);
                }
                Ad selectedAd = (Ad)itemListBox1.SelectedItem;

                // Remove the selected item from list2

                // Add the selected item to list1
                list2.Add(selectedAd);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = list1;
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = list2;
            }
        }

        private void ListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemListBox2.SelectedItem != null)
            {
                // Get the selected item
                Ad selectedAd = (Ad)itemListBox2.SelectedItem;

                // Remove the selected item from list1
                int selectedIndex = itemListBox2.SelectedIndex;
                if (selectedIndex != -1)
                {
                    list2.RemoveAt(selectedIndex);
                }

                // Add the selected item to list2
                list1.Add(selectedAd);

                // Update the ItemsSource to refresh the ListBox display
                itemListBox2.ItemsSource = null;
                itemListBox2.ItemsSource = list2;
                itemListBox1.ItemsSource = null;
                itemListBox1.ItemsSource = list1;
            }
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.adSetService.DeleteAdSet(adSet);
                MessageBox.Show("Ad Set deleted succesfully");
                AdAccountOverview adAccountOverview = new AdAccountOverview();
                this.Content = adAccountOverview;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
