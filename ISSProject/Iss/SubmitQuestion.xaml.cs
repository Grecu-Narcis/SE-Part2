// <copyright file="SubmitQuestion.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.FAQ
{
    using System.Windows;
    using System.Windows.Controls;
    using Backend.Services;

    /// <summary>
    /// Interaction logic for SubmitQuestion.xaml.
    /// </summary>
    public partial class SubmitQuestion : Window
    {
        private readonly FAQService service;
        private readonly List<string> topics;

        // private readonly List<Backend.Models.FAQ> faqs;
        public SubmitQuestion()
        {
            this.InitializeComponent();

            this.service = FAQService.Instance;

            this.topics = this.service.GetTopics();

            this.dropTopic.ItemsSource = this.topics;
        }

        private void QuestionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Input question here...")
            {
                textBox.Text = string.Empty;
            }
        }

        private void QuestionBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input question here...";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string question = this.questionBox.Text;
            string? selectedTopic = this.dropTopic.SelectedItem as string;
            Backend.Models.FAQ newQ = new (question,
                                           "to be added",
                                           topic: selectedTopic);
            this.service.AddSubmittedQuestion(newQ);
            MessageBox.Show("The question has been submitted. Check the FAQ page later to see if it has been approved.");
        }
    }
}
