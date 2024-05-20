// <copyright file="FAQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using System.Reflection.Metadata.Ecma335;
    using Backend.Models;
    using Backend.Repositories;

    public class FAQService : IFAQService
    {
        private static readonly FAQService InstanceValue = new ();
        private readonly List<string> topics = new ();
        private readonly FAQRepository repository;
        private readonly List<FAQ> submittedQuestions;

        public FAQService()
        {
            this.repository = new FAQRepository();
            this.submittedQuestions = new ();
        }

        public static FAQService Instance
        {
            get { return InstanceValue; }
        }

        public List<FAQ> GetAllFAQs()
        {
            return this.repository.GetFAQList();
        }

        public List<string> GetTopics()
        {
            List<Backend.Models.FAQ> faqList = this.GetAllFAQs();
            foreach (Backend.Models.FAQ faqItem in faqList)
            {
                if (!this.topics.Contains(faqItem.Topic))
                {
                    this.topics.Add(faqItem.Topic);
                }
            }

            return this.topics;
        }

        public void AddSubmittedQuestion(FAQ newQuestion)
        {
            this.submittedQuestions.Add(newQuestion);
        }

        public void DeleteFAQ(int id)
        {
            FAQ faqToDelete = this.repository.GetFAQList().FirstOrDefault(f => f.Id == id);
            if (faqToDelete != null)
            {
                this.repository.DeleteFAQ(faqToDelete); // Delete from the database
            }
        }

        public List<FAQ> GetSubmittedQuestions()
        {
            return this.submittedQuestions;
        }

        public List<FAQ> FilterFAQs(List<FAQ> faqList, string searchText)
        {
            searchText = searchText.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                return faqList
                    .Where(faq =>
                        faq.Question.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                        faq.Topic.Equals(searchText, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            return faqList;
        }
    }
}
