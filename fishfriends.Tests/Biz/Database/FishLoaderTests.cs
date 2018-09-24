using fishfriends.Biz.Database;
using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;

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

        [Test]
        public void TestLoadedFishFishNameArgumentError()
        {
            Assert.Throws<ArgumentException>(() => new LoadedFish("I am not a valid fish name"));
        }

        [Test]
        public void TestLoadedFishListHappyPath()
        {
            List<string> listOfNames = new List<string>() { "batfish", "anthias", "clown", "cardinals", "chromis", "blennies", "batfish" };

            List<LoadedFish> listOfFish = new LoadedFishList(listOfNames).FishList;

            foreach(var fish in listOfFish)
            {
                Assert.AreEqual(listOfNames.FirstOrDefault(f => f == fish.Name), fish.Name);
                Assert.IsNotNullOrEmpty(fish.Id.ToString());
                Assert.AreNotEqual(fish.Id, 0);
            }
        }

        [Test]
        public void TestLoadedFishListNameArgumentError()
        {
            List<string> listOfNames = new List<string>() { "I am not a valid fish name", "anthias", "clown", "cardinals", "chromis", "blennies", "batfish" };

            Assert.Throws<ArgumentException>(() => new LoadedFishList(listOfNames));
        }
    }
}
