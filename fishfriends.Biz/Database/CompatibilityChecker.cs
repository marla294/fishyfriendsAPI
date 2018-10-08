using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public static class CompatibilityChecker
    {
        public static List<FishPairCompatibility> GetAllFishCompatibility(List<FishDTO> selectedFish)
        {
            List<FishPairCompatibility> allFishPairCompatibility = CreateFishPairCompatibilityList();

            for (var i = 0; i < selectedFish.Count; i++)
            {
                for (var j = 0; j < allFishPairCompatibility.Count; j++)
                {
                    var currentPair = allFishPairCompatibility[j];
                    var main = currentPair.MainFish;
                    var selected = selectedFish[i];

                    var fishCompatibility = GetFishCompatibility(main, selected);

                    currentPair.CompatibilityList.Add(fishCompatibility);
                    currentPair.SetTotalCompatibility();
                }
            }

            return allFishPairCompatibility;
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

        private static FishCompatibility GetFishCompatibility(FishDTO mainFish, FishDTO selectedFish)
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

            var compatibility = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql)[0][0];

            return new FishCompatibility(selectedFish, compatibility);
        }
    }
}
