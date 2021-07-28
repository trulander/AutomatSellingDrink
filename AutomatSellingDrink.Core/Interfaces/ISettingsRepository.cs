using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface ISettingsRepository
    {
        Task SaveSettingsAsync(Core.Models.Settings settings);
        Task<Core.Models.Settings> LoadSettingsAsync();
    }
}