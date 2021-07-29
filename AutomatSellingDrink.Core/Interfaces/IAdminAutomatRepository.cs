using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatRepository
    {
        Task<Drink> CreateDrinkAsync(Drink newDrink);
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