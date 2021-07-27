using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using AutomatSellingDrink.DataAccess.Entities;
using Coin = AutomatSellingDrink.Core.Models.Coin;
using IMapper = AutoMapper.IMapper;

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
        public async Task DepositCoin(Coin coin)
        {
            var entity = _mapper.Map<Core.Models.Coin, Entities.Coin>(coin);
            
            var result = _applicationDbContext.Coins.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<Core.Models.Coin[]> GetChange(Core.Models.User user)
        {
            List<Core.Models.Coin> result = new List<Core.Models.Coin>();
            var coins = _applicationDbContext.Coins.Where(x => x.Owner.Id == user.Id).ToArray();
            foreach (var coin in coins)
            {
                result.Add(_mapper.Map<Entities.Coin, Core.Models.Coin>(coin));
            }

            return result.ToArray();
        }

        public async Task<Core.Models.Coin[]> GetAvailableDepositCoins()
        {
            List<Core.Models.Coin> result = new List<Core.Models.Coin>();
            var coins = _applicationDbContext.AvailableDepositCoins.Select(x=>x.Cost).Distinct().ToArray();
            
            foreach (var coin in coins)
            {
                result.Add(new Coin()
                {
                    Cost = coin
                });
            }

            return result.ToArray();
        }

        public async Task BuyDrink()
        {
            
        }

        public void GetAvailableDrinks()
        {
            
        }
    }
}