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
        public void TestCompatibilityCheckerHappyPath()
        {
            var testFishList = FishLoader.LoadFishList(new List<string>() { "clown", "blennies", "anthias" });
            var testFishPairCompatibilityList = CompatibilityChecker.GetFishPairCompatibility(testFishList);
            var testPair = testFishPairCompatibilityList.FirstOrDefault<FishPairCompatibilityDTO>(pair => pair.FishOne.Name == "clown");

            Assert.AreEqual(testFishPairCompatibilityList.Count, 6);
            Assert.IsNotNull(testPair);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPath2SameFish()
        {
            var testFishList = FishLoader.LoadFishList(new List<string>() { "batfish", "batfish" });
            var testFishPairCompatibilityList = CompatibilityChecker.GetFishPairCompatibility(testFishList);
            var testNotBatfishPair = testFishPairCompatibilityList.FirstOrDefault<FishPairCompatibilityDTO>(pair => pair.FishOne.Name != "batfish");

            Assert.AreEqual(testFishPairCompatibilityList.Count, 2);
            Assert.IsNull(testNotBatfishPair);
        }

        [Test]
        public void TestCompatibilityCheckerNotEnoughArgumentError()
        {
            var testFishList = FishLoader.LoadFishList(new List<string>() { "batfish" });

            Assert.Throws<ArgumentException>(() => CompatibilityChecker.GetFishPairCompatibility(testFishList));
        }

    }
}