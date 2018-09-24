using fishfriends.Biz.Database;
using System.Collections.Generic;
using System.Linq;
using System;

namespace fishfriends.Biz.Models
{
    //Returns fish or List<Fish> with the same fish ids in the database
    public class FishCrafter
    {
        List<Fish> DbFishList { get; set; }

        public FishCrafter()
        {
            DbFishList = new FishLoader().FishList;
        }

        public Fish CraftSingleFish(string name)
        {
            IsValidFish(name);

            var fishId = DbFishList.FirstOrDefault(fish => fish.Name == name).Id;

            return new Fish(fishId, name);
        }

        public List<Fish> CraftListOfFish(List<string> names)
        {
            List<Fish> FishList = new List<Fish>();

            foreach (var name in names)
            {
                IsValidFish(name);
                FishList.Add(CraftSingleFish(name));
            }

            return FishList;
        }

        //Checks to see if a string is a valid fish in the database
        void IsValidFish(string fishName)
        {
            var testFish = DbFishList.FirstOrDefault(fish => fish.Name == fishName);

            if (testFish == null)
            {
                throw new ArgumentException(fishName + " is not a valid fish.");
            }

        }
    }
}
