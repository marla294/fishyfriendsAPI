using System;
namespace fishfriends.Biz.Models
{
    public class FishCompatibility
    {
        public FishDTO SelectedFish { get; set; }
        public string Compatibility { get; set; }

        public FishCompatibility()
        {
            SelectedFish = null;
            Compatibility = null;
        }

        public FishCompatibility(FishDTO selectedFish, string compatibility)
        {
            SelectedFish = selectedFish;
            Compatibility = compatibility;
        }
    }
}
