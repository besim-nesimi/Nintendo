namespace Nintendo.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int Height { get; set; }

        public int Weight { get; set; }
    }
}
