namespace AutomatSellingDrink.API.Contracts
{
    public class NewDrink
    {
        public int Cost { get; set; }
        public string Name { get; set; }
        public int FileId { get; set; }
        public int Count { get; set; }
    }
}