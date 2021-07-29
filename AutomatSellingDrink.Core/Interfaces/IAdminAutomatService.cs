using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatService
    {
        Task<Drink> CreateDrinkAsync(Core.Models.Drink drink);
        Task DeleteDrink();
        Task UpdateDrink();
        Task GetDrink();
        Task GetAllDrinks();
        Task UpdateQuantityCoins();
        Task GetQuantityCoins();
        Task UpdateAvailableDepositCoins();
        Task GetAvailableDepositCoins();
    }
}