using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class OneCampaignPaymentTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int campaignPaymentId = 1;
            int reach = 1000;
            decimal price = 100;

            // Act
            OneCampaignPayment oneCampaignPayment = new OneCampaignPayment(campaignPaymentId, reach, price);

            // Assert
            Assert.Equal(campaignPaymentId, oneCampaignPayment.campaignPaymentId);
            Assert.Equal(reach, oneCampaignPayment.reach);
            Assert.Equal(price, oneCampaignPayment.price);

            // Set
            oneCampaignPayment.campaignPaymentId = 2;
            oneCampaignPayment.reach = 2000;
            oneCampaignPayment.price = 200;

            // Assert
            Assert.Equal(2, oneCampaignPayment.campaignPaymentId);
            Assert.Equal(2000, oneCampaignPayment.reach);
            Assert.Equal(200, oneCampaignPayment.price);
        }   
    }
}
