using Iss.Entity;
using Iss.Repository;
using Iss.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Iss.Tests.Service
{
    public class PaymentServiceTests
    {
        [Fact]
        public void AddOneAd_WhenCalled_CallsAddOneAdOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addOneAd();

            // Assert
            mockPaymentRepository.Verify(x => x.addOneAd(), Times.Once);
        }

        [Fact]
        public void AddOneAdSet_WhenCalled_CallsAddOneAdSetOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addOneAdSet();

            // Assert
            mockPaymentRepository.Verify(x => x.addOneAdSet(), Times.Once);
        }

        [Fact]
        public void AddOneCampaign_WhenCalled_CallsAddOneCampaignOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addOneCampaign();

            // Assert
            mockPaymentRepository.Verify(x => x.addOneCampaign(), Times.Once);
        }

        [Fact]
        public void AddBasicSubscription_WhenCalled_CallsAddSubscriptionWithBasicOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addBasicSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.addSubscription("Basic"), Times.Once);
        }

        [Fact]
        public void AddSilverSubscription_WhenCalled_CallsAddSubscriptionWithSilverOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addSilverSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.addSubscription("Silver"), Times.Once);
        }

        [Fact]
        public void AddGoldSubscription_WhenCalled_CallsAddSubscriptionWithGoldOnRepository()
        {
            // Arrange
            var mockPaymentRepository = new Mock<IPaymentRepository>();
            var paymentService = new PaymentService(mockPaymentRepository.Object);

            // Act
            paymentService.addGoldSubscription();

            // Assert
            mockPaymentRepository.Verify(x => x.addSubscription("Gold"), Times.Once);
        }
    }
}
