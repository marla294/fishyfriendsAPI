using System;
using System.Collections.Generic;

namespace fishfriends.Biz.Models
{
    public class AllFish
    {
        public List<Fish> FishList { get; private set; }

        public AllFish()
        {
            FishList = new List<Fish>() {new Fish() {Name = "Pete The Fish"}};
        }

    }
}
