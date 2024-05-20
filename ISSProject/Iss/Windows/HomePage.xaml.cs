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
using System.Windows.Shapes;

using Iss.Service;

namespace Iss.Windows
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AccountOverviewButton_Click(object sender, EventArgs e)
        {
            AdAccountOverview accountOverview = new AdAccountOverview();
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = accountOverview;
            }
        }

        private void NegotiationHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAdAccount = true;
            ListOfRequests listOfRequests = new ListOfRequests(isAdAccount);
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = listOfRequests;
            }
        }

        private void EditAccountButton_Click(object sender, RoutedEventArgs e)
        {
            EditAdAccount editAdAccount = new EditAdAccount();
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = editAdAccount;
            }
        }
    }
}
