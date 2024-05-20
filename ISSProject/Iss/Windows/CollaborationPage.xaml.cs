using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CollaborationPage.xaml
    /// </summary>
    public partial class CollaborationPage : UserControl
    {
        private bool isAdAccount;
        private ICollaborationService collaborationService = new CollaborationService();
        private List<Collaboration> collaborations = new ();
        public CollaborationPage(bool isAdAccount)
        {
            InitializeComponent();
            this.isAdAccount = isAdAccount;
            if (this.isAdAccount)
            {
                PopulateListViewAdAccount();
            }
            else
            {
                PopulateListView();
                this.seeStatistics.Visibility = Visibility.Hidden;
            }
        }

        public void PopulateListViewAdAccount()
        {
            collaborations = collaborationService.GetActiveCollaborationForAdAccount();

            foreach (Collaboration collaboration in collaborations)
            {
                ListViewItem item = new ListViewItem();
                item.Content = collaboration;
                requestListView.Items.Add(item);
            }
        }

        public void PopulateListView()
        {
            collaborations = collaborationService.GetCollaborationForInfluencer();

            foreach (Collaboration collaboration in collaborations)
            {
                ListViewItem item = new ListViewItem();
                item.Content = collaboration;
                requestListView.Items.Add(item);
            }
        }

        public void RedirectToHome_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.isAdAccount)
            {
                HomePage homePage = new HomePage();
                LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = homePage;
                }
            }
            else
            {
                InfluencerStart influencerStart = new InfluencerStart();
                InfluencerStart mainWindow = Window.GetWindow(this) as InfluencerStart;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = influencerStart.Content;
                }
            }
        }

        private void SeeStatistics_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.isAdAccount)
            {
                Statistics statistics = new Statistics();
                LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
                if (mainWindow != null)
                {
                    mainWindow.contentContainer.Content = statistics;
                }
            }
        }
    }
}