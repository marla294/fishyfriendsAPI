using System;
namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public FishDTO FishOne { get; set; }
        public FishDTO FishTwo { get; set; }
        public string Compatibility { get; set; }

        public FishPairCompatibility()
        {
            FishOne = null;
            FishTwo = null;
            Compatibility = null;
        }

        public FishPairCompatibility(FishDTO fishOne, FishDTO fishTwo, string compatibility)
        {
            FishOne = fishOne;
            FishTwo = fishTwo;
            Compatibility = compatibility;
        }

    }
}
