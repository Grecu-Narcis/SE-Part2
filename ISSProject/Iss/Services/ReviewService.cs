﻿// <copyright file="ReviewService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Models;
    using Backend.Repositories;

    public class ReviewService : IServiceReview
    {
        private static readonly ReviewService TheInstance = new ();
        private readonly ReviewRepository reviewRepository;

        private ReviewService()
        {
            this.reviewRepository = new ReviewRepository();
        }

        public static ReviewService Instance
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
    }
}
