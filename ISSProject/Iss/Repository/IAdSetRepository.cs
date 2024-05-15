using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IAdSetRepository
    {
        public void addAdSet(AdSet adSetToAdd);
        public void deleteAdSet(AdSet adSetToDelete);
        public void updateAdSet(AdSet adSetToUpdate);
        public AdSet getAdSetByName(AdSet adSet);
        public void addAdToAdSet(AdSet adSet, Ad adToAdd);
        public void removeAdFromAdSet(AdSet adSet, Ad adToRemove);
        public List<AdSet> getAdSetsThatAreNotInCampaign();
        public List<AdSet> getAdSetsInCampaign(string id);
    }
}
