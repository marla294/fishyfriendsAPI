using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    public static class FishLoader
    {
        public static List<FishDTO> LoadAll()
        {
            return LoadByQuery("select * from fish order by id;");
        }

        public static FishDTO LoadSingle(string name)
        {
            return LoadAll().FirstOrDefault<FishDTO>(f => f.Name == name);
        }

        public static List<FishDTO> LoadFishList(List<string> names)
        {
            var fishList = new List<FishDTO>();

            foreach(var name in names)
            {
                fishList.Add(LoadSingle(name));
            }

            return fishList;
        }

        private static List<FishDTO> LoadByQuery(string sql)
        {
            var fishResultSet = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql);
            var fishList = new List<FishDTO>();

            for (var i = 0; i < fishResultSet[0].Count; i++)
            {
                Fish fish = Int32.TryParse(fishResultSet[0][i], out int id)
                    ? new Fish(id, fishResultSet[1][i])
                    : new Fish();

                LoadInfoForFish(fish);

                fishList.Add(fish.ToDTO());
            }

            return fishList;
        }

        private static void LoadInfoForFish(Fish fish)
        {
            var sql = String.Format("select info from fishinfo where fish = {0} order by infoid;", fish.ToDTO().Id.ToString());

            var infoResultSet = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql);

            for (var i = 0; i < infoResultSet[0].Count; i++)
            {
                fish.AddInfo(infoResultSet[0][i]);
            }

        }
    }

}
