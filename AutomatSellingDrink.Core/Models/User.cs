using System.Collections.Generic;

namespace AutomatSellingDrink.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public ICollection<Coin> Coins { get; set; }
    }
}