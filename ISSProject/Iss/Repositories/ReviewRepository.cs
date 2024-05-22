// <copyright file="ReviewRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Controllers;
    using Backend.Models;
    using Iss.Database;
    using Iss.User;

    public class ReviewRepository : INterfaceReview<ReviewClass>
    {
        // private readonly string xmlFilePath;
        private List<ReviewClass> reviewList;
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();

        public ReviewRepository()
        {
            this.reviewList = new List<ReviewClass>();
        }

        public List<ReviewClass> GetReviewList()
        {
            return this.reviewList;
        }

        public void AddReview(ReviewClass newR)
        {
            databaseContext.Review.Add(newR);
            databaseContext.SaveChanges();
        }

        public void DeleteReview(ReviewClass reviewToDelete)
        {
            databaseContext.ChangeTracker.Clear();

            databaseContext.Review.Remove(reviewToDelete);
            databaseContext.SaveChanges();
        }

        public void UpdateReview(ReviewClass reviewToUpdate)
        {
            databaseContext.ChangeTracker.Clear();

            reviewToUpdate.User = Iss.User.User.GetInstance().Name;
            databaseContext.Update(reviewToUpdate);
            databaseContext.SaveChanges();
        }

        public ReviewClass GetReviewByName(string adName)
        {
            ReviewClass ad = databaseContext.Review.Where(a => a.User == adName).FirstOrDefault();

            return ad;
        }
    }
}
