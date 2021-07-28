using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatRepository
    {
        Task CreateDrinkAsync(Core.Models.Drink newDrink);
        Task DeleteDrinkAsync();
        Task UpdateDrinkAsync();
        Task GetDrinkAsync();
        Task GetAllDrinksAsync();
        Task UpdateQuantityCoinsAsync();
        Task GetQuantityCoinsAsync();
        Task UpdateAvailableDepositCoinsAsync();
        Task GetAvailableDepositCoinsAsync();
    }
}