using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IAdAccountRepository
    {
        public AdAccount getAdAccount(string nameOfCompany, string password);
        public void addAdAccount(AdAccount adAccountToAdd);
        public List<Ad> getAdsForCurrentUser();
        public List<AdSet> getAdSetsForCurrentUser();
        public List<Campaign> getCampaignsForCurrentUser();
        public void editAdAccount(String nameOfCompany, String URL, String password, String location);
    }
}
