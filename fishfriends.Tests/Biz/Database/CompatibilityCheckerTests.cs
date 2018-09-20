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
            var fishOne = new Fish() { Name = "batfish" };
            var fishTwo = new Fish() { Name = "blennies" };
            var fishThree = new Fish() { Name = "anthias" };
            var fishList = new List<Fish>() { fishOne, fishTwo, fishThree};

            var compatibility = new CompatibilityChecker().GetCompatibility(fishList);

            Assert.AreEqual(8, compatibility);
        }
    }
}
