using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface IAdSetService
    {
        public void addAdSet(AdSet adSetToAdd);
        public void addAdToAdSet(AdSet adSet, Ad adToAdd);
        public void removeAdFromAdSet(AdSet adSet, Ad adToRemove);
        public List<AdSet> getAdSetsThatAreNotInCampaign();
        public List<AdSet> getAdSetsInCampaign(string id);
        public AdSet getAdSetByName(AdSet adSet);
        public void updateAdSet(AdSet adSetToUpdate);
        public void deleteAdSet(AdSet adSetToDelete);
    }
}
