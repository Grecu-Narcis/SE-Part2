// <copyright file="IServiceReview.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using Backend.Models;

namespace Backend.Services
{
    public interface IServiceReview
    {
        List<ReviewClass> GetAllReviews();

        void AddReview(string review);
    }
}
