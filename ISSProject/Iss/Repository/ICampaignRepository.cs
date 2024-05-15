using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface ICampaignRepository
    {
        void addCampaign(Campaign campaignToAdd);
        Campaign getCampaignByName(Campaign campaignToGetByName);
        void addAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet);
        void deleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet);
        void deleteCampaign(Campaign campaignToDelete);
        void updateCampaign(Campaign campaignToUpdate);
    }
}
