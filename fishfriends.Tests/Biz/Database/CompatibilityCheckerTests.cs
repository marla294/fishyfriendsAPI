using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestCompatibilityCheckerHappyPath2Fish()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "batfish", "blennies" });

            var compatibility = CompatibilityChecker.GetCompatibility(fishList);

            Assert.AreEqual(7, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPathMoreThan2Fish()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "batfish", "blennies", "anthias" });

            var compatibility = CompatibilityChecker.GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPath2SameFish()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "batfish", "batfish" });

            var compatibility = CompatibilityChecker.GetCompatibility(fishList);

            Assert.AreEqual(5, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerNotEnoughArgumentError()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "batfish" });

            Assert.Throws<ArgumentException>(() => CompatibilityChecker.GetCompatibility(fishList));
        }

    }
}