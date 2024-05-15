using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class RequestTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string collaborationTitle = "Title";
            string adOverview = "Overview";
            string contentRequirements = "Requirements";
            string compensation = "Compensation";
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddDays(1);
            bool influencerAccept = true;
            bool adAccountAccept = true;

            // Act
            Request request = new Request(collaborationTitle, adOverview, contentRequirements, compensation, startDate, endDate, influencerAccept, adAccountAccept);

            // Assert
            Assert.Equal(collaborationTitle, request.collaborationTitle);
            Assert.Equal(adOverview, request.adOverview);
            Assert.Equal(contentRequirements, request.contentRequirements);
            Assert.Equal(compensation, request.compensation);
            Assert.Equal(startDate, request.startDate);
            Assert.Equal(endDate, request.endDate);
            Assert.Equal(influencerAccept, request.influencerAccept);
            Assert.Equal(adAccountAccept, request.adAccountAccept);
        }

    }
}
