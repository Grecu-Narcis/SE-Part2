﻿using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Iss.Tests.Entity
{
    public class CamapaignTest
    {
        [Fact]
        public void Constructor_WithoutId_CorrectInitialization()
        {
            // Arrange
            string campaignName = "Campaign Name";
            DateTime startDate = new DateTime(2021, 1, 1);
            int duration = 30;

            // Act
            Campaign campaign = new Campaign(campaignName, startDate, duration);

            // Assert
            Assert.Equal(campaignName, campaign.campaignName);
            Assert.Equal(startDate, campaign.startDate);
            Assert.Equal(duration, campaign.duration);
            Assert.Null(campaign.adSets);
            Assert.Equal("CAMPAIGN NAME: " + campaignName + "-" + "START DATE: " + startDate.ToString() + "-" + "DURATION: " + duration, campaign.ToString());
        }

        [Fact]
        public void Constructor_WithAllParametersAndAdSets_CorrectInitialization()
        {
            // Arrange
            string campaignName = "Campaign Name";
            DateTime startDate = new DateTime(2021, 1, 1);
            int duration = 30;
            List<AdSet> adSets = new List<AdSet>();

            // Act
            Campaign campaign = new Campaign(campaignName, startDate, duration, adSets);

            // Assert
            Assert.Equal(campaignName, campaign.campaignName);
            Assert.Equal(startDate, campaign.startDate);
            Assert.Equal(duration, campaign.duration);
            Assert.Equal(adSets, campaign.adSets);
            Assert.Equal("CAMPAIGN NAME: " + campaignName + "-" + "START DATE: " + startDate.ToString() + "-" + "DURATION: " + duration, campaign.ToString());
        }

        [Fact]
        public void Constructor_WithId_CorrectInitialization()
        {
            // Arrange
            string campaignId = "1";
            string campaignName = "Campaign Name";
            DateTime startDate = new DateTime(2021, 1, 1);
            int duration = 30;

            // Act
            Campaign campaign = new Campaign(campaignId, campaignName, startDate, duration);

            // Assert
            Assert.Equal(campaignId, campaign.campaignId);
            Assert.Equal(campaignName, campaign.campaignName);
            Assert.Equal(startDate, campaign.startDate);
            Assert.Equal(duration, campaign.duration);
            Assert.Null(campaign.adSets);
            Assert.Equal("CAMPAIGN NAME: " + campaignName + "-" + "START DATE: " + startDate.ToString() + "-" + "DURATION: " + duration, campaign.ToString());
        }
    }
}
