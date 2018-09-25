using NUnit.Framework;
using fishfriends.Biz.Database;
using System.Linq;

namespace fishfriends.Tests.Service.Controllers
{
    [TestFixture]
    public class FishControllerTests
    {
        [Test]
        public void TestFishControllerGet()
        {
            var testFishList = new LoadedFishList().FishList;

            Assert.AreEqual(testFishList.Count, 31);
            Assert.AreEqual(testFishList.FirstOrDefault(fish => fish.Name == "anthias").Name, "anthias");
            Assert.AreEqual(testFishList.FirstOrDefault(fish => fish.Name == "anthias").Id, 3);
        }
    }
}
