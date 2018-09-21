using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;
using fishfriends.Biz.Models;
using System.Collections.Generic;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestCompatibilityChecker()
        {
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { "batfish", "blennies", "anthias" });

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }
    }
}
