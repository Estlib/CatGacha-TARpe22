namespace CatGacha.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime SignupAt { get; set; }
        public bool IsDisabled { get; set; }
        public string DisableReason { get; set; }

        public ICollection<CatOwnership> CatsOwned { get; set; }

        //

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
