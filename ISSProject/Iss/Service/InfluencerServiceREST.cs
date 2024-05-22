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
    public class InfluencerServiceREST
    {
        private readonly HttpClient httpClient;
        private IInfluencerRepository influencerRepository = new InfluencerRepository();

        public InfluencerServiceREST(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public List<Influencer> GetInfluencers()
        {
            var response = httpClient.GetAsync("api/Influencer/influencers").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<Influencer>>().Result;
            }
            else
            {
                throw new Exception($"Failed to retrieve influencers: {response.ReasonPhrase}");
            }
        }
    }
}
