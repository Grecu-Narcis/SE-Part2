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
    /// Interaction logic for SubscriptionsPage.xaml
    /// </summary>
    public partial class SubscriptionsPage : UserControl
    {
        private IPaymentService paymentService = new PaymentService();
        public SubscriptionsPage()
        {
            InitializeComponent();
        }

        private void OneAdButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddOneAd();
            int totalAmountToPay = 5;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void OneAdSetButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddOneAdSet();
            int totalAmountToPay = 20;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void OneCampaignButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddOneCampaign();
            int totalAmountToPay = 150;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void BasicSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddBasicSubscription();
            int totalAmountToPay = 250;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void SilverSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddSilverSubscription();
            int totalAmountToPay = 350;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }

        private void GoldSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            paymentService.AddGoldSubscription();
            int totalAmountToPay = 500;
            Payment paymentPage = new Payment(totalAmountToPay);
            MainWindow? mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.contentContainer.Content = paymentPage;
            }
        }
    }
}
