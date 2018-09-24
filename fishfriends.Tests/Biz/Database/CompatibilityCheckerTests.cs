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
        public void TestCompatibilityCheckerHappyPath2Fish()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish", "blennies"});

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(7, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPathMoreThan2Fish()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish", "blennies", "anthias" });

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPath2SameFish()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish", "batfish" });

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(5, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerNotEnoughArgumentError()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish" });

            Assert.Throws<ArgumentException>(() => new CompatibilityChecker().GetCompatibility(fishList));
        }

        [Test]
        public void TestCompatibilityCheckerFishNameArgumentError()
        {
            var fishOne = new Fish(1, "I am not a valid fish name");
            var fishTwo = new FishCrafter().CraftSingleFish("anthias");
            List<Fish> fishList = new List<Fish>() { fishOne, fishTwo };

            Assert.Throws<ArgumentException>(() => new CompatibilityChecker().GetCompatibility(fishList));
        }
    }
}