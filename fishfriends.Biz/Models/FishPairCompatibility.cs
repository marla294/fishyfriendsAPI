using System;
namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public Fish FishOne { get; set; }
        public Fish FishTwo { get; set; }
        public string Compatibility { get; set; }

        public FishPairCompatibility()
        {
            FishOne = null;
            FishTwo = null;
            Compatibility = null;
        }

        public FishPairCompatibility(Fish fishOne, Fish fishTwo, string compatibility)
        {
            FishOne = fishOne;
            FishTwo = fishTwo;
            Compatibility = compatibility;
        }

    }
}
