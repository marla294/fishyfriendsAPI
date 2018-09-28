using NUnit.Framework;
using fishfriends.Biz.Database;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class FishInfoFactoryTests
    {
        [Test]
        public void TestFishInfoLoadSingle()
        {
            var testFishInfo = FishInfoFactory.LoadInfoSingleFish("blennies");

            Assert.AreEqual(testFishInfo.Fish.Name, "blennies");
            Assert.AreEqual(testFishInfo.Info.Count, 3);
        }
    }
}
