using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;
using Iss.Repository;
using Moq;
using Xunit;
using Iss.Service;

namespace Iss.Tests.Service
{
    public class AdServiceTests
    {
        [Fact]
        public void AddAd_WhenCalled_CallsAddAdOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            var ad = new Ad(
                productName: "Test Product",
                photo: "test.jpg",
                description: "Test description",
                websiteLink: "https://example.com"
            );

            // Act
            adService.addAd(ad);

            // Assert
            mockAdRepository.Verify(x => x.addAd(ad), Times.Once);
        }

        [Fact]
        public void GetAdsThatAreNotInAdSet_WhenCalled_CallsGetAdsThatAreNotInAdSetOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            // Act
            var result = adService.getAdsThatAreNotInAdSet();

            // Assert
            mockAdRepository.Verify(x => x.getAdsThatAreNotInAdSet(), Times.Once);
        }

        [Fact]
        public void UpdateAd_WhenCalled_CallsUpdateAdOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            var ad = new Ad(
                productName: "Test Product",
                photo: "test.jpg",
                description: "Test description",
                websiteLink: "https://example.com"
            );

            // Act
            adService.updateAd(ad);

            // Assert
            mockAdRepository.Verify(x => x.updateAd(ad), Times.Once);
        }

        [Fact]
        public void GetAdByName_WhenCalled_CallsGetAdByNameOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            string adName = "TestAdName";

            // Act
            var result = adService.getAdByName(adName);

            // Assert
            mockAdRepository.Verify(x => x.getAdByName(adName), Times.Once);
        }

        [Fact]
        public void DeleteAd_WhenCalled_CallsDeleteAdOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            var ad = new Ad(
                productName: "Test Product",
                photo: "test.jpg",
                description: "Test description",
                websiteLink: "https://example.com"
            );

            // Act
            adService.deleteAd(ad);

            // Assert
            mockAdRepository.Verify(x => x.deleteAd(ad), Times.Once);
        }

        [Fact]
        public void GetAdsFromAdSet_WhenCalled_CallsGetAdsForAdSetOnRepository()
        {
            // Arrange
            var mockAdRepository = new Mock<IAdRepository>();
            var adService = new AdService(mockAdRepository.Object);

            string adSetId = "TestAdSetId";

            // Act
            var result = adService.GetAdsFromAdSet(adSetId);

            // Assert
            mockAdRepository.Verify(x => x.getAdsForAdSet(adSetId), Times.Once);
        }
    }
}