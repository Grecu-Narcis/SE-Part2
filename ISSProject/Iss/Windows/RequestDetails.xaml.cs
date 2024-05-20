﻿using System;
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

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for RequestDetails.xaml
    /// </summary>
    public partial class RequestDetails : UserControl
    {
        private bool isAdAccount;
        public RequestDetails(Request request, bool isAdAccount)
        {
            InitializeComponent();
            this.isAdAccount = isAdAccount;
            PopulateFields(request);
        }

        private void PopulateFields(Request request)
        {
            // Populate fields with request details
            this.collaborationTitleTextBlock.Text = request.CollaborationTitle;
            this.adOverviewTextBlock.Text = request.AdOverview;
            this.contentRequirementsTextBlock.Text = request.ContentRequirements;
            this.compensationTextBlock.Text = request.Compensation;
            this.startDateTextBlock.Text = request.StartDate.ToString("dd/MM/yyyy");
            this.endDateTextBlock.Text = request.EndDate.ToString("dd/MM/yyyy");
        }

        private void ListOfRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdAccount)
            {
                ListOfRequests listOfRequests = new ListOfRequests(isAdAccount);
                InfluencerStart influencerStart = Window.GetWindow(this) as InfluencerStart;
                if (influencerStart != null)
                {
                    influencerStart.contentContainer.Content = listOfRequests;
                }
            }
            else
            {
                ListOfRequests listOfRequests = new ListOfRequests(isAdAccount);
                MainWindow window = Window.GetWindow(this) as MainWindow;
                if (window != null && window is MainWindow mainWindow)
                {
                    mainWindow.contentContainer.Content = listOfRequests;
                }
            }
        }
    }
}