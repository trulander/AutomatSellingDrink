using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using AutomatSellingDrink.Core.Exceptions;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class AdminAutomatService : IAdminAutomatService
    {
        private readonly IAdminAutomatRepository _adminAutomatRepository;

        public AdminAutomatService(
            IAdminAutomatRepository adminAutomatRepository)
        {
            _adminAutomatRepository = adminAutomatRepository;
        }
        public async Task<Core.Models.Drink> CreateDrinkAsync(Core.Models.Drink drink)
        {
            var oldDrink = await GetDrinkAsync(drink.Name);
            if (oldDrink != null)
            {
                throw new DrinkExistException("Такой напиток уже существует");
            }
            return await _adminAutomatRepository.CreateDrinkAsync(drink);
        }

        public async Task DeleteDrinkByNameAsync(string nameDrink)
        {
            await _adminAutomatRepository.DeleteDrinkByNameAsync(nameDrink);
        }

        public async Task<Core.Models.Drink> UpdateDrinkAsync(Core.Models.Drink drink)
        {
           return await _adminAutomatRepository.UpdateDrinkAsync(drink);
        }

        public async Task<Core.Models.Drink> GetDrinkAsync(string name)
        {
            var result = await _adminAutomatRepository.GetDrinkAsync(name);
            return result;
        }

        public async Task<Core.Models.Drink[]> GetAllDrinksAsync()
        {
            var result = await _adminAutomatRepository.GetAllDrinksAsync();
            return result;
        }

        public async Task<Core.Models.Coin> CreateCoinAsync(Core.Models.Coin coin)
        {
            var oldDrink = await GetCoinAsync(coin);
            if (oldDrink != null)
            {
                throw new CoinExistException("Такая монета уже существует");
            }

            if (coin.Cost <=0 )
            {
                throw new NotAllowCoinException("Стоимость монеты должна быть больше 0");
            }
            return await _adminAutomatRepository.CreateCoinAsync(coin);
        }
        
        public async Task<Core.Models.Coin> UpdateCoinAsync(Core.Models.Coin coin)
        {
            if (coin.Cost <=0 )
            {
                throw new NotAllowCoinException("Стоимость монеты должна быть больше 0");
            }
           return await _adminAutomatRepository.UpdateCoinAsync(coin);
        }

        public async Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin)
        {
            var result = await _adminAutomatRepository.GetCoinAsync(coin);
            return result;
        }

        public async Task<Core.Models.Coin[]> GetAllCoinsAsync()
        {
            var result = await _adminAutomatRepository.GetAllCoinsAsync();
            return result;
        }

    }
}