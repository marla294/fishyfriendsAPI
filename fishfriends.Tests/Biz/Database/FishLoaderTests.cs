using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class FishLoaderTests
    {
        [Test]
        public void TestFishFactoryLoadAll()
        {
            var fishList = FishFactory.LoadAll();

            Assert.AreEqual(fishList.Count, 31);
        }

        [Test]
        public void TestFishFactoryLoadSingleHappyPath()
        {
            var testFish = FishFactory.LoadSingle("blennies");

            Assert.AreEqual(testFish.Name, "blennies");
            Assert.AreEqual(testFish.Id, 6);
        }

        [Test]
        public void TestFishFactoryLoadSingleInvalidFish()
        {
            var testFish = FishFactory.LoadSingle("1=1");

            Assert.IsNull(testFish);
        }

        [Test]
        public void TestFishFactoryLoadFishListHappyPath()
        {
            var testNameList = new List<string>() { "batfish", "anthias", "clown", "cardinals", "chromis", "blennies", "batfish" };
            var testFishList = FishFactory.LoadFishList(testNameList);

            foreach (var fish in testFishList)
            {
                Assert.IsNotNull(fish);
                Assert.AreNotEqual(fish.Id, 0);
                Assert.AreEqual(testNameList.FirstOrDefault(f => f == fish.Name), fish.Name);
                Assert.IsNotNullOrEmpty(fish.Id.ToString());
            }
        }
    }
}
