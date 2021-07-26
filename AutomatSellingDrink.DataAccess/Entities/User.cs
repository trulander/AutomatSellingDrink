using System.Collections.Generic;

namespace AutomatSellingDrink.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public ICollection<Coin> Coins { get; set; }
    }
}