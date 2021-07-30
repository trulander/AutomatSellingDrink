using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatService
    {
        Task<Drink> CreateDrinkAsync(Core.Models.Drink drink);
        Task DeleteAllDrinksByNameAsync(string nameDrink);
        Task UpdateDrinkAsync(Drink drink);
        Task<Core.Models.Drink> GetDrinkAsync(string name);
        Task<Core.Models.Drink[]> GetAllDrinksAsync(string name);
        Task UpdateQuantityCoins(int coinsCost, int quantity);
        Task<int> GetQuantityCoins(int coinsCost);
        Task UpdateAvailableDepositCoins(Core.Models.Settings settings);
        Task<Settings> GetAvailableDepositCoins();
    }
}