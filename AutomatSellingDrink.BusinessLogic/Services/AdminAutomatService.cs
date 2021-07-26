using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class AdminAutomatService : IAdminAutomatService
    {
        private readonly IAdminAutomatRepositories _adminAutomatRepositories;

        public AdminAutomatService(IAdminAutomatRepositories adminAutomatRepositories)
        {
            _adminAutomatRepositories = adminAutomatRepositories;
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