using System;
namespace fishfriends.Biz.Models
{
    public class FishPairCompatibilityDTO
    {
        public FishDTO FishOne { get; set; }
        public FishDTO FishTwo { get; set; }
        public string Compatibility { get; set; }

        public FishPairCompatibilityDTO()
        {
            FishOne = null;
            FishTwo = null;
            Compatibility = null;
        }

        public FishPairCompatibilityDTO(FishDTO fishOne, FishDTO fishTwo, string compatibility)
        {
            FishOne = fishOne;
            FishTwo = fishTwo;
            Compatibility = compatibility;
        }
    }
}
