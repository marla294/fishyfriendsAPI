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
            var fishList = new LoadedFishList(new List<string>() {fish1, fish2}).FishList;

            return new CompatibilityChecker().GetCompatibility(fishList);
        }
    }
}
