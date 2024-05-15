using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class OneAdSetPayment: IOneTimePayment
    {
        public int adSetPaymentId { get; set; }
        public int reach { get; set; }
        public decimal price { get; set; } 

        public OneAdSetPayment(int paymentId, int reach, decimal price) {
            this.adSetPaymentId = paymentId;
            this.reach = reach;
            this.price = price;
        }
    }
}
