// <copyright file="PaymentsAndBillingsMain.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.PaymentsAndBillings
{
    using System.Windows;
    using Backend.Controllers;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interaction logic for PaymentsAndBillingsMain.xaml.
    /// </summary>
    public partial class PaymentsAndBillingsMain : Window
    {
        public Window MainWindow;

        public PaymentsAndBillingsMain()
        {
            this.InitializeComponent();

            this.Closed += (sender, eventData) =>
            {
                this.MainWindow.Show();
            };
        }

        private void BankAccountDetails_Click(object sender, RoutedEventArgs e)
        {
            var bankAccountsRepositoryWindow = new BankAccountsRepositoryWindow(
                App.ServiceProvider.GetService<BankAccountController>());
            bankAccountsRepositoryWindow.MainWindow = this;
            bankAccountsRepositoryWindow.Show();
        }

        private void PaymentForm_Click(object sender, RoutedEventArgs e)
        {
            var paymentForm = new PaymentForm(
                App.ServiceProvider.GetService<PaymentFormController>());
            paymentForm.MainWindow = this;
            paymentForm.Show();
        }
    }
}
