using fishfriends.Biz.Database;
using System.Collections.Generic;
using System.Linq;

namespace fishfriends.Biz.Models
{
    //Returns fish with the same fish ids in the database
    public class FishCrafter
    {
        List<Fish> DbFishList { get; set; }

        public FishCrafter()
        {
            DbFishList = new FishLoader().FishList;
        }

        public Fish CraftSingleFish(string name)
        {
            var fishId = DbFishList.FirstOrDefault(fish => fish.Name == name).Id;

            return new Fish(fishId, name);
        }

        public List<Fish> CraftListOfFish(List<string> names)
        {
            List<Fish> FishList = new List<Fish>();

            foreach (var name in names)
            {
                FishList.Add(CraftSingleFish(name));
            }

            return FishList;
        }
    }
}
