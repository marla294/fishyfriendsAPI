using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using fishfriends.Biz.Database;
using fishfriends.Biz.Models;

namespace fishfriends.Service.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class FishController : ApiController
    {
        // Get All
        public List<FishDTO> Get()
        {
            return FishLoader.LoadAll();
        }
    }
}