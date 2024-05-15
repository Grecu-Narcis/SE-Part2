using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IAdRepository
    {
        public void addAd(Ad adToAdd);
        public Ad getAdByName(string adName);
        public List<Ad> getAdsThatAreNotInAdSet();
        public List<Ad> getAdsForAdSet(string adSetId);
        public void updateAd(Ad adToUpdate);
        public void deleteAd(Ad adToDelete);
    }
}
