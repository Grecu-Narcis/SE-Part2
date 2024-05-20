// <copyright file="ReviewRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System.Xml;
    using System.Xml.Serialization;
    using Backend.Controllers;
    using Backend.Models;
    public class ReviewRepository : INterfaceReview<ReviewClass>
    {
        private readonly string xmlFilePath;
        private List<ReviewClass> reviewList;

        public ReviewRepository()
        {
            this.reviewList = new List<ReviewClass>();
            string binDirectory = "\\bin";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string pathUntilBin;

            int index = basePath.IndexOf(binDirectory);
            pathUntilBin = basePath[..index];
            string pathToReviewsXML = $"\\XMLFiles\\REVIEWitems.xml";
            this.xmlFilePath = pathUntilBin + pathToReviewsXML;
            this.LoadFromXml();
        }

        public List<ReviewClass> GetReviewList()
        {
            return this.reviewList;
        }

        public void AddReview(ReviewClass newR)
        {
            this.reviewList.Add(newR);
            this.SaveToXml();
        }

        private void LoadFromXml()
        {
            try
            {
                if (File.Exists(this.xmlFilePath))
                {
                    XmlSerializer serializer = new (typeof(ReviewClass), new XmlRootAttribute("ReviewClass"));

                    this.reviewList = new List<ReviewClass>();
                    using FileStream fileStream = new (this.xmlFilePath, FileMode.Open);
                    using XmlReader reader = XmlReader.Create(fileStream);
                    while (reader.ReadToFollowing("ReviewClass"))
                    {
                        ReviewClass review = (ReviewClass)serializer.Deserialize(reader);
                        this.reviewList.Add(review);
                    }
                }
                else
                {
                    this.reviewList = new List<ReviewClass>();
                }
            }
            catch
            {
            }
        }

        private void SaveToXml()
        {
            XmlSerializer serializer = new (typeof(List<ReviewClass>), new XmlRootAttribute("Reviews"));

            using FileStream fileStream = new (this.xmlFilePath, FileMode.Create);
            serializer.Serialize(fileStream, this.reviewList);
        }
    }
}
