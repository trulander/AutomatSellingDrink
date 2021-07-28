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


        public async Task<Core.Models.Coin[]> GetAvailableCoinsAsync()
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

        public async Task GetAvailableDepositCoinsAsync()
        {
            
        }

        public async Task BuyDrinkAsync()
        {
            
        }

        public async Task GetAvailableDrinksAsync()
        {
            
        }
    }
}