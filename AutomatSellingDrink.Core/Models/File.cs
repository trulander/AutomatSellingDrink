namespace AutomatSellingDrink.Core.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Drink Drink { get; set; }
    }
}