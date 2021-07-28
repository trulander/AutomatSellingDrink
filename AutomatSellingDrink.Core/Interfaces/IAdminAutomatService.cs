using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IAdminAutomatService
    {
        Task CreateDrink(Core.Models.Drink drink);
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