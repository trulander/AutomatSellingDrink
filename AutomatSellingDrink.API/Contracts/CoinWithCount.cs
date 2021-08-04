namespace AutomatSellingDrink.API.Contracts
{
    public class CoinWithCount
    {
        public int Cost { get; set; }
        public int Count { get; set; }
        public bool IsAllowToDeposit { get; set; }
    }
}