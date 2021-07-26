using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class UserAutomatService : IUserAutomatService
    {
        private readonly IUserAutomatRepository _userAutomatRepository;

        public UserAutomatService(IUserAutomatRepository userAutomatRepository)
        {
            _userAutomatRepository = userAutomatRepository;
        }
        public void DepositCoins()
        {
            _userAutomatRepository.DepositCoins();
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