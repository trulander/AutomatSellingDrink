using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatRepository
    {
        Task<Drink> CreateDrinkAsync(Drink newDrink);
        Task DeleteDrinkByNameAsync(string nameDrink);
        Task<Core.Models.Drink> UpdateDrinkAsync(Drink drink);
        Task<Core.Models.Drink> GetDrinkAsync(string name);
        Task<Core.Models.Drink[]> GetAllDrinksAsync();
        Task<Core.Models.Coin> CreateCoinAsync(Core.Models.Coin coin);
        Task<Coin> UpdateCoinAsync(Core.Models.Coin coin);
        Task<Coin> GetCoinAsync(Core.Models.Coin coin);
        Task<Core.Models.Coin[]> GetAllCoinsAsync();
    }
}