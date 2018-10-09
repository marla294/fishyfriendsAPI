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

            for (var i = 0; i < allFishPairCompatibility.Count; i++) 
            {
                var currentPair = allFishPairCompatibility[i];
                var main = currentPair.MainFish;

                for (var j = 0; j < selectedFish.Count; j++)
                {
                    var selected = selectedFish[j];
                    var fishCompatibility = GetFishCompatibility(main, selected);

                    currentPair.SetFishCompatibility(selected, fishCompatibility.Compatibility);
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
