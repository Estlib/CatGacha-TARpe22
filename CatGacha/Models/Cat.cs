namespace CatGacha.Models
{
    public enum Zodiac
    {
        A, B, C, D, E, F, G, H, I, J, K, L
    }
    public class Cat
    {
        public int CatID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Zodiac Zodiac { get; set; }
        public string Snack { get; set; }
        public string Personality { get; set; }
        public ICollection<CatOwnership> CatOwnerships { get; set; }
    }
}
