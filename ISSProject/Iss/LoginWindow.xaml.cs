// <copyright file="LoginWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend
{
    using System.Windows;
    using System.Windows.Controls;
    using Backend.Login;

    /// <summary>
    /// Interaction logic for name.xaml.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel loginViewModel;

        public LoginWindow()
        {
            this.InitializeComponent();
            this.loginViewModel = new LoginViewModel();
        }

        private void Click_Login_Button_Event(object sender, RoutedEventArgs eventArgs)
        {
            this.loginViewModel.Username = this.UsernameTextBox.Text;
            this.loginViewModel.Password = this.PasswordTextBox.Password;
            this.loginViewModel.Email = this.EmailTextBox.Text;

            if (this.loginViewModel.AreUserCredentialsValidForLogin())
            {
                MessageBox.Show("You have been logged in successfully.", "Login success!");
                MainWindowStats window = new ();
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid account credentials.", "Login failed!");
            }
        }

        private void TextBox_Username_LostFocus(object sender, RoutedEventArgs eventArgs)
        {
            TextBox? senderTextBox = sender as TextBox;
            if (senderTextBox != null && string.IsNullOrWhiteSpace(senderTextBox.Text))
            {
                senderTextBox.Text = " ";
            }
        }

        private void TextBox_Email_LostFocus(object sender, RoutedEventArgs eventArgs)
        {
            TextBox? senderTextBox = sender as TextBox;
            if (senderTextBox != null && string.IsNullOrWhiteSpace(senderTextBox.Text))
            {
                senderTextBox.Text = " ";
            }
        }
    }
}