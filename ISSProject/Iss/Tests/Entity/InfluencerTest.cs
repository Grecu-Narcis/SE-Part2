using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class InfluencerTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string influencerId = "1";
            string influencerName = "Influencer Name";
            int followerCount = 1000;
            int collaborationPrice = 100;

            // Act
            Influencer influencer = new Influencer(influencerId, influencerName, followerCount, collaborationPrice);

            // Assert
            Assert.Equal(influencerId, influencer.influencerId);
            Assert.Equal(influencerName, influencer.influencerName);
            Assert.Equal(followerCount, influencer.followerCount);
            Assert.Equal(collaborationPrice, influencer.collaborationPrice);
            Assert.Equal(influencerName + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$", influencer.ToString());
        }

        [Fact]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string influencerName = "Influencer Name";
            int followerCount = 1000;
            int collaborationPrice = 100;

            // Act
            Influencer influencer = new Influencer(influencerName, followerCount, collaborationPrice);

            // Assert
            Assert.Equal(influencerName, influencer.influencerName);
            Assert.Equal(followerCount, influencer.followerCount);
            Assert.Equal(collaborationPrice, influencer.collaborationPrice);
            Assert.Equal(influencerName + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$", influencer.ToString());
        }
    }
}
