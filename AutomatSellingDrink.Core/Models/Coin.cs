namespace AutomatSellingDrink.Core.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; }
        public bool IsAllowToDeposit { get; set; }
    }
}