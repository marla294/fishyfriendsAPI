using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;
using System;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestGetAllFishCompatibilityHappyPath()
        {
            var testFishList = FishLoader.LoadFishList(new List<string>() { "clown"});
            var testFishPairCompatibilityList = CompatibilityChecker.GetAllFishCompatibility(testFishList);
            var testPair = testFishPairCompatibilityList.FirstOrDefault<FishPairCompatibilityDTO>(pair => pair.FishTwo.Name == "chromis");

            Assert.AreEqual(testPair.Compatibility, "Yes");
        }

    }
}