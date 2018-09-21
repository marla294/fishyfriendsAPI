using System.Collections.Generic;
using System.Web.Http;
using fishfriends.Biz.Database;
using fishfriends.Biz.Models;
using System.Linq;

namespace fishfriends.Service.Controllers
{
    public class CompatibilityController : ApiController
    {
        // Get Compatibility of Multiple Fish
        public int Get(string fish1, string fish2)
        {
            var allFish = new FishLoader().FishList;
            var fishOneId = allFish.FirstOrDefault(fish => fish.Name == fish1).Id;
            var fishTwoId = allFish.FirstOrDefault(fish => fish.Name == fish2).Id;

            var fishList = new List<Fish>() { new Fish(fishOneId, fish1), new Fish(fishTwoId, fish2) };

            return new CompatibilityChecker().GetCompatibility(fishList);
        }
    }
}
