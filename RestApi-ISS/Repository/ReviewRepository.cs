namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Models;
    using Iss.Database;
    using Iss.Entity;
    using Iss.Repository;
    using Iss.User;
    using Microsoft.Data.SqlClient;
    using RestApi_ISS.Controllers;

    public class ReviewRepository : INterfaceReview<ReviewClass>
    {
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
            databaseContext.ReviewClass.Add(newR);
            databaseContext.SaveChanges();
        }

        public void DeleteReview(ReviewClass reviewToDelete)
        {
            databaseContext.ChangeTracker.Clear();

            databaseContext.ReviewClass.Remove(reviewToDelete);
            databaseContext.SaveChanges();
        }

        public void UpdateReview(ReviewClass reviewToUpdate)
        {
            databaseContext.ChangeTracker.Clear();

            reviewToUpdate.User = User.GetInstance().Name;
            databaseContext.Update(reviewToUpdate);
            databaseContext.SaveChanges();
        }

        public ReviewClass GetReviewByName(string adName)
        {
            ReviewClass ad = databaseContext.ReviewClass.Where(a => a.User == adName).FirstOrDefault();

            return ad;
        }
    }
}
