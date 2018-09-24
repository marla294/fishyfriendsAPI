using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class FishLoaderTests
    {
        [Test]
        public void TestLoadedFishHappyPath()
        {
            var testLoadedFish = new LoadedFish("anthias");

            Assert.AreEqual(testLoadedFish.Id, 3);
        }
    }
}
