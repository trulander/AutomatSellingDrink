using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class AdminAutomatService : IAdminAutomatService
    {
        private readonly IAdminAutomatRepository _adminAutomatRepository;
        private readonly ISettingsService _settingsService;

        public AdminAutomatService(
            IAdminAutomatRepository adminAutomatRepository,
            ISettingsService settingsService)
        {
            _adminAutomatRepository = adminAutomatRepository;
            _settingsService = settingsService;
        }
        public async Task<Core.Models.Drink> CreateDrinkAsync(Core.Models.Drink drink)
        {
            return await _adminAutomatRepository.CreateDrinkAsync(drink);
        }

        public async Task DeleteAllDrinksByNameAsync(string nameDrink)
        {
            await _adminAutomatRepository.DeleteAllDrinksByNameAsync(nameDrink);
        }

        public async Task UpdateDrinkAsync(Core.Models.Drink drink)
        {
            _adminAutomatRepository.UpdateDrinkAsync(drink);
        }

        public async Task<Core.Models.Drink> GetDrinkAsync(string name)
        {
            var result = await _adminAutomatRepository.GetDrinkAsync(name);
            return result;
        }

        public async Task<Core.Models.Drink[]> GetAllDrinksAsync(string name)
        {
            var result = await _adminAutomatRepository.GetAllDrinksAsync(name);
            return result;
        }

        public async Task UpdateQuantityCoins(int coinsCost, int quantity)
        {
           await _adminAutomatRepository.UpdateQuantityCoinsAsync(coinsCost, quantity);
        }

        public async Task<int> GetQuantityCoins(int coinsCost)
        {
            var result = await _adminAutomatRepository.GetQuantityCoinsAsync(coinsCost);
            return result;
        }

        public async Task UpdateAvailableDepositCoins(Core.Models.Settings settings)
        {
            await _settingsService.SaveSettingsAsync(settings);
        }

        public async Task<Core.Models.Settings> GetAvailableDepositCoins()
        {
            var result = await _settingsService.LoadSettingsAsync();
            return result;
        }
    }
}