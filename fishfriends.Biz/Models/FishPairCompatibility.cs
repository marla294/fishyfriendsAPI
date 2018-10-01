using System;
namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        FishDTO FishOne { get; set; }
        FishDTO FishTwo { get; set; }
        string Compatibility { get; set; }

        public FishPairCompatibility()
        {
            FishOne = null;
            FishTwo = null;
            Compatibility = null;
        }

        public FishPairCompatibility(FishDTO fishOne, FishDTO fishTwo)
        {
            FishOne = fishOne;
            FishTwo = fishTwo;
            Compatibility = null;
        }

        public void SetCompatibility(string compatibility)
        {
            if (Compatibility == null)
            {
                Compatibility = compatibility;
            }
        }

        public FishPairCompatibilityDTO ToDTO()
        {
            return new FishPairCompatibilityDTO(this.FishOne, this.FishTwo, this.Compatibility);
        }

    }
}
