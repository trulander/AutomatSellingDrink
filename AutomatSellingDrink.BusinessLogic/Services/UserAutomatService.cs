using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomatSellingDrink.Core.Exceptions;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class UserAutomatService : IUserAutomatService
    {
        private readonly IUserAutomatRepository _userAutomatRepository;
        private readonly ISettingsService _settingsService;
        private int _userSummMoney = 0;

        public UserAutomatService(IUserAutomatRepository userAutomatRepository, ISettingsService settingsService)
        {
            _userAutomatRepository = userAutomatRepository;
            _settingsService = settingsService;
        }
        public async Task DepositCoinAsync(Core.Models.Coin coin)
        {

            var settings = await _settingsService.LoadSettingsAsync();
            
            if ((coin.Cost == 1 && settings.IsAllowUpload1Coin) || 
                (coin.Cost == 2 && settings.IsAllowUpload2Coin) ||
                (coin.Cost == 5 && settings.IsAllowUpload5Coin) ||
                (coin.Cost == 10 && settings.IsAllowUpload10Coin))
            {
                await _userAutomatRepository.DepositCoinAsync(coin);
                _userSummMoney += coin.Cost;
            }
            else
            {
                throw new NotAllowCoinException("Данная монета не доступна для внесения");
            }
            
        }

        public async Task<Core.Models.Coin[]> GetChangeAsync()
        {
            var rawCoins = await _userAutomatRepository.GetAllCoinsAsync();
            List<Coin> toCgangeCoins = new List<Coin>();

            Dictionary<int, int> allCoins = new Dictionary<int, int>();
            
            foreach (var coin in rawCoins)
            {
                if (allCoins.ContainsKey(coin.Cost))
                {
                    allCoins[coin.Cost] += 1;
                }
                else
                {
                    allCoins.Add(coin.Cost, 1);
                }
            }
            
            int coveredPrice(int summToChange,int price, int maxNo)
            {
                int counted = 0;
                int Num = summToChange / price;
                if (maxNo == 0)
                    return 0;
                if (maxNo != -1)             //-i is infinit
                    if (Num > maxNo - counted)
                        Num = maxNo;
                for (int i = 0; i < Num; i++)
                {
                    toCgangeCoins.Add(new Coin()
                    {
                        Cost = price
                    });
                }
                return Num * price;
            }

            var test = allCoins.Reverse().ToArray();
            for (int i = 0; i < allCoins.Count; i++)
            {
                _userSummMoney -= coveredPrice(_userSummMoney,test[i].Key,test[i].Value);
            }
            return await _userAutomatRepository.GetChangeAsync(toCgangeCoins.ToArray());
        }

        public async Task<Core.Models.Settings> GetAvailableDepositCoins()
        {
            return await _settingsService.LoadSettingsAsync();
        }

        public async Task<int> BuyDrinkAsync(Core.Models.Drink drink)
        {
            Core.Models.Drink drinkFromDb = await _userAutomatRepository.GetDrinkAsync(drink);
            if (drinkFromDb == null)
            {
                throw new DrinkNotFoundException("Напитка нет в наличии");
            }
            if (drinkFromDb.Cost <= _userSummMoney)
            {
                _userSummMoney -= drinkFromDb.Cost;
                await _userAutomatRepository.BuyDrinkAsync(drinkFromDb);
            }
            else
            {
                throw new NeedMoreMoneyException("Не достаточно денег для покупки выбранного написка");
            }
            
            return _userSummMoney;
        }

        public async Task<Core.Models.Drink[]> GetAvailableDrinks()
        {
            var result = await _userAutomatRepository.GetAvailableDrinksAsync();
            if (result == null || result.Length == default(int))
            {
                throw new DrinkNotFoundException("Ни одного напитка нет в наличии");
            }
            return result;
        }
    }
}