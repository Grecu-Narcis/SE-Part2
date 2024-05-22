// <copyright file="ReviewService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Backend.Models;
using Backend.Repositories;
using Iss.Services;

namespace Backend.Services
{
    public class ReviewService<T> : IServiceReview
    {
        private static readonly ReviewService<T> TheInstance = new ();
        private readonly INterfaceReview<T> reviewRepository;

        private ReviewService(INterfaceReview<T> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        private ReviewService()
        {
            this.reviewRepository = new ReviewRepository() as INterfaceReview<T>;
        }

        public static ReviewService<T> Instance
        {
            get { return TheInstance; }
        }

        public List<ReviewClass> GetAllReviews()
        {
            return this.reviewRepository.GetReviewList();
        }

        public void AddReview(string review)
        {
            string user = "Dan Oliver";
            ReviewClass reviewToAdd = new (user, review);
            this.reviewRepository.AddReview(reviewToAdd);
        }

        List<ReviewClass> IServiceReview.GetAllReviews()
        {
            throw new System.NotImplementedException();
        }
    }
}
