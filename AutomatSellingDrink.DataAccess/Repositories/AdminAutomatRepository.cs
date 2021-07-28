using System;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class AdminAutomatRepository : IAdminAutomatRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminAutomatRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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