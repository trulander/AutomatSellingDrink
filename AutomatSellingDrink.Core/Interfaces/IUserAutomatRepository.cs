using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatRepository
    {
        Task DepositCoinAsync(Coin coin);
        Task GetChangeAsync(Core.Models.Coin[] coins);
        Task<Core.Models.Coin[]> GetAllCoinsAsync();
        Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin);
        Task BuyDrinkAsync(string name);
        Task<Drink[]> GetAllDrinksAsync();
        Task<Core.Models.Drink> GetDrinkAsync(string name);
    }
}