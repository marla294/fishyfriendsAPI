using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestGetAllFishCompatibilityHappyPath()
        {
            var selectedFishes = new List<string>() { "clown", "damsels" };
            var selectedFishList = FishLoader.LoadFishList(selectedFishes);
            var allFishCompatibility = CompatibilityChecker.GetAllFishCompatibility(selectedFishList);
            var anthiasFishCompatibility = allFishCompatibility.FirstOrDefault(pair => pair.MainFish.Name == "anthias");

            Assert.AreEqual(allFishCompatibility.Count, 31);
            Assert.AreEqual(anthiasFishCompatibility.WorstCompatibility, "Yes");
        }

    }
}