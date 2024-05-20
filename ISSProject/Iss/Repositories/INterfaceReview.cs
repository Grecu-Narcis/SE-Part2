using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Repositories
{
    internal interface INterfaceReview<T>
    {
        public List<ReviewClass> GetReviewList();

        public void AddReview(ReviewClass newR);
    }
}
