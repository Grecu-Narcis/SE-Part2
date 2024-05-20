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
using Frontend;

namespace Iss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void InfluencerClick(object sender, RoutedEventArgs e)
        {
            LoginInfluencer loginInfluencerWindow = new LoginInfluencer();
            loginInfluencerWindow.Show();
        }
        private void CompanyClick(object sender, RoutedEventArgs e)
        {
           LoginWindow loginCompany = new LoginWindow();
            loginCompany.Show();
        }
    }
}
