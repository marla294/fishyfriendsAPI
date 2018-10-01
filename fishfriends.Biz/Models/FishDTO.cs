using System.Collections.Generic;

namespace fishfriends.Biz.Models
{
    public class FishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Info { get; set; }

        public FishDTO()
        {
            Id = 0;
            Name = "";
            Info = new List<string>();
        }

        public FishDTO(int id, string name, List<string> info)
        {
            Id = id;
            Name = name;
            Info = info;
        }
    }
}
