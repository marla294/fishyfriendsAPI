using fishfriends.Biz.Database;
using NUnit.Framework;
using fishfriends.Biz.Models;
using System.Collections.Generic;
using System;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestCompatibilityCheckerHappyPath()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish", "blennies", "anthias" });

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerArgumentError()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish" });

            Assert.Throws<ArgumentException>(() => new CompatibilityChecker().GetCompatibility(fishList));
        }
    }
}