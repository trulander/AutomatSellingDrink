using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserAutomatRepository
    {
        Task DepositCoinAsync(Coin coin);
        Task<Coin[]> GetChangeAsync(Core.Models.Coin[] coins);
        Task GetAvailableDepositCoinsAsync();
        Task BuyDrinkAsync();
        Task GetAvailableDrinksAsync();
        Task<Core.Models.Coin[]> GetAvailableCoinsAsync();
    }
}