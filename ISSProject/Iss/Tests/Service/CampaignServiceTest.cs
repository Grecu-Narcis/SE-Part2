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
    public class CampaignServiceTest
    {

        private Campaign testingCampaign = new Campaign(campaignId: "1",
                                        campaignName: "New Campaign",
                                        startDate: DateTime.Now,
                                        duration: 50);
        private AdSet testingAdSet = new AdSet(adSetId: "1",
                                    name: "New AdSet",
                                    targetAudience: "Gen Z");

        [Fact]
        public void AddCampaign_WhenCalled_CallsAddCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.addCampaign(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.addCampaign(testingCampaign), Times.Once);
        }

        [Fact]
        public void GetCampaignByName_WhenCalled_CallsGetCampaignByNameOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.getCampaignByName(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.getCampaignByName(testingCampaign), Times.Once);
        }

        [Fact]
        public void DeleteCampaign_WhenCalled_CallsDeleteCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.deleteCampaign(testingCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.deleteCampaign(testingCampaign), Times.Once);
        }

        [Fact]
        public void AddAdSetToCampaign_WhenCalled_CallsAddAdSetToCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.addAdSetToCampaign(testingCampaign, testingAdSet);

            // Assert
            mockCampaignRepository.Verify(x => x.addAdSetToCampaign(testingCampaign, testingAdSet), Times.Once);
        }

        [Fact]
        public void DeleteAdSetFromCampaign_WhenCalled_CallsDeleteAdSetFromCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            // Act
            campaignService.deleteAdSetFromCampaign(testingCampaign, testingAdSet);

            // Assert
            mockCampaignRepository.Verify(x => x.deleteAdSetFromCampaign(testingCampaign, testingAdSet), Times.Once);
        }

        [Fact]
        public void UpdateCampaign_WhenCalled_CallsUpdateCampaignOnRepository()
        {
            // Arrange
            var mockCampaignRepository = new Mock<ICampaignRepository>();
            var campaignService = new CampaignService(mockCampaignRepository.Object);

            var updatedCampaign = new Campaign(campaignId: "1",
                                               campaignName: "Updated Campaign",
                                               startDate: DateTime.Now,
                                               duration: 51);

            // Act
            campaignService.updateCampaign(updatedCampaign);

            // Assert
            mockCampaignRepository.Verify(x => x.updateCampaign(updatedCampaign), Times.Once);
        }   
    }
}
