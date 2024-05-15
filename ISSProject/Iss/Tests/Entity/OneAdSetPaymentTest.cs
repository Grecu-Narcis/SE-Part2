using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class OneAdSetPaymentTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            int adSetPaymentId = 1;
            int reach = 1000;
            decimal price = 100;

            // Act
            OneAdSetPayment oneAdSetPayment = new OneAdSetPayment(adSetPaymentId, reach, price);

            // Assert
            Assert.Equal(adSetPaymentId, oneAdSetPayment.adSetPaymentId);
            Assert.Equal(reach, oneAdSetPayment.reach);
            Assert.Equal(price, oneAdSetPayment.price);

            // Set
            oneAdSetPayment.adSetPaymentId = 2;
            oneAdSetPayment.reach = 2000;
            oneAdSetPayment.price = 200;

            // Assert
            Assert.Equal(2, oneAdSetPayment.adSetPaymentId);
            Assert.Equal(2000, oneAdSetPayment.reach);
            Assert.Equal(200, oneAdSetPayment.price);
        }
    }
}
