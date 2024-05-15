﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Iss.Entity;
using Iss.Repository;
using System.Data.SqlClient;
using System.Data;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Iss.Tests.Repository
{
        [TestFixture]
        public class InfluencerRepositoryTests
        {
            [Test]
            public void GetInfluencers_ReturnsListOfInfluencers()
            {
                // Arrange

                InfluencerRepository testInfluencerRepository = new InfluencerRepository();

                List<Influencer> result = testInfluencerRepository.GetInfluencers();

                ClassicAssert.IsNotNull(result);

                ClassicAssert.Greater(result.Count, 0); // Ensure there's at least one influencer
                ClassicAssert.AreEqual("1", result[0].influencerId);
                ClassicAssert.AreEqual("Selly", result[0].influencerName);
                ClassicAssert.AreEqual(10000, result[0].followerCount);
                ClassicAssert.AreEqual(1000, result[0].collaborationPrice);
        }
    }
}
