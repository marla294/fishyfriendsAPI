using System.Collections.Generic;

namespace fishfriends.Biz.Models
{
    public class Fish
    {
        int Id { get; set; }
        string Name { get; set; }
        List<string> Info { get; set; }

        public Fish() 
        {
            Id = 0;
            Name = "";
            Info = new List<string>();
        }

        public Fish(int id, string name)
        {
            Id = id;
            Name = name;
            Info = new List<string>();
        }

        public void AddInfo(string info)
        {
            Info.Add(info);
        }

        public FishDTO ToDTO()
        {
            return new FishDTO(this.Id, this.Name, this.Info);
        }
    }
}
