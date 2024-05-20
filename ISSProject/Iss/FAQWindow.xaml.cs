// <copyright file="FAQWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using Backend.Models;
    using Backend.Services;
    using Frontend.FAQ;

    /// <summary>
    /// Interaction logic for FAQWindow.xaml.
    /// </summary>
    public partial class FAQWindow : Window
    {
        public Window MainWindow;
        private FAQService service;
        private ReviewService reviewService;
        private List<Backend.Models.FAQ> fAQs;
        private List<ReviewClass> reviews;

        /// <summary>
        /// Initializes a new instance of the <see cref="FAQWindow"/> class.
        /// </summary>
        public FAQWindow()
        {
            this.service = FAQService.Instance;
            this.reviewService = ReviewService.Instance;

            this.fAQs = new List<Backend.Models.FAQ>();
            this.reviews = new List<ReviewClass>();

            this.fAQs = this.service.GetAllFAQs();
            this.reviews = this.reviewService.GetAllReviews();

            this.InitializeComponent();

            this.listFAQ.ItemsSource = this.fAQs;

            this.Closed += (sender, e) =>
            {
                MainWindow.Show();
            };
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Search questions/topic...")
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Search questions/topic...";
            }
        }

        private void InputBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Write feedback...")
            {
                textBox.Text = string.Empty;
            }
        }

        private void InputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Write feedback...";
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox search = (TextBox)sender;
            string searchText = search.Text.ToLower();

            List<Backend.Models.FAQ> filteredFAQ = service.FilterFAQs(this.fAQs, search.Text);

            if (filteredFAQ == null || filteredFAQ.Count == 0)
            {
                filteredFAQ = this.fAQs;
            }

            this.listFAQ.ItemsSource = filteredFAQ;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputFeedback = this.inputBox.Text;
            this.reviewService.AddReview(inputFeedback);
            this.inputBox.Text = string.Empty;
        }

        private void ListFAQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listFAQ.SelectedItem != null)
            {
                Backend.Models.FAQ selectedFAQ = (Backend.Models.FAQ)this.listFAQ.SelectedItem;
                this.answerTextBlock.Text = selectedFAQ.Answer;
                this.answerPopup.IsOpen = true;
            }
            else
            {
                this.answerPopup.IsOpen = false;
            }
        }

        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
            this.answerPopup.IsOpen = false;
        }

        private void SubmitQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            SubmitQuestion windowSubmit = new SubmitQuestion();
            windowSubmit.Show();
        }

        private void AdminButton_Copy_Click(object sender, RoutedEventArgs e)
        {
            AdminMode admindWindow = new AdminMode();
            admindWindow.Show();
        }
    }
}
