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
    public class RequestServiceTest
    {

        private Request testingRequest = new Request(
            "title", "adOverview", "contentRequirement", "compensation", DateTime.Now, DateTime.Now.AddDays(7), true, true);

        private List<Request> testingRequestList = new List<Request>
        {
            new Request("title1", "adOverview1", "contentRequirement1", "compensation1", DateTime.Now, DateTime.Now.AddDays(7), true, true),
            new Request("title2", "adOverview2", "contentRequirement2", "compensation2", DateTime.Now, DateTime.Now.AddDays(7), true, true),
            new Request("title3", "adOverview3", "contentRequirement3", "compensation3", DateTime.Now, DateTime.Now.AddDays(7), true, true)
        };

        [Fact]
        public void AddRequest_WhenCalled_CallsAddRequestOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.addRequest(testingRequest);

            //Assert
            mockRequestRepository.Verify(x => x.addRequest(testingRequest), Times.Once);
        }

        [Fact]
        public void DeleteRequest_WhenCalled_CallsDeleteRequestOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.deleteRequest(testingRequest);

            //Assert
            mockRequestRepository.Verify(x => x.deleteRequest(testingRequest), Times.Once);
        }

        [Fact]
        public void GetInfluencerId_WhenCalled_CallsGetInfluencerIdOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.getInfluencerId();

            //Assert
            mockRequestRepository.Verify(x => x.getInfluencerId(), Times.Once);
        }

        [Fact]
        public void GetRequestsForInfluencer_WhenCalled_CallsGetRequestsForInfluencerOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.getRequestsForInfluencer();

            //Assert
            mockRequestRepository.Verify(x => x.getRequestsForInfluencer(), Times.Once);
        }

        [Fact]
        public void GetRequestWithTitle_WhenCalled_CallsGetRequestsListOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            requestService.addRequest(testingRequest);

            //Act
            requestService.getRequestWithTitle("title");

            //Assert
            mockRequestRepository.Verify(x => x.getRequestsList(), Times.Once);
        }

        [Fact]
        public void GetRequestsForAdAccount_WhenCalled_CallsGetRequestsForAdAccountOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.getRequestsForAdAccount();

            //Assert
            mockRequestRepository.Verify(x => x.getRequestsForAdAccount(), Times.Once);
        }

        [Fact]
        public void UpdateRequest_WhenCalled_CallsUpdateRequestOnRepository()
        {
            //Arrange
            var mockRequestRepository = new Mock<IRequestRepository>();
            var requestService = new RequestService(mockRequestRepository.Object);

            //Act
            requestService.updateRequest(testingRequest, "newCompensation", "newContentRequirements");

            //Assert
            mockRequestRepository.Verify(x => x.updateRequest(testingRequest), Times.Once);
        }   
    }
}
