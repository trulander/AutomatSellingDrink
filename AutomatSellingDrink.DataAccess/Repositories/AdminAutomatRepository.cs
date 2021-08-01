using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using AutomatSellingDrink.Core.Exceptions;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using Microsoft.EntityFrameworkCore;
using Coin = AutomatSellingDrink.DataAccess.Entities.Coin;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class AdminAutomatRepository : IAdminAutomatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public AdminAutomatRepository(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<Core.Models.Drink> CreateDrinkAsync(Core.Models.Drink newDrink)
        {
            var result = await _applicationDbContext.Drinks.AddAsync(_mapper.Map<Entities.Drink>(newDrink));
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<Entities.Drink,Core.Models.Drink>(result.Entity);
        }

        public async Task DeleteDrinkByNameAsync(string nameDrink)
        {
            _applicationDbContext.Drinks.RemoveRange(_applicationDbContext.Drinks.Where(x=>x.Name == nameDrink));
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Core.Models.Drink> UpdateDrinkAsync(Drink drink)
        {
            var updatedDrink = await _applicationDbContext.Drinks.Where(x => x.Name == drink.Name).FirstOrDefaultAsync();
            updatedDrink.Name = drink.Name;
            updatedDrink.Cost = drink.Cost;
            updatedDrink.FileId = drink.FileId;
            updatedDrink.Count = drink.Count;

            _applicationDbContext.SaveChangesAsync();
            
            return _mapper.Map<Entities.Drink, Core.Models.Drink>(updatedDrink);
        }

        public async Task<Core.Models.Drink> GetDrinkAsync(string name)
        {
            var result = await _applicationDbContext.Drinks.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Drink,Core.Models.Drink>(result);
        }
        

        public async Task<Core.Models.Drink[]> GetAllDrinksAsync()
        {
            var drinks = await _applicationDbContext.Drinks.Include(x=>x.Image).ToArrayAsync();
            List<Core.Models.Drink> result = new List<Drink>();
            foreach (var drink in drinks)
            {
                result.Add(_mapper.Map<Entities.Drink, Core.Models.Drink>(drink));
            }
            return result.ToArray();
        }

        public async Task<Core.Models.Coin> CreateCoinAsync(Core.Models.Coin coin)
        {
            var result = await _applicationDbContext.Coins.AddAsync(_mapper.Map<Core.Models.Coin, Entities.Coin>(coin));
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<Entities.Coin,Core.Models.Coin>(result.Entity);
        }
        
        public async Task<Core.Models.Coin> UpdateCoinAsync(Core.Models.Coin coin)
        {
            var newCoin = await _applicationDbContext.Coins.Where(X => X.Cost == coin.Cost).FirstOrDefaultAsync();
            
            if (coin == null )
            {
                throw new CoinNotFoundException("Такой монеты не существует");
            }

            newCoin.Cost = coin.Cost;
            newCoin.Count = coin.Count;
            newCoin.IsAllowToDeposit = coin.IsAllowToDeposit;
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<Entities.Coin, Core.Models.Coin>(newCoin);
        }

        public async Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin)
        {
            var result = await _applicationDbContext.Coins.Where(X => X.Cost == coin.Cost).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Coin, Core.Models.Coin>(result);
        }
        
        public async Task<Core.Models.Coin[]> GetAllCoinsAsync()
        {
            var coins = await _applicationDbContext.Coins.ToArrayAsync();
            List<Core.Models.Coin> result = new List<Core.Models.Coin>();
            foreach (var coin in coins)
            {
                result.Add(_mapper.Map<Entities.Coin, Core.Models.Coin>(coin));
            }
            return result.ToArray();
        }
    }
}