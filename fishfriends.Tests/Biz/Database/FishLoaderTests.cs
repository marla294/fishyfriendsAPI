using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class FishLoaderTests
    {
        [Test]
        public void TestFishLoader()
        {
            var testFishList = new FishLoader().FishList;
            var namesLoadedCorrectly = testFishList.FirstOrDefault(fish => fish.Name == "crabs, shrimps and snails");
            var idsLoadedCorrectly = testFishList.FirstOrDefault(fish => fish.Id == 31);

            Assert.AreEqual(testFishList.Count, 31);
            Assert.IsNotNull(namesLoadedCorrectly);
            Assert.IsNotNull(idsLoadedCorrectly);
        }
    }
}
