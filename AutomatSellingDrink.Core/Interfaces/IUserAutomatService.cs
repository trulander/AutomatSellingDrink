using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatService
    {
        Task<Balance> DepositCoinAsync(Core.Models.Coin coin);
        Task<Coin[]> GetChangeAsync();
        Task<Core.Models.Coin[]> GetAllCoinsAsync();
        Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin);
        Task<Balance> BuyDrinkAsync(string name);
        Task<Core.Models.Drink[]> GetAllDrinksAsync();
    }
}