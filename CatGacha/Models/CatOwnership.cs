namespace CatGacha.Models
{
    public class CatOwnership
    {
        public int OwnershipID { get; set; } //id
        public int UserID { get; set; } //kasutajaid
        public int CatID { get; set; } //catid 
        public int? OwnershipTotal { get; set; } //kui palju kasutaja omab

    }
}