using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public static class CompatibilityChecker
    {

        public static List<FishPairCompatibilityDTO> GetAllFishCompatibility(List<FishDTO> selectedFish)
        {
            List<FishPairCompatibilityDTO> fishCompatibility = new List<FishPairCompatibilityDTO>();
            List<FishDTO> allFish = FishLoader.LoadAll();

            for (var i = 0; i < selectedFish.Count; i++)
            {
                for (var j = 0; j < allFish.Count; j++)
                {
                    fishCompatibility.Add(GetFishPairCompatibility(selectedFish[i], allFish[j]));
                }
            }

            return fishCompatibility;
        }

        private static FishPairCompatibilityDTO GetFishPairCompatibility(FishDTO fishOne, FishDTO fishTwo)
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

            var FPC = new FishPairCompatibility(fishOne, fishTwo);

            FPC.SetCompatibility(compatibility);

            return FPC.ToDTO();
        }
    }
}
