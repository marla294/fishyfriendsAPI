using System.Collections.Generic;
using System.Web.Http;
using fishfriends.Biz.Database;

namespace fishfriends.Service.Controllers
{
    public class CompatibilityController : ApiController
    {
        //Get Compatibility of Multiple Fish
        //http://127.0.0.1:8080/api/compatibility?fishNames=clown&fishNames=anthias&fishNames=eels
        public int Get([FromUri] string[] fishNames)
        {
            var fishNamesList = new List<string>();
            fishNamesList.AddRange(fishNames);

            var fishList = FishFactory.LoadFishList(fishNamesList);

            return CompatibilityChecker.GetCompatibility(fishList);
        }
    }
}
