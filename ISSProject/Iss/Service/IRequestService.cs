using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface IRequestService
    {
        public void addRequest(Request requestToAdd);
        public void deleteRequest(Request requestToDelete);
        public int getInfluencerId();
        public List<Request> getRequestsForInfluencer();
        public Request getRequestWithTitle(string title);
        public List<Request> getRequestsForAdAccount();
        public void updateRequest(Request requestToUpdate, string newCompensation, string newContentRequirements);
    }
}
