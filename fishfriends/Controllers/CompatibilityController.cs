using System.Collections.Generic;
using System.Web.Http;
using fishfriends.Biz.Database;
using fishfriends.Biz.Models;

namespace fishfriends.Service.Controllers
{
    public class CompatibilityController : ApiController
    {
        //Get Compatibility of Multiple Fish
        //http://127.0.0.1:8080/api/compatibility?fishNames=clown&fishNames=anthias&fishNames=eels
        public List<FishPairCompatibilityDTO> Get([FromUri] string[] fishNames)
        {
            var fishNamesList = new List<string>();
            fishNamesList.AddRange(fishNames);

            var fishList = FishLoader.LoadFishList(fishNamesList);

            return CompatibilityChecker.GetFishPairCompatibility(fishList);
        }
    }
}
