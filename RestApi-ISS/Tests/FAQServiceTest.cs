using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using RestApi_ISS.Entity;
using RestApi_ISS.Repository;
using RestApi_ISS.Service;

namespace RestApi_ISS.Tests.Service
{
    [TestFixture]
    public class FAQServiceTests
    {
        private Mock<IFAQRepository> mockFAQRepository;
        private FAQService faqService;

        [SetUp]
        public void SetUp()
        {
            mockFAQRepository = new Mock<IFAQRepository>();
            faqService = new FAQService();
        }

        [Test]
        public void GetAllFAQs_ReturnsAllFAQs()
        {
            var expectedFAQs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "What is this?", Topic = "General" },
                new FAQ { Id = 2, Question = "How does it work?", Topic = "Usage" }
            };

            mockFAQRepository.Setup(repo => repo.GetFAQList()).Returns(expectedFAQs);

            var result = faqService.GetAllFAQs();

            Assert.That(result, Is.EqualTo(expectedFAQs.Count));
            CollectionAssert.AreEqual(expectedFAQs, result);
        }

        [Test]
        public void GetTopics_ReturnsUniqueTopics()
        {
            var faqs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "What is this?", Topic = "General" },
                new FAQ { Id = 2, Question = "How does it work?", Topic = "Usage" },
                new FAQ { Id = 3, Question = "What is the usage?", Topic = "Usage" }
            };

            mockFAQRepository.Setup(repo => repo.GetFAQList()).Returns(faqs);

            var result = faqService.GetTopics();

            Assert.That(result, Is.EqualTo(2));
            CollectionAssert.AreEquivalent(new List<string> { "General", "Usage" }, result);
        }

        [Test]
        public void AddSubmittedQuestion_AddsQuestionToList()
        {
            var newQuestion = new FAQ { Id = 1, Question = "What is this?", Topic = "General" };

            faqService.AddSubmittedQuestion(newQuestion);

            var submittedQuestions = faqService.GetSubmittedQuestions();
            Assert.That(submittedQuestions.Count, Is.EqualTo(1));
            Assert.That(submittedQuestions, Is.EqualTo(newQuestion));
        }

        [Test]
        public void DeleteFAQ_RemovesFAQFromRepository()
        {
            var faqs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "What is this?", Topic = "General" }
            };

            mockFAQRepository.Setup(repo => repo.GetFAQList()).Returns(faqs);
            mockFAQRepository.Setup(repo => repo.DeleteFAQ(It.IsAny<FAQ>()));

            faqService.DeleteFAQ(1);

            mockFAQRepository.Verify(repo => repo.DeleteFAQ(It.Is<FAQ>(f => f.Id == 1)), Times.Once);
        }

        [Test]
        public void FilterFAQs_FiltersBySearchText()
        {
            var faqs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "What is this?", Topic = "General" },
                new FAQ { Id = 2, Question = "How does it work?", Topic = "Usage" },
                new FAQ { Id = 3, Question = "What is the usage?", Topic = "Usage" }
            };

            var result = faqService.FilterFAQs(faqs, "usage");

            Assert.That(result.Count, Is.EqualTo(2));
            CollectionAssert.AreEquivalent(faqs.Where(f => f.Topic == "Usage"), result);
        }
    }
}