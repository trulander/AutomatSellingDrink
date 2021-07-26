using System.Collections.Generic;

namespace AutomatSellingDrink.API.Contracts
{
    public class User
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public ICollection<DataAccess.Entities.Coin> Coins { get; set; }
    }
}