using System.Collections.Generic;
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
            _applicationDbContext.Coins.Add(_mapper.Map<Core.Models.Coin, Entities.Coin>(coin));
            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<Core.Models.Coin[]> GetAllCoinsAsync()
        {
            var coins = await _applicationDbContext.Coins.OrderBy(x => x.Cost).ToArrayAsync();
            List<Core.Models.Coin> result = new List<Coin>();
            foreach (var coin in coins) result.Add(_mapper.Map<Entities.Coin, Core.Models.Coin>(coin));
            return result.ToArray();
        }
        
        public async Task<Core.Models.Coin[]> GetChangeAsync(Core.Models.Coin[] coins)
        {
            List<Core.Models.Coin> result = new List<Coin>();
            foreach (var coin in coins)
            {
                var coinToRemove = new Entities.Coin()
                {
                    Cost = coin.Cost
                };
                //_applicationDbContext.Coins.RemoveRange(_applicationDbContext.Coins.Where(x=>x.Cost = coin.Cost).Take());
                result.Add(
                    _mapper.Map<Entities.Coin,Core.Models.Coin>(
                        _applicationDbContext.Coins.Remove(
                            await _applicationDbContext.Coins.Where(x=>x.Cost == coin.Cost).FirstAsync()).Entity
                        )
                    );    
            }
            await _applicationDbContext.SaveChangesAsync();
            return result.ToArray();

        }

        public async Task<Core.Models.Drink> GetDrinkAsync(Core.Models.Drink drink)
        {
            var result = await _applicationDbContext.Drinks.Where(x => x.Name == drink.Name).FirstOrDefaultAsync();
            return _mapper.Map<Entities.Drink,Core.Models.Drink>(result);
        }

        public async Task BuyDrinkAsync(Core.Models.Drink drink)
        {
            _applicationDbContext.Drinks.Remove(_mapper.Map<Core.Models.Drink, Entities.Drink>(drink));
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<Core.Models.Drink[]> GetAvailableDrinksAsync()
        {
            var drinks = await _applicationDbContext.Drinks.OrderBy(x => x.Cost).ToArrayAsync();
            List<Core.Models.Drink> result = new List<Drink>();
            foreach (var drink in drinks) result.Add(_mapper.Map<Entities.Drink, Core.Models.Drink>(drink));
            return result.ToArray();
        }
    }
}