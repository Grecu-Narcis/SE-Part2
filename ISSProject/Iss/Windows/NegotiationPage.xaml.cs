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

using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for NegotiationPage.xaml
    /// </summary>
    public partial class NegotiationPage : UserControl
    {
        private Request request;
        private bool isAddAccount;
        private RequestService requestService = new RequestService();
        public NegotiationPage(Request request, bool isAddAccount)
        {
            this.request = request;
            this.isAddAccount = isAddAccount;
            InitializeComponent();
            PopulateFields();
        }

        public void PopulateFields()
        {
            collaborationTitleTextBox.Text = request.CollaborationTitle;
            compensationTextBox.Text = request.Compensation;
            adOverviewTextBox.Text = request.AdOverview;
            newRequirementsTextBox.Text = request.ContentRequirements;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // go back to the request page
            ListOfRequests listOfRequests = new ListOfRequests(isAddAccount);
            this.Content = listOfRequests;
        }

        private void SendNegotiationButton_Click(object sender, RoutedEventArgs e)
        {
            // update the request with the new negotiation
            string newCompensation = newPriceTextBox.Text;
            string newContentRequirements = newRequirementsTextBox.Text;
            if (isAddAccount)
            {
                request.AdAccountAccept = true;
                request.InfluencerAccept = false;
            }
            else
            {
                request.AdAccountAccept = false;
                request.InfluencerAccept = true;
            }
            requestService.UpdateRequest(request, newCompensation, newContentRequirements);
            MessageBox.Show("Negotiation sent!");
            // go back to the request page
            ListOfRequests listOfRequests = new ListOfRequests(isAddAccount);
            this.Content = listOfRequests;
        }
    }
}
