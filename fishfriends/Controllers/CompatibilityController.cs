using System.Collections.Generic;
using System.Web.Http;
using fishfriends.Biz.Database;

namespace fishfriends.Service.Controllers
{
    public class CompatibilityController : ApiController
    {
        // Get Compatibility of Multiple Fish
        public int Get(params string[] fishNames)
        {
            var fishNamesList = new List<string>();
            fishNamesList.AddRange(fishNames);

            var fishList = new LoadedFishList(fishNamesList).FishList;

            return new CompatibilityChecker().GetCompatibility(fishList);
        }
    }
}
