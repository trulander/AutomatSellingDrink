using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatRepository
    {
        Task<Drink> CreateDrinkAsync(Drink newDrink);
        Task DeleteAllDrinksByNameAsync(string nameDrink);
        Task UpdateDrinkAsync(Drink drink);
        Task<Core.Models.Drink> GetDrinkAsync(string name);
        Task<Core.Models.Drink[]> GetAllDrinksAsync(string name);
        Task UpdateQuantityCoinsAsync(int coinCost, int quantity);
        Task<int> GetQuantityCoinsAsync(int coinCost);
    }
}