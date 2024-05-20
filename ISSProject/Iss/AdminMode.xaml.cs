// <copyright file="AdminMode.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend.FAQ
{
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using Backend.Models;
    using Backend.Services;

    /// <summary>
    /// Interaction logic for AdminMode.xaml.
    /// </summary>
    public partial class AdminMode : Window
    {
        private readonly TODOServices todoServices;
        private readonly ReviewService reviewService;

        public AdminMode()
        {
            this.todoServices = TODOServices.Instance;
            this.reviewService = ReviewService.Instance;
            this.InitializeComponent();
            this.PopulateTodoList();
            this.PopulateReviewList();
        }

        private void PopulateReviewList()
        {
            List<ReviewClass> reviews = this.reviewService.GetAllReviews();
            if (reviews != null)
            {
                StringBuilder stringBuilderInstance = new ();
                foreach (ReviewClass review in reviews)
                {
                    stringBuilderInstance.AppendLine(review.ToString());
                }

                this.reviewBlock.Text = stringBuilderInstance.ToString();
            }
            else
            {
                this.reviewBlock.Text = string.Empty;
            }
        }

        private void PopulateTodoList()
        {
            List<TODOClass> todos = this.todoServices.GetTODOS();
            if (todos != null)
            {
                StringBuilder stringBuilderInstance = new ();
                foreach (TODOClass todo in todos)
                {
                    stringBuilderInstance.AppendLine(todo.ToString());
                }

                this.todoTextBlock.Text = stringBuilderInstance.ToString();
            }
            else
            {
                this.todoTextBlock.Text = string.Empty;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Input number of finished task")
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input number of finished task";
            }
        }

        private void AddTask_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "Input new task here")
            {
                textBox.Text = string.Empty;
            }
        }

        private void AddTask_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Input new task here";
            }
        }

        private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(this.removeText.Text, out int idToRemove))
            {
                this.todoServices.RemoveTODO(idToRemove);
                this.PopulateTodoList();
                this.removeText.Text = "Input number of finished task";
            }
            else
            {
                MessageBox.Show("Please enter a valid ID.");
            }
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string newTask = this.addTask.Text;
            if (!string.IsNullOrWhiteSpace(newTask))
            {
                TODOClass task = new (newTask);
                this.todoServices.AddTODO(task);
            }

            this.PopulateTodoList();
        }
}
}
