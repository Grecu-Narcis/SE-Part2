using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Service
{
    public interface IPaymentService
    {
        void addOneAd();
        void addOneAdSet();
        void addOneCampaign();
        void addBasicSubscription();
        void addSilverSubscription();
        void addGoldSubscription();
    }
}
