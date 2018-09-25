using System;
using System.Collections.Generic;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Biz.Database
{
    //Pair programming help - to do
    //public static class FishFactory {
    //    public List<Fish> LoadAll() {
    //        return LoadByQuery("select * from fish order by id;");
    //    }

    //    public Fish LoadByName(string name) {
    //        don't build query manually, susceptible to sql injection
    //        return LoadByQuery($"select * from fish where name = '{name}' by id;").FirstOrDefault();
    //    }

    //    private List<Fish> LoadByQuery(string sql) {
    //        var dB = new ConnectionUtils();

    //        var fishResultSet = dB.GetResultSet(sql);
    //        var finalResult = new List<Fish>();

    //        for (var i = 0; i < fishResultSet[0].Count; i++)
    //        {
    //            Fish fish = Int32.TryParse(fishResultSet[0][i], out int id)
    //                ? new Fish()
    //                {
    //                    Id = id,
    //                    Name = fishResultSet[1][i]
    //                }
    //                : new Fish();

    //            finalResult.Add(fish);
    //        }
    //    }
    //}

    //Loads all the fish that are in the database into FishList
    public class FishLoader
    {
        //List of database fish, for internal use in setting up a fish list
        protected List<Fish> DbFishList { get; set; }

        public FishLoader()
        {
            DbFishList = new List<Fish>();

            PopulateFishList();
        }

        void PopulateFishList()
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

                DbFishList.Add(fish);
            }
        }
    }

    public class LoadedFish : FishLoader
    {
        //API won't show these unless these are public get and set; not sure why
        //I wanted to have private set on these
        public int Id { get; set; }
        public string Name { get; set; }

        public LoadedFish()
        {
            Id = 0;
            Name = "";
        }

        public LoadedFish(string fishName)
        {
            if(IsValidFish(fishName))
            {
                Fish fish = DbFishList.FirstOrDefault(f => f.Name == fishName);

                Id = fish.Id;
                Name = fish.Name;
            }
        }

        //Checks to see if a string is a valid fish in the database
        bool IsValidFish(string fishName)
        {
            var testFish = DbFishList.FirstOrDefault(fish => fish.Name == fishName);

            if (testFish == null)
            {
                throw new ArgumentException(fishName + " is not a valid fish.");
            }

            return true;
        }
    }

    public class LoadedFishList : FishLoader
    {
        public List<LoadedFish> FishList { get; private set; }

        public LoadedFishList()
        {
            FishList = new List<LoadedFish>();

            foreach (var fish in DbFishList)
            {
                FishList.Add(new LoadedFish(fish.Name));
            }
        }

        public LoadedFishList(List<string> nameList)
        {
            FishList = new List<LoadedFish>();

            foreach (var name in nameList)
            {
                FishList.Add(new LoadedFish(name));
            }
        }
    }
}
