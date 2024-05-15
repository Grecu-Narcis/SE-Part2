    using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    
    public class CollaborationTests
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int collaborationId = 1;
            DateTime startDate = new DateTime(2022, 4, 1);
            bool status = true;
            string contentRequirement = "Content requirement";
            string adOverview = "Ad overview";
            string collaborationFee = "100";
            int days = 7;
            string collaborationTitle = "Collaboration Title";

            // Act
            Collaboration collaboration = new Collaboration(collaborationId, startDate, status, contentRequirement, adOverview, collaborationFee, days, collaborationTitle);

            // Assert
            Assert.Equal(collaborationId, collaboration.CollaborationId);
            Assert.Equal(startDate, collaboration.startDate);
            Assert.Equal(status, collaboration.status);
            Assert.Equal(contentRequirement, collaboration.contentRequirement);
            Assert.Equal(adOverview, collaboration.adOverview);
            Assert.Equal(collaborationFee, collaboration.collaborationFee);
            Assert.Equal(startDate.AddDays(days), collaboration.endDate);
        }

        [Fact]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string collaborationTitle = "Collaboration Title";
            string adOverview = "Ad overview";
            string collaborationFee = "100";
            string contentRequirement = "Content requirement";
            DateTime startDate = new DateTime(2022, 4, 1);
            DateTime endDate = new DateTime(2022, 4, 8);
            bool status = true;

            // Act
            Collaboration collaboration = new Collaboration(collaborationTitle, adOverview, collaborationFee, contentRequirement, startDate, endDate, status);

            // Assert
            Assert.Equal(collaborationTitle, collaboration.collaborationTitle);
            Assert.Equal(adOverview, collaboration.adOverview);
            Assert.Equal(collaborationFee, collaboration.collaborationFee);
            Assert.Equal(contentRequirement, collaboration.contentRequirement);
            Assert.Equal(startDate, collaboration.startDate);
            Assert.Equal(endDate, collaboration.endDate);
            Assert.Equal(status, collaboration.status);
        }


    }
}
