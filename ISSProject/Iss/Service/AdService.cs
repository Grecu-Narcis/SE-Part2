using Iss.Repository;
using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal class AdService
    {
        private IAdRepository adRepository;
        public AdService(IAdRepository adRepository)
        {
            this.adRepository = adRepository;
        }

        public AdService()
        {
            this.adRepository = new AdRepository();
        }

        public void addAd(Ad adToAdd)
        {
            this.adRepository.addAd(adToAdd);
        }

        public List<Ad> getAdsThatAreNotInAdSet()
        {
            return this.adRepository.getAdsThatAreNotInAdSet();
        }

        public void updateAd(Ad adToUpdate)
        {
            this.adRepository.updateAd(adToUpdate);
        }

        public Ad getAdByName(string adName)
        {
            return this.adRepository.getAdByName(adName);   
        }

        public void deleteAd(Ad adToDelete)
        {
            this.adRepository.deleteAd(adToDelete);
        }

        public List<Ad> GetAdsFromAdSet(string adSetId)
        {
            return this.adRepository.getAdsForAdSet(adSetId);
        }
    }
}
