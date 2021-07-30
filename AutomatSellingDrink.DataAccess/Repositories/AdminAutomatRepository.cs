using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public async Task DeleteAllDrinksByNameAsync(string nameDrink)
        {
            _applicationDbContext.Drinks.RemoveRange(_applicationDbContext.Drinks.Where(x=>x.Name == nameDrink));
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateDrinkAsync(Drink drink)
        {
            var updatedDrink = _applicationDbContext.Drinks.Where(x => x.Name == drink.Name).ToArray();
            foreach (var unit in updatedDrink)
            {
                unit.Name = drink.Name;
                unit.Cost = drink.Cost;
                unit.FileId = unit.FileId;
            }
            
           // _applicationDbContext.Drinks.UpdateRange(updatedDrink);
            _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Core.Models.Drink> GetDrinkAsync(string name)
        {
            var result = await _applicationDbContext.Drinks.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Drink,Core.Models.Drink>(result);
        }

        public async Task<Core.Models.Drink[]> GetAllDrinksAsync(string name)
        {
            var drinks = await _applicationDbContext.Drinks.Where(x => x.Name == name).ToArrayAsync();
            List<Core.Models.Drink> result = new List<Drink>();
            foreach (var drink in drinks)
            {
                result.Add(_mapper.Map<Entities.Drink, Core.Models.Drink>(drink));
            }
            return result.ToArray();
        }

        public async Task UpdateQuantityCoinsAsync(int coinCost, int quantity)
        {
            var coins = _applicationDbContext.Coins.Where(X => X.Cost == coinCost).ToArray();
            if (coins.Length > quantity)
            {
                List<Entities.Coin> coinsToRemove = new List<Coin>();
                for (int i = 0; i < quantity - coins.Length; i++)
                {
                    coinsToRemove.Add(coins[i]);
                }
                _applicationDbContext.Coins.RemoveRange(coinsToRemove);
            }else if (coins.Length < quantity)
            {
                List<Entities.Coin> coinsToAdd = new List<Coin>();
                for (int i = 0; i < quantity - coins.Length; i++)
                {
                    coinsToAdd.Add(new Coin()
                    {
                        Cost = coinCost
                    });
                }
                await _applicationDbContext.Coins.AddRangeAsync(coinsToAdd);
            }

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> GetQuantityCoinsAsync(int coinCost)
        {
            var result = await _applicationDbContext.Coins.Where(X => X.Cost == coinCost).CountAsync();
            return result;
        }
    }
}