using Iss.Entity;
using Iss.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal class CampaignService : ICampaignService
    {
        private ICampaignRepository campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public CampaignService()
        {
            this.campaignRepository = new CampaignRepository();
        }

        public void addCampaign(Campaign campaignToAdd)
        {
            this.campaignRepository.addCampaign(campaignToAdd);

            Campaign campaignFromRepository = campaignRepository.getCampaignByName(campaignToAdd);

            if (campaignFromRepository == null)
            {
                Console.WriteLine("Campaign with the specified name was not found.");
                return;
            }

            List<AdSet> currentAdSet = campaignFromRepository.adSets;

            foreach (AdSet adSet in currentAdSet)
            {
                campaignRepository.addAdSetToCampaign(campaignFromRepository, adSet);
            }
        }

        public Campaign getCampaignByName(Campaign campaignToGetByName)
        {
            Campaign campaignToReturn =  campaignRepository.getCampaignByName(campaignToGetByName);
            return campaignToReturn;
        }

        public void deleteCampaign(Campaign campaignToDelete)
        {
            campaignRepository.deleteCampaign(campaignToDelete);
        }

        public void addAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            campaignRepository.addAdSetToCampaign(campaignToAddAdSet, adSet);
        }

        public void deleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            campaignRepository.deleteAdSetFromCampaign(campaignToDeleteAdSet, adSet);
        }

        public void updateCampaign(Campaign campaignToUpdate)
        {
            campaignRepository.updateCampaign(campaignToUpdate);
        }
    }
}
