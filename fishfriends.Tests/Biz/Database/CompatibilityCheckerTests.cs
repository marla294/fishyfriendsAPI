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
            var fishList = new LoadedFishList(new List<string>() { "batfish", "blennies"}).FishList;

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(7, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPathMoreThan2Fish()
        {
            var fishList = new LoadedFishList(new List<string>() { "batfish", "blennies", "anthias" }).FishList;

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerHappyPath2SameFish()
        {
            var fishList = new LoadedFishList(new List<string>() { "batfish", "batfish" }).FishList;

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(5, compatibility);
        }

        [Test]
        public void TestCompatibilityCheckerNotEnoughArgumentError()
        {
            var fishList = new LoadedFishList(new List<string>() { "batfish" }).FishList;

            Assert.Throws<ArgumentException>(() => new CompatibilityChecker().GetCompatibility(fishList));
        }

    }
}