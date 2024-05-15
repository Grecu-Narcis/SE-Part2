using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IInfluencerRepository
    {
        public List<Influencer> GetInfluencers();
    }
}
