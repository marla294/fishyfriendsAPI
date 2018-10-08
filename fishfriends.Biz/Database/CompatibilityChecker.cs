using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public static class CompatibilityChecker
    {
        public static List<FishPairCompatibility> GetAllFishCompatibility(List<FishDTO> selectedFish)
        {
            List<FishPairCompatibility> fishCompatibility = CreateFishPairCompatibilityList();
            List<FishDTO> allFish = FishLoader.LoadAll();

            for (var i = 0; i < selectedFish.Count; i++)
            {
                for (var j = 0; j < allFish.Count; j++)
                {
                    //fishCompatibility.Add(GetFishPairCompatibility(allFish[j], selectedFish[i]));
                    fishCompatibility[j].CompatibilityList.Add(GetFishCompatibility(allFish[j], selectedFish[i]));
                }
            }

            return fishCompatibility;
        }

        public static List<FishPairCompatibility> CreateFishPairCompatibilityList()
        {
            List<FishPairCompatibility> fishCompatibility = new List<FishPairCompatibility>();
            List<FishDTO> allFish = FishLoader.LoadAll();

            for (var j = 0; j < allFish.Count; j++)
            {
                fishCompatibility.Add(new FishPairCompatibility(allFish[j]));
            }

            return fishCompatibility;
        }

        private static FishCompatibility GetFishCompatibility(FishDTO fishOne, FishDTO fishTwo)
        {
            var sql = String.Format("select c.compatible " +
                                        "from compatibility c " +
                                        "inner join fish f1 " +
                                        "on c.fishone = f1.id " +
                                        "inner join fish f2 " +
                                        "on c.fishtwo = f2.id " +
                                        "where f1.name = '{0}' " +
                                        "and f2.name = '{1}';",
                                        fishOne.Name, fishTwo.Name);

            var compatibility = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql)[0][0];

            return new FishCompatibility(fishTwo, compatibility);
        }
    }
}
