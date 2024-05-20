using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

using Iss.Entity;
using Iss.Service;

namespace Iss.Windows
{
    public partial class CreateAdAccount : UserControl
    {
        public IAdAccountService AdAccountService;
        public CreateAdAccount()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049/");

            this.AdAccountService = new AdAccountServiceRest(httpClient);
            InitializeComponent();
            // Set the domain of activities and authorising institutions
            DomainOfActivityComboBox.ItemsSource = Constants.DOMAIN_OF_ACTIVITIES;
            AuthorisingInstitutionComboBox.ItemsSource = Constants.AUTHORIZING_INSTITUTIONS;
        }

        private void CreateAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            string nameOfCompany = CompanyName.Text;
            string domainOfActivity = DomainOfActivityComboBox.Text;
            string siteUrl = SiteUrl.Text;
            string password = Password.Password;
            string taxIdentificationNumber = CIF.Text;
            string headquartersLocation = Headquarters.Text;
            string authorisingInstitution = AuthorisingInstitutionComboBox.Text;
            // TODO! implement the creation of the account
            AdAccount account = new AdAccount(nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstitution);
            AdAccountService.AddAdAccount(account);
            AdAccountService.Login(nameOfCompany, password);
            // make the main window appear after button click
            LoginInfluencer mainWindow = Window.GetWindow(this) as LoginInfluencer;
            mainWindow.HomePage = new HomePage();
            this.Content = mainWindow.HomePage;
        }
    }
}
