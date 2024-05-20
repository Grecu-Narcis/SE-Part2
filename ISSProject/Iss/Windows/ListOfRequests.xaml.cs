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
using System.Collections.Specialized;
using System.Collections;

using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for ListOfRequests.xaml
    /// </summary>
    public partial class ListOfRequests : UserControl
    {
        private RequestService requestService = new RequestService();
        private CollaborationService collaborationService = new CollaborationService();

        public List<Request> Requests { get; set; }
        private bool isAdAccount;
        public ListOfRequests(bool isAdAccount)
        {
            InitializeComponent();
            this.isAdAccount = isAdAccount;

            PopulateRequests();
        }

        private void PopulateRequests()
        {
            if (isAdAccount)
            {
                // Get requests for the current user
                Requests = requestService.GetRequestsForAdAccount();
            }
            else
            {
                // Get requests for the current user
                Requests = requestService.GetRequestsForInfluencer();
            }

            requestsListView.SetValue(ItemsControl.ItemsSourceProperty, Requests);
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {
                Request request = (Request)requestsListView.SelectedItem;
                Request selectedRequest = requestService.GetRequestWithTitle(request.CollaborationTitle);
                RequestDetails requestDetails = new RequestDetails(selectedRequest, isAdAccount);
                if (isAdAccount)
                {
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                    if (mainWindow != null)
                    {
                        mainWindow.contentContainer.Content = requestDetails;
                    }
                }
                else
                {
                    InfluencerStart influencerStart = Window.GetWindow(this) as InfluencerStart;
                    if (influencerStart != null)
                    {
                        influencerStart.contentContainer.Content = requestDetails;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a request!");
            }
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {
                try
                {
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.GetRequestWithTitle(request.CollaborationTitle);
                    selectedRequest.InfluencerAccept = true;
                    requestService.DeleteRequest(selectedRequest);

                    Collaboration collaboration = new Collaboration(request.CollaborationTitle, selectedRequest.AdOverview, selectedRequest.Compensation, selectedRequest.ContentRequirements, selectedRequest.StartDate, selectedRequest.EndDate, true);

                    collaborationService.AddCollaboration(collaboration);
                    MessageBox.Show("Request accepted. A new collaboration was created!");
                    this.Content = new ListOfRequests(this.isAdAccount);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to accept!");
            }
        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {
                try
                {
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.GetRequestWithTitle(request.CollaborationTitle);
                    selectedRequest.InfluencerAccept = false;
                    requestService.DeleteRequest(selectedRequest);
                    MessageBox.Show("Request declined. The request was deleted!");
                    this.Content = new ListOfRequests(this.isAdAccount);

                    // requestsListView.ItemsSource = null;
                    // requestsListView.ItemsSource = requests;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to decline!");
            }
        }

        private void NegociateButton_Click(object sender, RoutedEventArgs e)
        {
            if (requestsListView.SelectedItem != null)
            {
                try
                {
                    Request request = (Request)requestsListView.SelectedItem;
                    Request selectedRequest = requestService.GetRequestWithTitle(request.CollaborationTitle);

                    NegotiationPage negociationPage = new NegotiationPage(selectedRequest, isAdAccount);

                    if (isAdAccount)
                    {
                        negociationPage = new NegotiationPage(selectedRequest, true);
                        MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                        if (mainWindow != null)
                        {
                            mainWindow.contentContainer.Content = negociationPage;
                        }
                    }
                    else
                    {
                        InfluencerStart influencerStart = Window.GetWindow(this) as InfluencerStart;
                        if (influencerStart != null)
                        {
                            influencerStart.contentContainer.Content = negociationPage;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a request to negociate!");
            }
        }

        private void StartPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdAccount)
            {
                InfluencerStart start = new InfluencerStart();
                InfluencerStart influencerStart = Window.GetWindow(this) as InfluencerStart;
                if (influencerStart != null)
                {
                    influencerStart.contentContainer.Content = start.Content;
                }
            }
            else
            {
                HomePage start = new HomePage();
                Window window = Window.GetWindow(this);
                if (window != null && window is MainWindow mainWindow)
                {
                    mainWindow.contentContainer.Content = mainWindow.HomePage;
                }
            }
        }
    }
}
