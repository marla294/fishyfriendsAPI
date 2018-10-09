namespace fishfriends.Biz.Models
{
    public class Compatibility
    {
        public FishDTO SelectedFish { get; set; }
        public string Compatible { get; set; }

        public Compatibility()
        {
            SelectedFish = null;
            Compatible = null;
        }

        public Compatibility(FishDTO selectedFish, string compatible)
        {
            SelectedFish = selectedFish;
            Compatible = compatible;
        }
    }
}
