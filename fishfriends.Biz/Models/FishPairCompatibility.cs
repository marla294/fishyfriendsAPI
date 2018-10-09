using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    public class FishPairCompatibility
    {
        public FishDTO MainFish { get; set; } //main fish - one of the 31
        public List<FishCompatibility> CompatibilityList { get; set; } //selected fishes
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


        public void SetFishCompatibility(FishCompatibility fishCompatibility)
        {
            var selectedFish = fishCompatibility.SelectedFish;
            var selectedFishCompatibility = CompatibilityList.FirstOrDefault(compat => compat.SelectedFish == selectedFish);

            if (selectedFishCompatibility == null)
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
