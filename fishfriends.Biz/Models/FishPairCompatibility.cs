using System;
using System.Collections.Generic;

namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        FishDTO FishOne { get; set; }
        //FishDTO FishTwo { get; set; }
        //string Compatibility { get; set; }
        List<FishCompatibility> CompatibilityList { get; set; }

        public class FishCompatibility
        {
            FishDTO Fish { get; set; }
            string Compatibility { get; set; }
        }

        public FishPairCompatibility()
        {
            FishOne = null;
            //FishTwo = null;
            //Compatibility = null;
            CompatibilityList = new List<FishCompatibility>();
        }

        public FishPairCompatibility(FishDTO fishOne)
        {
            FishOne = fishOne;
            //FishTwo = fishTwo;
            //Compatibility = null;
            CompatibilityList = new List<FishCompatibility>();
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
