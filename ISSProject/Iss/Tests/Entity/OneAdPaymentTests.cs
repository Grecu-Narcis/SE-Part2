using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class OneAdPaymentTests
    {
        [Fact]
        public void getNextID_NoPreviousPayments_ReturnsCorrectNextID()
        {
            // Arrange
            var account = new AdAccount("TestCompany", "TestDomain", "https://example.com", "password", "123456789", "TestLocation", "TestInstitution");

            var payment = new OneAdPayment(0, 0, 0);
            payment.account = account;

            // Act
            var nextID = payment.getNextID();

            // Assert
            Assert.Equal(1, nextID); // adding payments not implemented
        }

        [Fact]
        public void GetterProperties_Initialization_ReturnCorrectValues()
        {
            // Arrange
            int paymentId = 1;
            int reach = 1000;
            decimal price = 50;

            var payment = new OneAdPayment(paymentId, reach, price);

            // Act
            int retrievedPaymentId = payment.paymentId;
            int retrievedReach = payment.reach;
            decimal retrievedPrice = payment.price;

            // Assert
            Assert.Equal(paymentId, retrievedPaymentId);
            Assert.Equal(reach, retrievedReach);
            Assert.Equal(price, retrievedPrice);
        }
    }
}
