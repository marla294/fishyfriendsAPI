using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public FishDTO MainFish { get; set; } //main fish - one of the 31
        public List<FishCompatibility> CompatibilityList { get; set; } //selected fish
        public string TotalCompatibility { get; set; } //worst compatibility between the 1 main fish and the several selected


        public FishPairCompatibility()
        {
            MainFish = null;
            CompatibilityList = new List<FishCompatibility>();
            TotalCompatibility = null;
        }


        public FishPairCompatibility(FishDTO mainFish) : this()
        {
            MainFish = mainFish;
        }


        public void SetFishCompatibility(FishDTO compareFish, string compatibility)
        {
            var compareFishCompatibility = CompatibilityList.FirstOrDefault(compat => compat.CompareFish == compareFish);

            if (compareFishCompatibility == null)
            {
                CompatibilityList.Add(new FishCompatibility(compareFish, compatibility));
            }

            SetTotalCompatibility();
        }


        public void SetTotalCompatibility()
        {
            foreach (var fishCompatibility in CompatibilityList)
            {
                var compatibility = fishCompatibility.Compatibility;

                if (TotalCompatibility == null) 
                { 
                    TotalCompatibility = compatibility; 
                }
                else 
                {
                    switch (compatibility)
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
