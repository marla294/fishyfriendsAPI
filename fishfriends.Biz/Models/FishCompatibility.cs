using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    public class FishCompatibility
    {
        public FishDTO MainFish { get; set; } //main fish - one of the 31
        public List<Compatibility> CompatibilityList { get; set; } //selected fishes
        public string WorstCompatibility { get; set; } //worst compatibility between the 1 main fish and the several selected


        public FishCompatibility()
        {
            MainFish = null;
            CompatibilityList = new List<Compatibility>();
            WorstCompatibility = null;
        }

        public FishCompatibility(FishDTO mainFish) : this()
        {
            MainFish = mainFish;
        }

        public void SetFishCompatibility(Compatibility fishCompatibility)
        {
            var selectedFish = fishCompatibility.SelectedFish;
            var selectedFishCompatibility = CompatibilityList.FirstOrDefault(compat => compat.SelectedFish == selectedFish);

            if (selectedFishCompatibility == null)
            {
                CompatibilityList.Add(fishCompatibility);
            }

            CalculateWorstCompatibility();
        }

        void CalculateWorstCompatibility()
        {
            var worst = "Yes";

            foreach(var compatibility in CompatibilityList)
            {
                var compatible = compatibility.Compatible;

                if (compatible == "No")
                {
                    worst = "No";
                    break;
                }

                if (compatible == "Maybe")
                {
                    worst = "Maybe";
                }

            }

            WorstCompatibility = worst;
        }
    }
}
