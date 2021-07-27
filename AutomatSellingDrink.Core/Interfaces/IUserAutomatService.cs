using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatService
    {
        Task DepositCoin(Coin coins);
        Task<Coin[]> GetChange(Core.Models.User user);
        Task<Coin[]> GetAvailableDepositCoins();
        Task BuyDrink(Core.Models.Drink drink, Core.Models.User user);
        Task GetAvailableDrinks();
    }
}