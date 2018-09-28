using System.Collections.Generic;

namespace fishfriends.Biz.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Info { get; set; }

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
    }
}
