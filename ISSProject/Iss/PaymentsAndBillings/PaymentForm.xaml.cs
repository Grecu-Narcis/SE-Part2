// <copyright file="PaymentForm.xaml.cs" company="PlaceholderCompany">
// Copyright (controllerForPayment) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.PaymentsAndBillings
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Backend.Controllers;

    /// <summary>
    /// Interaction logic for PaymentForm.xaml.
    /// </summary>
    public partial class PaymentForm : Window
    {
        public Window MainWindow;
        private readonly PaymentFormController paymentController;

        public PaymentForm(PaymentFormController controllerForPayment)
        {
            this.paymentController = controllerForPayment;
            this.InitializeComponent();
            this.UpdateFields();

            this.Closed += (sender, EventData) =>
            {
                this.MainWindow.Show();
            };
        }

        private void UpdateFields()
        {
            this.itemName.Text = this.paymentController.GetProduct().Name;
            this.itemDescription.Text = this.paymentController.GetProduct().Description;
            this.itemPrice.Text = this.paymentController.GetProduct().Price;
            var itemImageSource = this.paymentController.GetProduct().Image;
            this.itemImage.Source = new BitmapImage(new Uri(itemImageSource, UriKind.Relative));
        }

        private async void PayButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.paymentController.SendPaymentConfirmationMailAsync();
                MessageBox.Show("Payment sent successfully!");
            }
            catch
            {
                MessageBox.Show("Payment failed!");
            }
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Changes saved successfully!");
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs e)
        {
            this.homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs e)
        {
            this.homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            this.profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            this.profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
