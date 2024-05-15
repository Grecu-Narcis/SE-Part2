using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    internal interface IAdAccountService
    {
        public void login(string email, string password);
        public AdAccount getAccount();
        public List<Ad> getAdsForCurrentUser();
        public List<AdSet> getAdSetsForCurrentUser();
        public List<Campaign> getCampaignsForCurrentUser();
        public void addAdAccount(AdAccount addAccount);
        public void editAdAccount(String nameOfCompany, String URL, String password, String location);
    }
}
