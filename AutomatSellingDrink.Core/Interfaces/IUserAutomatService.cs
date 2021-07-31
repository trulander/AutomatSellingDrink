using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatService
    {
        Task<Balance> DepositCoinAsync(Core.Models.Coin coin);
        Task<Coin[]> GetChangeAsync();
        Task<Settings> GetAvailableDepositCoins();
        Task<Balance> BuyDrinkAsync(string name);
        Task<Core.Models.Drink[]> GetAvailableDrinks();
    }
}