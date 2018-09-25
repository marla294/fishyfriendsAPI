using System.Collections.Generic;
using System.Web.Http;
using fishfriends.Biz.Database;

namespace fishfriends.Service.Controllers
{
    public class FishController : ApiController
    {
        // Get All
        public List<LoadedFish> Get()
        {
            return new LoadedFishList().FishList;
        }
    }
}