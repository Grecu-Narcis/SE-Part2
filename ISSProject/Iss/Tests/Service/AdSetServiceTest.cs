using Iss.Entity;
using Iss.Repository;
using Iss.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Service
{
    public class AdSetServiceTest
    {
        
        private Ad testingAd = new Ad("1","test-name", "test-photo", "test-description","test-link");

        private AdSet testingAdSet = new AdSet(id: "1",
                                    name: "New AdSet",
                                    ads: new List<Ad>{
            new Ad("2","test-name2", "test-photo2", "test-description2","test-link2"),
            new Ad("3","test-name3", "test-photo3", "test-description3","test-link3")
        },
                                    targetAudience: "Gen Z");

        [Fact]
        public void AddSet_WhenCalled_CallsAddSetOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.addAdSet(testingAdSet);

            // Assert
            mockAdSetRepository.Verify(x => x.addAdSet(testingAdSet), Times.Once);
        }

        [Fact]
        public void AddAdToAdSet_WhenCalled_CallsAddAdToAdSetOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.addAdToAdSet(testingAdSet, testingAd);

            // Assert
            mockAdSetRepository.Verify(x => x.addAdToAdSet(testingAdSet, testingAd), Times.Once);
        }

        [Fact]
        public void RemoveAdFromAdSet_WhenCalled_CallsRemoveAdFromAdSetOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.removeAdFromAdSet(testingAdSet, testingAd);

            // Assert
            mockAdSetRepository.Verify(x => x.removeAdFromAdSet(testingAdSet, testingAd), Times.Once);
        }

        [Fact]
        public void GetAdSetsThatAreNotInCampaign_WhenCalled_CallsGetAdSetsThatAreNotInCampaignOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.getAdSetsThatAreNotInCampaign();

            // Assert
            mockAdSetRepository.Verify(x => x.getAdSetsThatAreNotInCampaign(), Times.Once);
        }

        [Fact]
        public void GetAdSetsInCampaign_WhenCalled_CallsGetAdSetsInCampaignOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.getAdSetsInCampaign("1");

            // Assert
            mockAdSetRepository.Verify(x => x.getAdSetsInCampaign("1"), Times.Once);
        }

        [Fact]
        public void GetAdSetByName_WhenCalled_CallsGetAdSetByNameOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.getAdSetByName(testingAdSet);

            // Assert
            mockAdSetRepository.Verify(x => x.getAdSetByName(testingAdSet), Times.Once);
        }

        [Fact]
        public void UpdateAdSet_WhenCalled_CallsUpdateAdSetOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.updateAdSet(testingAdSet);

            // Assert
            mockAdSetRepository.Verify(x => x.updateAdSet(testingAdSet), Times.Once);
        }

        [Fact]
        public void DeleteAdSet_WhenCalled_CallsDeleteAdSetOnRepository()
        {
            // Arrange
            var mockAdSetRepository = new Mock<IAdSetRepository>();
            var adSetService = new AdSetService(mockAdSetRepository.Object);

            // Act
            adSetService.deleteAdSet(testingAdSet);

            // Assert
            mockAdSetRepository.Verify(x => x.deleteAdSet(testingAdSet), Times.Once);
        }
    
    }
}
