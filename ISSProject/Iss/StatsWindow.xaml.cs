// <copyright file="StatsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend
{
    using System;
    using System.Windows;
    using ScottPlot;

    /// <summary>
    /// Interaction logic for StatsWindow.xaml.
    /// </summary>
    // [Obsolete]
    public partial class StatsWindow : Window
    {
        private Window mainWindow;

        public StatsWindow()
        {
            this.InitializeComponent();
            this.mainWindow = Application.Current.MainWindow;

            double[] engagement_data_xAxis = new double[24];
            double[] engagement_data_yAxis = new double[24];

            double[] clicks_data_xAxis = new double[24];
            double[] clicks_data_yAxis = new double[24];

            double[] impressions_data_xAxis = new double[24];
            double[] impressions_data_yAxis = new double[24];

            double[] purchases_data_xAxis = new double[24];
            double[] purchases_data_yAxis = new double[24];

            double[] zeros = new double[24];

            void ShowEngagementPlot()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Ad Engagement throughout the day");
                this.CurrentPlot.Plot.XLabel("Hour of the day");
                this.CurrentPlot.Plot.YLabel("Engagement on a scale from 1 to 10");

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10);
                this.CurrentPlot.Plot.Add.Bars(engagement_data_xAxis, engagement_data_yAxis);
                this.CurrentPlot.Plot.ShowGrid();
                this.CurrentPlot.Plot.HideLegend();
                this.CurrentPlot.Refresh();
            }

            void ShowClicksPlot()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Ad Clicks in the last 24 days");
                this.CurrentPlot.Plot.XLabel("Days ago");
                this.CurrentPlot.Plot.YLabel("Number of clicks");

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 1000);
                this.CurrentPlot.Plot.Add.FillY(clicks_data_xAxis, clicks_data_yAxis, zeros);
                this.CurrentPlot.Plot.Add.Scatter(clicks_data_xAxis, clicks_data_yAxis);
                this.CurrentPlot.Plot.ShowGrid();
                this.CurrentPlot.Plot.HideLegend();
                this.CurrentPlot.Refresh();
            }

            void ShowImpressionsPlot()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Ad Impressions in the last 24 days");
                this.CurrentPlot.Plot.XLabel("Days ago");
                this.CurrentPlot.Plot.YLabel("Number of impressions");

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 10000);
                this.CurrentPlot.Plot.Add.FillY(impressions_data_xAxis, impressions_data_yAxis, zeros);
                this.CurrentPlot.Plot.Add.Scatter(impressions_data_xAxis, impressions_data_yAxis);
                this.CurrentPlot.Plot.ShowGrid();
                this.CurrentPlot.Plot.HideLegend();
                this.CurrentPlot.Refresh();
            }

            void ShowCTRPlot()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Click-through rate in the last 24 days");
                this.CurrentPlot.Plot.XLabel("Days ago");
                this.CurrentPlot.Plot.YLabel("CTR");

                double[] current_data_xAxis = new double[24];
                double[] current_data_yAxis = new double[24];

                for (int index = 0; index < 24; index++)
                {
                    current_data_xAxis[index] = index;
                }

                for (int index = 0; index < 24; index++)
                {
                    current_data_yAxis[index] = clicks_data_yAxis[index] / impressions_data_yAxis[index];
                }

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 1);
                this.CurrentPlot.Plot.Add.FillY(current_data_xAxis, current_data_yAxis, zeros);
                this.CurrentPlot.Plot.Add.Scatter(current_data_xAxis, current_data_yAxis);
                this.CurrentPlot.Plot.ShowGrid();
                this.CurrentPlot.Plot.HideLegend();
                this.CurrentPlot.Refresh();
            }

            void ShowPurchasesPlot()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Purchases in the last 24 days");
                this.CurrentPlot.Plot.XLabel("Days ago");
                this.CurrentPlot.Plot.YLabel("Number of purchases");

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -0.5, right: 23.5);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: 0, top: 500);

                this.CurrentPlot.Plot.Add.FillY(purchases_data_xAxis, purchases_data_yAxis, zeros);
                this.CurrentPlot.Plot.Add.Scatter(purchases_data_xAxis, purchases_data_yAxis);
                this.CurrentPlot.Plot.ShowGrid();
                this.CurrentPlot.Plot.HideLegend();

                this.CurrentPlot.Refresh();
            }

            void ShowEngagementTypes()
            {
                this.CurrentPlot.Plot.Clear();
                this.CurrentPlot.Plot.Title("Engagement types in the last 24 days");

                double[] sums = new double[2];
                for (int index = 0; index < 24; index++)
                {
                    sums[0] += clicks_data_yAxis[index];
                    sums[1] += purchases_data_yAxis[index];
                }

                this.CurrentPlot.Plot.Axes.SetLimitsX(left: -1, right: 1);
                this.CurrentPlot.Plot.Axes.SetLimitsY(bottom: -1, top: 1);
                this.CurrentPlot.Plot.HideGrid();
                this.CurrentPlot.Plot.ShowLegend([
                    new ()
                    {
                        Label = "Users that clicked the add and bought",
                        LineColor = Colors.Orange,
                        MarkerColor = Colors.Orange,
                    },
                    new ()
                    {
                        Label = "Users that only clicked the add",
                        LineColor = Colors.Blue,
                        MarkerColor = Colors.Blue,
                    }

                ]);

                this.CurrentPlot.Plot.Add.Pie(sums);
                this.CurrentPlot.Plot.XLabel(string.Empty);
                this.CurrentPlot.Plot.YLabel(string.Empty);
                this.CurrentPlot.Refresh();
            }

            this.Loaded += (sender, eventData) =>
            {
                Random random = new ();
                for (int index = 0; index < 24; index++)
                {
                    engagement_data_xAxis[index] = index;
                }

                for (int index = 0; index < 24; index++)
                {
                    engagement_data_yAxis[index] = random.Next(10);
                }

                for (int index = 0; index < 24; index++)
                {
                    clicks_data_xAxis[index] = index;
                }

                for (int index = 0; index < 24; index++)
                {
                    clicks_data_yAxis[index] = random.Next(1000);
                }

                for (int index = 0; index < 24; index++)
                {
                    impressions_data_xAxis[index] = index;
                }

                for (int index = 0; index < 24; index++)
                {
                    impressions_data_yAxis[index] = random.Next((int)clicks_data_yAxis[index], 10000);
                }

                for (int index = 0; index < 24; index++)
                {
                    purchases_data_xAxis[index] = index;
                }

                for (int index = 0; index < 24; index++)
                {
                    purchases_data_yAxis[index] = random.Next((int)clicks_data_yAxis[index] / 10, (int)clicks_data_yAxis[index] / 2);
                }

                for (int index = 0; index < 24; index++)
                {
                    zeros[index] = 0;
                }

                this.CurrentPlot.Width = 800;
                this.CurrentPlot.Height = 460;

                ShowEngagementPlot();
            };

            this.Closed += (sender, eventData1) =>
            {
                this.MainWindow.Show();
            };

            this.EngagementButton.Click += (sender, eventData) =>
            {
                ShowEngagementPlot();
            };

            this.ClicksButton.Click += (sender, eventData) =>
            {
                ShowClicksPlot();
            };

            this.ImpresionsButton.Click += (sender, eventData) =>
            {
                ShowImpressionsPlot();
            };

            this.CTRButton.Click += (sender, eventData) =>
            {
                ShowCTRPlot();
            };

            this.PurchasesButton.Click += (sender, eventData) =>
            {
                ShowPurchasesPlot();
            };

            this.EngagementTypesButton.Click += (sender, eventData) =>
            {
                ShowEngagementTypes();
            };

            this.BackButton.Click += (sender, eventData) =>
            {
                this.MainWindow.Show();
                this.Close();
            };
        }

        public Window MainWindow
        {
            get { return this.mainWindow; }
            set { this.mainWindow = value; }
        }
    }
}