using Iss.Entity;
using Iss.Repository;
using Iss.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Iss.Service
{
    public class AdAccountService: IAdAccountService 
    {
        private IAdAccountRepository adAccountRepository;

        public AdAccountService(IAdAccountRepository adAccountRepository)
        {
            this.adAccountRepository = adAccountRepository;
        }

        public AdAccountService()
        {
            this.adAccountRepository = new AdAccountRepository();
        }

        public void login(string username, string password)
        {
            AdAccount adAccount = adAccountRepository.getAdAccount(username, password);
            if (adAccount != null)
            {
                User.User.getInstance().Id = adAccount.adAccountId;
                User.User.getInstance().Name = adAccount.nameOfCompany;
                User.User.getInstance().Password = adAccount.password;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }

        public AdAccount getAccount()
        {
            return adAccountRepository.getAdAccount(User.User.getInstance().Name, User.User.getInstance().Password);
        }

        public List<Ad> getAdsForCurrentUser() {
            return adAccountRepository.getAdsForCurrentUser();
        }

        public List<AdSet> getAdSetsForCurrentUser()
        {
            return adAccountRepository.getAdSetsForCurrentUser();
        }

        public List<Campaign> getCampaignsForCurrentUser()
        {
            return adAccountRepository.getCampaignsForCurrentUser();
        }

        public void addAdAccount(AdAccount account)
        {
            this.adAccountRepository.addAdAccount(account);
        }

        public void editAdAccount(String nameOfCompany, String URL, String password, String location)
        {
            this.adAccountRepository.editAdAccount(nameOfCompany, URL, password, location);
        }
    }
}
