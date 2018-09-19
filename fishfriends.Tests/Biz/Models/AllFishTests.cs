using System.Collections.Generic;
using fishfriends.Biz.Models;
using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;

namespace fishfriends.Tests.Biz.Models
{
    [TestFixture]
    public class AllFishTests
    {
        [Test]
        public void TestAllFish()
        {
            var testFishList = new AllFish().FishList;
            var namesLoadedCorrectly = testFishList.FirstOrDefault(fish => fish.Name == "crabs, shrimps and snails");
            var idsLoadedCorrectly = testFishList.FirstOrDefault(fish => fish.Id == 31);

            Assert.AreEqual(testFishList.Count, 31);
            Assert.IsNotNull(namesLoadedCorrectly);
            Assert.IsNotNull(idsLoadedCorrectly);
        }
    }
}
