using NUnit.Framework;
using System.Collections.Generic;
using fishfriends.Biz.Database;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Tests.Service.Controllers
{
    [TestFixture]
    public class CompatibilityControllerTests
    {
        [Test]
        public void TestCompatibilityControllerGetHappyPath()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "clown", "blennies", "anthias" });
            var fishPairCompatibilityList = CompatibilityChecker.GetFishPairCompatibility(fishList);
            var clownPair = fishPairCompatibilityList.FirstOrDefault<FishPairCompatibility>(pair => pair.FishOne.Name == "clown");

            Assert.AreEqual(fishPairCompatibilityList.Count, 6);
            Assert.IsNotNull(clownPair);
        }
    }
}
