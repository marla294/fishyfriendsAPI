using System;
using System.Collections.Generic;
using fishfriends.Biz.Database;

namespace fishfriends.Biz.Models
{
    public class AllFish
    {
        public List<Fish> FishList { get; private set; }

        public AllFish()
        {
            FishList = new List<Fish>();

            PopulateFishList();
        }

        private void PopulateFishList()
        {
            var dB = new ConnectionUtils();

            var fishList = dB.RunCommand("select name from fish;");

            foreach(var f in fishList)
            {
                FishList.Add(new Fish() { Name = f });
            }
        }

    }
}
