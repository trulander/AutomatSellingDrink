using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatService
    {
        Task DepositCoinAsync(Core.Models.Coin coin);
        Task<Coin[]> GetChangeAsync();
        Task<Settings> GetAvailableDepositCoins();
        Task BuyDrink();
        Task GetAvailableDrinks();
    }
}