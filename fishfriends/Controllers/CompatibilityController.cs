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
            var fishList = new FishCrafter().CraftListOfFish(new List<string>() { fish1, fish2 });

            return new CompatibilityChecker().GetCompatibility(fishList);
        }
    }
}
