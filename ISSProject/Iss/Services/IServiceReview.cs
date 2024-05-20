// <copyright file="IServiceReview.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Services
{
    using Backend.Models;

    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();

        void AddReview(string review);
    }
}
