using System;
using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public FishDTO MainFish { get; set; } //main list
        public List<FishCompatibility> CompatibilityList { get; set; }

        public class FishCompatibility
        {
            public FishDTO CompareFish { get; set; } //selected
            public string Compatibility { get; set; }

            public FishCompatibility()
            {
                CompareFish = null;
                Compatibility = "";
            }

            public FishCompatibility(FishDTO compareFish, string compatibility)
            {
                CompareFish = compareFish;
                Compatibility = compatibility;
            }
        }

        public FishPairCompatibility()
        {
            MainFish = null;
            CompatibilityList = new List<FishCompatibility>();
        }

        public FishPairCompatibility(FishDTO fishOne)
        {
            MainFish = fishOne;
            CompatibilityList = new List<FishCompatibility>();
        }

        public void SetCompatibility(FishDTO compareFish, string compatibility)
        {
            if (CompatibilityList.FirstOrDefault<FishCompatibility>(fc => fc.CompareFish == compareFish) == null)
            {
                CompatibilityList.Add(new FishCompatibility(compareFish, compatibility));
            }
        }

    }
}
