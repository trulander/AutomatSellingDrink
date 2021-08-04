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
        private  IUserAutomatRepository _userAutomatRepository;
        private readonly IUserMemoryService _userMemoryService;

        public UserAutomatService(
            IUserAutomatRepository userAutomatRepository,
            IUserMemoryService userMemoryService)
        {
            _userAutomatRepository = userAutomatRepository;
            _userMemoryService = userMemoryService;
        }

        public async Task<Core.Models.Balance> DepositCoinAsync(Core.Models.Coin addCoin)
        {
            var coin = await GetCoinAsync(addCoin);


            if (coin != null && coin.Cost == addCoin.Cost && coin.IsAllowToDeposit)
            {
                coin.Count += 1;
                await _userAutomatRepository.DepositCoinAsync(coin);
                _userMemoryService.IncreaseMoney(coin.Cost);
            }
            else
            {
                throw new NotAllowCoinException("Данная монета не доступна для внесения");
            }

            var result = new Balance()
            {
                Summ = _userMemoryService.GetUserMoney()
            };
            
            return result;
        }

        public async Task<Core.Models.Coin[]> GetChangeAsync()
        {
            if (_userMemoryService.GetUserMoney() <= 0)
            {
                throw new NeedMoreMoneyException("Ваш баланс равен 0");
            }
            
            var coins = await _userAutomatRepository.GetAllCoinsAsync();
            List<Core.Models.Coin> result = new List<Coin>();
            
            int coveredPrice(int summToChange,ref Core.Models.Coin coin)
            {
                Core.Models.Coin resultCoin = new Coin()
                {
                    Cost = coin.Cost,
                    Count = 0
                };
                int counted = 0;
                int Num = summToChange / coin.Cost;
                if (coin.Count == 0)
                    return 0;
                if (coin.Count != -1)             //-i is infinit
                    if (Num > coin.Count - counted)
                        Num = coin.Count;
                for (int i = 0; i < Num; i++)
                {
                    resultCoin.Count += 1;
                    coin.Count -= 1;
                }

                if (resultCoin.Count != 0)
                {
                    result.Add(resultCoin);
                }
                
                return Num * coin.Cost;
            }

            var test = coins.Reverse().ToArray();
            for (int i = 0; i < coins.Length; i++)
            {
                if (_userMemoryService.DecreaseMoney(
                    coveredPrice(
                        _userMemoryService.GetUserMoney(), 
                        ref coins[i]
                    )
                ) <= 0)
                {
                    break;
                }
            }
            await _userAutomatRepository.GetChangeAsync(coins);
            return result.ToArray();
        }

        public async Task<Core.Models.Coin[]> GetAllCoinsAsync()
        {
            var result = await _userAutomatRepository.GetAllCoinsAsync();
            return result;
        }
        
        public async Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin)
        {
            var result = await _userAutomatRepository.GetCoinAsync(coin);
            return result;
        }

        public async Task<Core.Models.Balance> BuyDrinkAsync(string name)
        {
            Core.Models.Drink drinkFromDb = await _userAutomatRepository.GetDrinkAsync(name);
            if (drinkFromDb == null || drinkFromDb.Count == 0)
            {
                throw new DrinkNotFoundException("Напитка нет в наличии");
            }
            if (drinkFromDb.Cost <= _userMemoryService.GetUserMoney())
            {
                _userMemoryService.DecreaseMoney(drinkFromDb.Cost);
                await _userAutomatRepository.BuyDrinkAsync(drinkFromDb.Name);
            }
            else
            {
                throw new NeedMoreMoneyException("Не достаточно денег для покупки выбранного написка");
            }
            
            var result = new Balance()
            {
                Summ = _userMemoryService.GetUserMoney()
            };
            return result;
        }

        public async Task<Core.Models.Drink[]> GetAllDrinksAsync()
        {
            var result = await _userAutomatRepository.GetAllDrinksAsync();
            if (result == null || result.Length == default(int))
            {
                throw new DrinkNotFoundException("Ни одного напитка нет в наличии");
            }
            return result;
        }

        public async Task<Balance> GetBalanceAsync()
        {
            var result = new Balance()
            {
                Summ = _userMemoryService.GetUserMoney()
            };
            return result;
        }
    }
}