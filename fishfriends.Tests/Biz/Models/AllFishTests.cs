using System;
using fishfriends.Biz.Models;
using fishfriends.Biz.Database;
using NUnit.Framework;

namespace fishfriends.Tests.Biz.Models
{
    [TestFixture]
    public class AllFishTests
    {
        [Test]
        public void TestAllFish()
        {
            var dB = new ConnectionUtils();

            var name = dB.RunCommand("select name from fish;");

            Assert.AreEqual(name, 1);
        }
    }
}
