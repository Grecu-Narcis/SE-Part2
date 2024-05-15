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
    public class CollaborationServiceTests
    {
        [Fact]
        public void AddCollaboration_WhenCalled_CallsCreateCollaborationOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            var collaboration = new Collaboration(
            CollaborationId: 1,
            startDate: DateTime.Now,
            status: true,
            contentRequirement: "Content requirement",
            adOverview: "Ad overview",
            collaborationFee: "100",
            days: 7,
            collaborationTitle: "Collaboration Title"
        );

            // Act
            collaborationService.addCollaboration(collaboration);

            // Assert
            mockCollaborationRepository.Verify(x => x.createCollaboration(collaboration), Times.Once);
        }

        [Fact]
        public void GetCollaborationForAdAccount_WhenCalled_CallsGetCollaborationsForAdAccountOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            // Act
            var result = collaborationService.getCollaborationForAdAccount();

            // Assert
            mockCollaborationRepository.Verify(x => x.GetCollaborationsForAdAccount(), Times.Once);
        }

        [Fact]
        public void GetCollaborationForInfluencer_WhenCalled_CallsGetCollaborationsForInfluencerOnRepository()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            // Act
            var result = collaborationService.getCollaborationForInfluencer();

            // Assert
            mockCollaborationRepository.Verify(x => x.getCollaborationsForInfluencer(), Times.Once);
        }

        [Fact]
        public void GetActiveCollaborationForAdAccount_WhenCalled_ReturnsActiveCollaborations()
        {
            // Arrange
            var mockCollaborationRepository = new Mock<IColaborationRepository>();
            var collaborationService = new CollaborationService(mockCollaborationRepository.Object);

            var activeCollaborations = new List<Collaboration>(); // Add some active collaborations
            mockCollaborationRepository.Setup(x => x.GetCollaborationsForAdAccount()).Returns(activeCollaborations);

            // Act
            var result = collaborationService.getActiveCollaborationForAdAccount();

            // Assert
            Assert.Equal(activeCollaborations, result);
        }
    }
}
