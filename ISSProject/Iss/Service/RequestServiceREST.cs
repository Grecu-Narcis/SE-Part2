using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    public class RequestServiceREST
    {
        private readonly HttpClient httpClient;
        private IRequestRepository requestRepository = new RequestRepository();

        public RequestServiceREST(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public void AddRequest(Request requestToAdd)
        {
            var response = httpClient.PostAsJsonAsync("api/Request/addRequest", requestToAdd).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add account: {response.ReasonPhrase}");
            }
        }

        public void DeleteRequest(Request requestToDelete)
        {
            var response = httpClient.DeleteAsync($"api/Request/deleteRequest/{requestToDelete.CollaborationTitle}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add account: {response.ReasonPhrase}");
            }
        }

        public string GetInfluencerId()
        {
            var response = httpClient.GetAsync("api/influencerId").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add account: {response.ReasonPhrase}");
            }
            return response.Content.ToString();
        }

        public List<Request> GetRequestsForInfluencer()
        {
            var response = httpClient.GetAsync("api/requestsForInfluencer").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch data: {response.ReasonPhrase}");
            }
            return response.Content.ReadFromJsonAsync<List<Request>>().Result;
        }

        public Request GetRequestWithTitle(string title)
        {
            // parse the requestToDelete list and find the requestToDelete with given title
            var response = httpClient.GetAsync($"api/requestWithTitle/{title}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch data: {response.ReasonPhrase}");
            }
            var requestsList = response.Content.ReadFromJsonAsync<List<Request>>().Result;

            if (requestsList == null)
            {
                return null;
            }

            foreach (Request request in requestsList)
            {
                if (request.CollaborationTitle == title)
                {
                    return request;
                }
            }
            return null;
        }

        public List<Request> GetRequestsForAdAccount()
        {
            var response = httpClient.GetAsync("api/requestsForAdAccount").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch data: {response.ReasonPhrase}");
            }
            return response.Content.ReadFromJsonAsync<List<Request>>().Result;
        }

        public void UpdateRequest(Request requestToUpdate, string newCompensation, string newContentRequirements)
        {
            requestToUpdate.Compensation = newCompensation;
            requestToUpdate.ContentRequirements = newContentRequirements;
            this.requestRepository.UpdateRequest(requestToUpdate);
            var response = httpClient.PutAsJsonAsync("api/Request/updateRequest", requestToUpdate).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add account: {response.ReasonPhrase}");
            }
        }
    }
}
