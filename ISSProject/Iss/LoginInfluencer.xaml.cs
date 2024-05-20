using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Iss.Service;
using Iss.Windows;

namespace Iss
{
    /// <summary>
    /// Interaction logic for LoginInfluencer.xaml
    /// </summary>
    public partial class LoginInfluencer : Window
    {
        internal HomePage HomePage;
        internal CreateAdAccount CreateAdAccount;
        public IAdAccountService AdAccountService;
        public LoginInfluencer(IAdAccountService adAccountService)
        {
            this.AdAccountService = adAccountService;
            InitializeComponent();
            InfluencerStart influencerStart = new InfluencerStart();
            influencerStart.Show();
        }

        public LoginInfluencer()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5049/");

            AdAccountService = new AdAccountServiceRest(httpClient);

            InitializeComponent();
            InfluencerStart influencerStart = new InfluencerStart();
            influencerStart.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Password;
            try
            {
                AdAccountService.Login(username, password);

                // Open the new window containing the HomePage user control
                this.HomePage = new HomePage();
                contentContainer.Content = HomePage;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            this.CreateAdAccount = new CreateAdAccount();
            contentContainer.Content = CreateAdAccount;
        }
    }
}
