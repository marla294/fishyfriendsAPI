using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    public static class FishLoader
    {
        public static List<Fish> LoadAll()
        {
            return LoadByQuery("select * from fish order by id;");
        }

        public static Fish LoadSingle(string name)
        {
            return LoadAll().FirstOrDefault<Fish>(f => f.Name == name);
        }

        public static List<Fish> LoadFishList(List<string> names)
        {
            var fishList = new List<Fish>();

            foreach(var name in names)
            {
                fishList.Add(LoadSingle(name));
            }

            return fishList;
        }

        private static List<Fish> LoadByQuery(string sql)
        {
            var fishResultSet = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql);
            var fishList = new List<Fish>();

            for (var i = 0; i < fishResultSet[0].Count; i++)
            {
                Fish fish = Int32.TryParse(fishResultSet[0][i], out int id)
                    ? new Fish()
                    {
                        Id = id,
                        Name = fishResultSet[1][i]
                    }
                    : new Fish();

                LoadInfoForFish(fish);

                fishList.Add(fish);
            }

            return fishList;
        }

        private static void LoadInfoForFish(Fish fish)
        {
            var sql = String.Format("select info from fishinfo where fish = {0} order by infoid;", fish.Id.ToString());

            var infoResultSet = ConnectionUtils.ExecuteCommand(new PostgreSQLConnection(), sql);

            for (var i = 0; i < infoResultSet[0].Count; i++)
            {
                fish.Info.Add(infoResultSet[0][i]);
            }

        }
    }

}
