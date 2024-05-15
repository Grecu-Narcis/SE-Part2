using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface IAdService
    {
        public void addAd(Ad adToAdd);
        public List<Ad> getAdsThatAreNotInAdSet();
        public void updateAd(Ad adToUpdate);
        public Ad getAdByName(string adName);
        public void deleteAd(Ad adToDelete);
        public List<Ad> GetAdsFromAdSet(string adSetId);

    }
}
