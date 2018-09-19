using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;

namespace fishfriends.Biz.Database
{
    public class FishLoader
    {
        public List<Fish> FishList { get; private set; }

        public FishLoader()
        {
            FishList = new List<Fish>();

            PopulateFishList();
        }

        private void PopulateFishList()
        {
            var dB = new ConnectionUtils();

            var fishResultSet = dB.GetResultSet("select * from fish order by id;");

            for (var i = 0; i < fishResultSet[0].Count; i++)
            {
                Fish fish = Int32.TryParse(fishResultSet[0][i], out int id)
                    ? new Fish()
                    {
                        Id = id,
                        Name = fishResultSet[1][i]
                    }
                    : new Fish();

                FishList.Add(fish);
            }
        }
    }
}
