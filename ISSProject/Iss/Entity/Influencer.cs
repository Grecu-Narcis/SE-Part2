using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Influencer
    {
        public string influencerId { get; set;}
        public String influencerName { get; set;}
        public int followerCount { get; set;}
        public int collaborationPrice { get; set;}

        public Influencer(string userId, string name, int followerCount, int collaborationPrice)
        {
            this.influencerId = userId;
            this.influencerName = name;
            this.followerCount = followerCount;
            this.collaborationPrice = collaborationPrice;
        }

        public Influencer(string name, int followerCount, int collaborationPrice)
        {
            this.influencerName = name;
            this.followerCount = followerCount;
            this.collaborationPrice = collaborationPrice;
        }

        public override string ToString()
        {
            return influencerName + " with " + followerCount + " followers. Costs: " + collaborationPrice + "$";
        }
    }
}
