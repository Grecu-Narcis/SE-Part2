// <copyright file="ExportWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Windows;
using Backend.Models;
using Frontend.Export;

namespace Frontend
{
    /// <summary>
    /// Interaction logic for Window1.xaml.
    /// </summary>
    public partial class ExportWindow : Window
    {
        private readonly AdvertisementStatistics stats = new AdvertisementStatistics(1000, 100, 5, 30);
        private readonly ExportManager exportManager;
        private readonly User user = new User();

        public ExportWindow()
        {
            this.InitializeComponent();
            this.user.Username = "Andrew Stone";
            this.exportManager = new ExportManager();
            this.MainWindow = new MainWindowStats();

            this.Closed += (sender, eventData) =>
            {
               this.MainWindow.Show();
            };
        }

        public MainWindowStats? MainWindow { get; set; }

        public void ConfirmExport()
        {
            if (this.MainWindow != null)
            {
                ExportSucces exportSucces = new ()
                {
                    MainWindow = this.MainWindow,
                };
                exportSucces.Show();
                this.Hide();
            }
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            int fontIndex = this.FontBox.SelectedIndex;
            int colorIndex = this.ColorBox.SelectedIndex;
            int fontSize = int.Parse(this.SizeInput.Text);
            bool impressionsChecked = this.ImpressionsCheck.IsChecked == true;
            bool clicksChecked = this.ClicksCheck.IsChecked == true;
            bool buysChecked = this.BuysCheck.IsChecked == true;
            bool timeChecked = this.TimeCheck.IsChecked == true;
            bool ctrChecked = this.CTRCheck.IsChecked == true;
            bool dateChecked = this.DateCheck.IsChecked == true;
            bool signatureChecked = this.SignatureCheck.IsChecked == true;
            bool recipientChecked = this.RecipientCheck.IsChecked == true;
            string recipientInput = this.RecipientInput.Text;
            bool emailButtonChecked = this.EmailButton1.IsChecked == true;
            bool downloadButtonChecked = this.DownloadButton1.IsChecked == true;
            string outputPath = "C:\\Users\\User\\Downloads\\output.csv";
            string emailRecipient = this.EmailInput1.Text;

            if (this.Radio7.IsChecked == true)
            {
                this.exportManager.ExportPDF(
                    this.stats,
                    this.user,
                    fontSize,
                    fontIndex,
                    colorIndex,
                    impressionsChecked,
                    clicksChecked,
                    buysChecked,
                    timeChecked,
                    ctrChecked,
                    dateChecked,
                    signatureChecked,
                    recipientChecked,
                    recipientInput,
                    emailButtonChecked,
                    downloadButtonChecked);
            }

            if (this.Radio5.IsChecked == true)
            {
                this.exportManager.ExportCSV(
                    this.stats,
                    impressionsChecked,
                    clicksChecked,
                    buysChecked,
                    ctrChecked,
                    timeChecked,
                    outputPath,
                    emailRecipient);
            }

            this.ConfirmExport();
        }

        private void ReturnButton1_Click(object sender, RoutedEventArgs e)
        {
            if (this.MainWindow != null)
            {
                this.MainWindow.Show();
                this.Close();
            }
        }
    }
}
