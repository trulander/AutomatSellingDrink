using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class UserAutomatRepository : IUserAutomatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserAutomatRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void DepositCoins()
        {
            
        }


        public void GetChange()
        {
            
        }

        public void GetAvailableDepositCoins()
        {
            
        }

        public void BuyDrink()
        {
            
        }

        public void GetAvailableDrinks()
        {
            
        }
    }
}