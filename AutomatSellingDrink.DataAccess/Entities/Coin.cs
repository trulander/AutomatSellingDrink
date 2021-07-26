namespace AutomatSellingDrink.DataAccess.Entities
{
    public class Coin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public User Owner { get; set; }
        public int UserId { get; set; }
    }
}