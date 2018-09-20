using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;
using fishfriends.Biz.Models;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class CompatibilityCheckerTests
    {
        [Test]
        public void TestCompatibilityChecker()
        {
            var compatibility = new CompatibilityChecker().GetCompatibility(new Fish() { Name = "anthias" }, new Fish() { Name = "eels" });

            Assert.AreEqual(5, compatibility);
        }
    }
}
