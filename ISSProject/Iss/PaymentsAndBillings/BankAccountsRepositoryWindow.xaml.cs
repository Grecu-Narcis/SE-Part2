// <copyright file="BankAccountsRepositoryWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.PaymentsAndBillings
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using Backend.Controllers;

    /// <summary>
    /// Interaction logic for BankAccountsRepositoryWindow.xaml.
    /// </summary>
    public partial class BankAccountsRepositoryWindow : Window
    {
        public Window? MainWindow;
        private readonly InterfaceBankAccountController bankAccountController;

        public BankAccountsRepositoryWindow(InterfaceBankAccountController bankAccountControllerInstance)
        {
            this.bankAccountController = bankAccountControllerInstance;
            this.InitializeComponent();
            this.UpdateFields();

            this.Closed += (sender, eventData) =>
            {
                this.MainWindow!.Show();
            };
        }

        private void UpdateFields()
        {
            this.textEmail.Text = this.bankAccountController.GetBankAccount().Email;
            this.textName.Text = this.bankAccountController.GetBankAccount().Name;
            this.textSurname.Text = this.bankAccountController.GetBankAccount().Surname;
            this.textPhoneNumber.Text = this.bankAccountController.GetBankAccount().PhoneNumber;
            this.textCounty.Text = this.bankAccountController.GetBankAccount().County;
            this.textCity.Text = this.bankAccountController.GetBankAccount().City;
            this.textAddress.Text = this.bankAccountController.GetBankAccount().Address;
            this.textNumber.Text = this.bankAccountController.GetBankAccount().Number;
            this.textHolderName.Text = this.bankAccountController.GetBankAccount().HolderName;
            this.textExpiryDate.Text = this.bankAccountController.GetBankAccount().ExpiryDate;
        }

        private void HomePage_MouseLeftButtonDown(object sender, MouseButtonEventArgs mouseEvent)
        {
            this.Close();
        }

        private void Profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs mouseEvent)
        {
            MessageBox.Show("Profile clicked!");
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs mouseEvent)
        {
            try
            {
                this.bankAccountController.UpdateBankAccount(this.textName.Text, this.textSurname.Text, this.textEmail.Text, this.textPhoneNumber.Text, this.textCounty.Text, this.textCity.Text, this.textAddress.Text, this.textNumber.Text, this.textHolderName.Text, this.textExpiryDate.Text);
                MessageBox.Show("Bank account updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.UpdateFields();
            }
        }

        private void HomePage_MouseEnter(object sender, MouseEventArgs mouseEvent)
        {
            this.homePageBlock.Background = Brushes.LightGray;
        }

        private void HomePage_MouseLeave(object sender, MouseEventArgs mouseEvent)
        {
            this.homePageBlock.Background = Brushes.DimGray;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs mouseEvent)
        {
            this.profileBlock.Background = Brushes.LightGray;
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs mouseEvent)
        {
            this.profileBlock.Background = Brushes.DimGray;
        }

        private void Profile_Click(object sender, RoutedEventArgs mouseEvent)
        {
            MessageBox.Show("Profile clicked!");
        }
    }
}
