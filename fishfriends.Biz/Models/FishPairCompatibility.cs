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

            CalculateTotalCompatibility();
        }

        public void SetFishCompatibility(FishCompatibility fishCompatibility)
        {
            var selectedFish = fishCompatibility.CompareFish;
            var compareFishCompatibility = CompatibilityList.FirstOrDefault(compat => compat.CompareFish == selectedFish);

            if (compareFishCompatibility == null)
            {
                CompatibilityList.Add(fishCompatibility);
            }

            CalculateTotalCompatibility();
        }

        public void CalculateTotalCompatibility()
        {
            TotalCompatibility = GetWorstCompatibility();
        }

        string GetWorstCompatibility()
        {
            var worst = "Yes";

            foreach(var fishCompatibility in CompatibilityList)
            {
                var compatibility = fishCompatibility.Compatibility;

                if (compatibility == "No")
                {
                    worst = "No";
                    break;
                }

                if (compatibility == "Maybe")
                {
                    worst = "Maybe";
                }

            }

            return worst;
        }
    }
}
