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
            var selectedFishList = FishLoader.LoadFishList(new List<string>() { "clown", "damsels" });
            var allFishCompatibility = CompatibilityChecker.GetAllFishCompatibility(selectedFishList);
            var fishPair = allFishCompatibility.FirstOrDefault(pair => pair.MainFish.Name == "anthias");

            Assert.AreEqual(allFishCompatibility.Count, 31);
            Assert.AreEqual(fishPair.TotalCompatibility, "Yes");
        }

    }
}