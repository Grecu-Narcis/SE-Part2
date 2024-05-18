using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;
using Iss.Repository;

namespace Iss.Service
{
    public class AdSetService
    {
        private IAdSetRepository adSetRepository = new AdSetRepository();

        public AdSetService()
        {
        }

        public AdSetService(IAdSetRepository adSetRepository)
        {
            this.adSetRepository = adSetRepository;
        }

        public void AddAdSet(AdSet adSet)
        {
            adSetRepository.addAdSet(adSet);

            adSet = adSetRepository.getAdSetByName(adSet);

            foreach (Ad ad in adSet.Ads)
            {
                adSetRepository.addAdToAdSet(adSet, ad);
            }
        }

        public void AddAdToAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.addAdToAdSet(adSet, ad);
        }

        public void RemoveAdFromAdSet(AdSet adSet, Ad ad)
        {
            this.adSetRepository.removeAdFromAdSet(adSet, ad);
        }

        public List<AdSet> GetAdSetsThatAreNotInCampaign()
        {
            return adSetRepository.getAdSetsThatAreNotInCampaign();
        }

        public List<AdSet> GetAdSetsInCampaign(string id)
        {
            return adSetRepository.getAdSetsInCampaign(id);
        }

        public AdSet GetAdSetByName(AdSet adSet)
        {
            return adSetRepository.getAdSetByName(adSet);
        }

        public void UpdateAdSet(AdSet adSet)
        {
            this.adSetRepository.updateAdSet(adSet);
        }

        public void DeleteAdSet(AdSet adSet)
        {
            this.adSetRepository.deleteAdSet(adSet);
        }
    }
}
