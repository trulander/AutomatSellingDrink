using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class AdminAutomatService : IAdminAutomatService
    {
        private readonly IAdminAutomatRepository _adminAutomatRepository;

        public AdminAutomatService(IAdminAutomatRepository adminAutomatRepository)
        {
            _adminAutomatRepository = adminAutomatRepository;
        }
        public async Task<Core.Models.Drink> CreateDrinkAsync(Core.Models.Drink drink)
        {
            return await _adminAutomatRepository.CreateDrinkAsync(drink);
        }

        public async Task DeleteDrink()
        {
            
        }

        public async Task UpdateDrink()
        {
            
        }

        public async Task GetDrink()
        {
            
        }

        public async Task GetAllDrinks()
        {
            
        }

        public async Task UpdateQuantityCoins()
        {
            
        }

        public async Task GetQuantityCoins()
        {
            
        }

        public async Task UpdateAvailableDepositCoins()
        {
            
        }

        public async Task GetAvailableDepositCoins()
        {
            
        }
    }
}