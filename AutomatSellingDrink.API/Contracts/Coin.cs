namespace AutomatSellingDrink.API.Contracts
{
    public class Coin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public User Owner { get; set; }
    }
}