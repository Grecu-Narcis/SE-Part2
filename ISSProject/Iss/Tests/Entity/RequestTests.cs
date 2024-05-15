using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class RequestTests
    {
        [Fact]
        public void ToString_ReturnsCollaborationTitle()
        {
            // Arrange
            var request = new Request("Title", "Overview", "Requirements", "Compensation", DateTime.Now, DateTime.Now, true, true);

            // Act
            var result = request.ToString();

            // Assert
            Assert.Equal("Title", result);
        }

        [Fact]
        public void RequestProperties_AreSetCorrectly()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(7);

            // Act
            var request = new Request("Title", "Overview", "Requirements", "Compensation", startDate, endDate, true, true);

            // Assert
            Assert.Equal("Title", request.collaborationTitle);
            Assert.Equal("Overview", request.adOverview);
            Assert.Equal("Requirements", request.contentRequirements);
            Assert.Equal("Compensation", request.compensation);
            Assert.Equal(startDate, request.startDate);
            Assert.Equal(endDate, request.endDate);
            Assert.True(request.influencerAccept);
            Assert.True(request.adAccountAccept);
        }
    }
}
