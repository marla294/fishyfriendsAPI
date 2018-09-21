using System;
namespace fishfriends.Biz.Models
{
    public class Fish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Fish() { }


        public Fish(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
