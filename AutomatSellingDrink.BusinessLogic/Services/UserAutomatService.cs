using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class UserAutomatService : IUserAutomatService
    {
        private readonly IUserAutomatRepository _userAutomatRepository;


        public UserAutomatService(IUserAutomatRepository userAutomatRepository)
        {
            _userAutomatRepository = userAutomatRepository;
        }
        public async Task DepositCoin(Core.Models.Coin coin)
        {
            await _userAutomatRepository.DepositCoin(coin);
        }


        public async Task<Core.Models.Coin[]> GetChange(Core.Models.User user)
        {
            return await _userAutomatRepository.GetChange(user);
        }

        public  async Task<Core.Models.Coin[]> GetAvailableDepositCoins()
        {
            return await _userAutomatRepository.GetAvailableDepositCoins();
        }

        public async Task BuyDrink(Core.Models.Drink drink, Core.Models.User user)
        {
            int summ = 0;
            foreach (var coin in user.Coins)
            {
                summ += coin.Cost;
            }
            
            if (drink.Cost <= summ)
            {
                
            }
            await _userAutomatRepository.BuyDrink();
        }

        public async Task GetAvailableDrinks()
        {
            
        }
    }
}