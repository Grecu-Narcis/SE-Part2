using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    public class FakeFAQRepository : IFAQRepository
    {
        private readonly List<FAQ> faqList;

        public FakeFAQRepository()
        {
            faqList = new List<FAQ>();
        }

        public List<FAQ> GetFAQList()
        {
            return faqList;
        }

        public void AddFAQ(FAQ newQestion)
        {
            faqList.Add(newQestion);
        }

        public void DeleteFAQ(FAQ question)
        {
            faqList.Remove(question);
        }
    }
}
