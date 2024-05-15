using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneCampaignPayment: IOneTimePayment
    {
        public int campaignPaymentId { get; set; }
        public int reach { get; set; }
        public decimal price { get; set; }

        public OneCampaignPayment(int paymentId, int reach, decimal price) {
            this.campaignPaymentId = paymentId;
            this.reach = reach;
            this.price = price;
        }
    }
}
