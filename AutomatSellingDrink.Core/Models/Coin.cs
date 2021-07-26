namespace AutomatSellingDrink.Core.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public User Owner { get; set; }
    }
}