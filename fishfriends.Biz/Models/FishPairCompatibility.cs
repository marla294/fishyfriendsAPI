using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public FishDTO MainFish { get; set; } //main list
        public List<FishCompatibility> CompatibilityList { get; set; }
        public string TotalCompatibility { get; set; }

        public FishPairCompatibility()
        {
            MainFish = null;
            CompatibilityList = new List<FishCompatibility>();
            TotalCompatibility = null;
        }

        public FishPairCompatibility(FishDTO fishOne) : base()
        {
            MainFish = fishOne;
            CompatibilityList = new List<FishCompatibility>();
            TotalCompatibility = null;
        }

        public void SetFishCompatibility(FishDTO compareFish, string compatibility)
        {
            if (CompatibilityList.FirstOrDefault<FishCompatibility>(fc => fc.CompareFish == compareFish) == null)
            {
                CompatibilityList.Add(new FishCompatibility(compareFish, compatibility));
            }

            SetTotalCompatibility();
        }

        void SetTotalCompatibility()
        {
            foreach (var compatibility in CompatibilityList)
            {
                if (TotalCompatibility == null) { TotalCompatibility = compatibility.Compatibility; }
                else 
                {
                    switch (compatibility.Compatibility)
                    {
                        case "Maybe":
                            if (TotalCompatibility == "Yes") { TotalCompatibility = "Maybe"; }
                            break;
                        case "No":
                            TotalCompatibility = "No";
                            break;
                    }
                }
            }
        }

    }
}
