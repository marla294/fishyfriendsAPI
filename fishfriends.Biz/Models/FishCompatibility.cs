using System;
namespace fishfriends.Biz.Models
{
    public class FishCompatibility
    {
        public FishDTO CompareFish { get; set; } //selected
        public string Compatibility { get; set; }

        public FishCompatibility()
        {
            CompareFish = null;
            Compatibility = null;
        }

        public FishCompatibility(FishDTO compareFish, string compatibility)
        {
            CompareFish = compareFish;
            Compatibility = compatibility;
        }
    }
}
