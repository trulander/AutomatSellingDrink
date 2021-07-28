using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class AdminAutomatService : IAdminAutomatService
    {
        private readonly IAdminAutomatRepository _adminAutomatRepository;

        public AdminAutomatService(IAdminAutomatRepository adminAutomatRepository)
        {
            _adminAutomatRepository = adminAutomatRepository;
        }
        public void CreateDrink()
        {
            
        }

        public void DeleteDrink()
        {
            
        }

        public void UpdateDrink()
        {
            
        }

        public void GetDrink()
        {
            
        }

        public void GetAllDrinks()
        {
            
        }

        public void UpdateQuantityCoins()
        {
            
        }

        public void GetQuantityCoins()
        {
            
        }

        public void UpdateAvailableDepositCoins()
        {
            
        }

        public void GetAvailableDepositCoins()
        {
            
        }
    }
}