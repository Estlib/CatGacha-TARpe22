namespace CatGacha.Models
{
    public enum Zodiac
    {
        Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat, Monkey, Rooster, Dog, Pig
    }
    public class Cat
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Zodiac Zodiac { get; set; }
        public string Snack { get; set; }
        public string Personality { get; set; }
        public string CatImageLink { get; set; }
        public ICollection<CatOwnership>? CatOwnerships { get; set; }
    }
}
