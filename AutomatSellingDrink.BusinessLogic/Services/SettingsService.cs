using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }
        
        public async Task SaveSettingsAsync(Core.Models.Settings settings)
        {
            await _settingsRepository.SaveSettingsAsync(settings);
        }
        
        public async Task<Core.Models.Settings> LoadSettingsAsync()
        {
           return await _settingsRepository.LoadSettingsAsync();
        }
    }
}