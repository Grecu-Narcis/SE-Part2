using Iss.Entity;

namespace Iss.Repository
{
    public interface IPaymentRepository
    {
        void addOneAd();
        void addOneAdSet();
        void addOneCampaign();
        void removeOneAd();
        void removeOneCampaign();
        void removeOneAdSet();
        void addSubscription(string name);
    }
}
