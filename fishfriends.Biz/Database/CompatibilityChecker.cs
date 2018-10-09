using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public static class CompatibilityChecker
    {
        public static List<FishPairCompatibility> GetAllFishCompatibility(List<FishDTO> selectedFishes)
        {
            List<FishPairCompatibility> allFishPairCompatibility = CreateFishPairCompatibilityList();

            for (var i = 0; i < allFishPairCompatibility.Count; i++) 
            {
                var current = allFishPairCompatibility[i];

                SetSelectedFishesCompatibility(current, selectedFishes);
            }

            return allFishPairCompatibility;
        }

        private static void SetSelectedFishesCompatibility(FishPairCompatibility current, List<FishDTO> selectedFishes)
        {
            var mainFish = current.MainFish;

            for (var j = 0; j < selectedFishes.Count; j++)
            {
                var selectedFish = selectedFishes[j];
                var fishCompatibility = GetFishCompatibility(mainFish, selectedFish);

                current.SetFishCompatibility(fishCompatibility);
            }
        }

        private static List<FishPairCompatibility> CreateFishPairCompatibilityList()
        {
            List<FishPairCompatibility> fishCompatibility = new List<FishPairCompatibility>();
            List<FishDTO> allFish = FishLoader.LoadAll();

            for (var j = 0; j < allFish.Count; j++)
            {
                fishCompatibility.Add(new FishPairCompatibility(allFish[j]));
            }

            return fishCompatibility;
        }

        private static Compatibility GetFishCompatibility(FishDTO mainFish, FishDTO selectedFish)
        {
            var sql = String.Format("select c.compatible " +
                                        "from compatibility c " +
                                        "inner join fish f1 " +
                                        "on c.fishone = f1.id " +
                                        "inner join fish f2 " +
                                        "on c.fishtwo = f2.id " +
                                        "where f1.name = '{0}' " +
                                        "and f2.name = '{1}';",
                                        mainFish.Name, selectedFish.Name);

            var compatible = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql)[0][0];

            return new Compatibility(selectedFish, compatible);
        }
    }
}
