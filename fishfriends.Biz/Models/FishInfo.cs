using System.Collections.Generic;
using fishfriends.Biz.Database;

namespace fishfriends.Biz.Models
{
    public class FishInfo
    {
        public Fish Fish { get; set; }
        public List<string> Info { get; set; }

        public FishInfo(string fishName)
        {
            Fish = FishFactory.LoadSingle(fishName);
            Info = new List<string>();
        }

        public void AddInfo(string info)
        {
            Info.Add(info);
        }
    }
}
