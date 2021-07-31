using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatRepository
    {
        Task DepositCoinAsync(Coin coin);
        Task<Coin[]> GetChangeAsync(Core.Models.Coin[] coins);
        Task<Core.Models.Coin[]> GetAllCoinsAsync();
        Task BuyDrinkAsync(string name);
        Task<Drink[]> GetAvailableDrinksAsync();
        Task<Core.Models.Drink> GetDrinkAsync(string name);
    }
}