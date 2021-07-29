using System;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteDrinkAsync()
        {
            
        }

        public async Task UpdateDrinkAsync()
        {
            
        }

        public async Task GetDrinkAsync()
        {
            
        }

        public async Task GetAllDrinksAsync()
        {
            
        }

        public async Task UpdateQuantityCoinsAsync()
        {
            
        }

        public async Task GetQuantityCoinsAsync()
        {
            
        }

        public async Task UpdateAvailableDepositCoinsAsync()
        {
            
        }

        public async Task GetAvailableDepositCoinsAsync()
        {
            
        }
    }
}