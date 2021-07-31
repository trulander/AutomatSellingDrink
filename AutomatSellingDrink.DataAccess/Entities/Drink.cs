namespace AutomatSellingDrink.DataAccess.Entities
{
    public class Drink
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public File Image { get; set; }
        public int FileId { get; set; }
        public int Count { get; set; }
    }
}