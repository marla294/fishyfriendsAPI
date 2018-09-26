using NUnit.Framework;
using System.Collections.Generic;
using fishfriends.Biz.Database;

namespace fishfriends.Tests.Service.Controllers
{
    [TestFixture]
    public class CompatibilityControllerTests
    {
        [Test]
        public void TestCompatibilityControllerGetHappyPath()
        {
            var fishList = FishFactory.LoadFishList(new List<string>() { "clown", "blennies", "anthias" });

            Assert.AreEqual(new CompatibilityChecker().GetCompatibility(fishList), 10);
        }
    }
}
