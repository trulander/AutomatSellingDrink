using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class UserAutomatRepository : IUserAutomatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserAutomatRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task DepositCoinAsync(Coin coin)
        {
            var entity = await _applicationDbContext.Coins.Where(x => x.Id == coin.Id).FirstOrDefaultAsync();
            entity.Count = coin.Count;
            _applicationDbContext.Coins.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<Core.Models.Coin[]> GetAllCoinsAsync()
        {
            var coins = await _applicationDbContext.Coins.OrderByDescending(x=>x.Cost).ToArrayAsync();
            List<Core.Models.Coin> result = new List<Core.Models.Coin>();
            foreach (var coin in coins)
            {
                result.Add(_mapper.Map<Entities.Coin, Core.Models.Coin>(coin));
            }
            return result.ToArray();
        }
        
        public async Task<Core.Models.Coin> GetCoinAsync(Core.Models.Coin coin)
        {
            var result = await _applicationDbContext.Coins.Where(X => X.Cost == coin.Cost).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Coin, Core.Models.Coin>(result);
        }
        
        public async Task GetChangeAsync(Core.Models.Coin[] coins)
        {
            foreach (var coin in coins)
            {
                var entity = await _applicationDbContext.Coins.Where(x => x.Id == coin.Id).FirstOrDefaultAsync();
                entity.Count = coin.Count;
                _applicationDbContext.Coins.Update(entity);
            }
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Core.Models.Drink> GetDrinkAsync(string name)
        {
            var result = await _applicationDbContext.Drinks.Where(x => x.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Drink,Core.Models.Drink>(result);
        }

        public async Task BuyDrinkAsync(string name)
        {
            var DrinkForUpdate = await _applicationDbContext.Drinks
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();
            if (DrinkForUpdate.Count > 0)
            {
                DrinkForUpdate.Count -= 1;
            }
            _applicationDbContext.Drinks.Update(
                DrinkForUpdate
            );
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Core.Models.Drink[]> GetDrinksAsync()
        {
            var drinks = await _applicationDbContext.Drinks.OrderBy(x => x.Cost).ToArrayAsync();
            List<Core.Models.Drink> result = new List<Drink>();
            foreach (var drink in drinks) result.Add(_mapper.Map<Entities.Drink, Core.Models.Drink>(drink));
            return result.ToArray();
        }
    }
}