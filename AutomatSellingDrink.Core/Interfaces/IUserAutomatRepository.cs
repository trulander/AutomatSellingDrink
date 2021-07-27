using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatRepository
    {
        Task DepositCoin(Coin coin);
        Task<Core.Models.Coin[]> GetChange(Core.Models.User user);
        Task<Coin[]> GetAvailableDepositCoins();
        Task BuyDrink();
        void GetAvailableDrinks();
    }
}