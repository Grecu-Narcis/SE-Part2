// <copyright file="ExportSucces.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.Export
{
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

    /// <summary>
    /// Interaction logic for name.xaml.
    /// </summary>
    public partial class ExportSucces : Window
    {
        public Window MainWindow;

        public ExportSucces() => this.InitializeComponent();

        private void Click_Return_To_Main_Page_Button(object sender, RoutedEventArgs eventArgs)
        {
            this.MainWindow.Show();
            this.Close();
        }
    }
}
