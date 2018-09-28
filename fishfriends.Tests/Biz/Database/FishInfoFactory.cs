using NUnit.Framework;
using fishfriends.Biz.Database;

namespace fishfriends.Tests.Biz.Database
{
    [TestFixture]
    public class FishInfoFactoryTests
    {
        [Test]
        public void TestFishInfoLoadAll()
        {
            //var testFishInfoList = FishInfoFactory.LoadAll();
        }

        [Test]
        public void TestFishInfoLoadSingle()
        {
            var testFishInfo = FishInfoFactory.LoadSingle("blennies");

            Assert.AreEqual(testFishInfo.Fish.Name, "blennies");
            Assert.AreEqual(testFishInfo.Info.Count, 3);
        }
    }
}
