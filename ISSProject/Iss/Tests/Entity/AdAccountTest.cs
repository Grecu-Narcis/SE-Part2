using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class AdAccountTest
    {
        [Fact]
        public void Constructor_WithAllParameters_CorrectInitialization()
        {
            // Arrange
            string id = "1";
            string nameOfCompany = "Company";
            string domainOfActivity = "Domain";
            string siteUrl = "Site";
            string password = "Password";
            string taxIdentificationNumber = "TIN";
            string headquartersLocation = "Location";
            string authorisingInstituion = "Institution";

            // Act
            AdAccount adAccount = new AdAccount(id, nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstituion);

            // Assert
            Assert.Equal(id, adAccount.adAccountId);
            Assert.Equal(nameOfCompany, adAccount.nameOfCompany);
            Assert.Equal(domainOfActivity, adAccount.domainOfActivity);
            Assert.Equal(siteUrl, adAccount.siteUrl);
            Assert.Equal(password, adAccount.password);
            Assert.Equal(taxIdentificationNumber, adAccount.taxIdentificationNumber);
            Assert.Equal(headquartersLocation, adAccount.headquartersLocation);
            Assert.Equal(authorisingInstituion, adAccount.authorisingInstituion);
        }

        [Fact]
        public void Constructor_WithSelectedParameters_CorrectInitialization()
        {
            // Arrange
            string nameOfCompany = "Company";
            string domainOfActivity = "Domain";
            string siteUrl = "Site";
            string password = "Password";
            string taxIdentificationNumber = "TIN";
            string headquartersLocation = "Location";
            string authorisingInstituion = "Institution";

            // Act
            AdAccount adAccount = new AdAccount(nameOfCompany, domainOfActivity, siteUrl, password, taxIdentificationNumber, headquartersLocation, authorisingInstituion);

            // Assert
            Assert.Equal(nameOfCompany, adAccount.nameOfCompany);
            Assert.Equal(domainOfActivity, adAccount.domainOfActivity);
            Assert.Equal(siteUrl, adAccount.siteUrl);
            Assert.Equal(password, adAccount.password);
            Assert.Equal(taxIdentificationNumber, adAccount.taxIdentificationNumber);
            Assert.Equal(headquartersLocation, adAccount.headquartersLocation);
            Assert.Equal(authorisingInstituion, adAccount.authorisingInstituion);
        }
    }
}
