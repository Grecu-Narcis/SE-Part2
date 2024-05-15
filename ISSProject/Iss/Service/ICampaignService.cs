using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface ICampaignService
    {
        public void addCampaign(Campaign campaignToAdd);
        public Campaign getCampaignByName(Campaign campaignToGetByName);
        public void deleteCampaign(Campaign campaignToDelete);
        public void addAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet);
        public void deleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet);
        public void updateCampaign(Campaign campaignToUpdate);
    }
}
