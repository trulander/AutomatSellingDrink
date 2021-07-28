using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface ISettingsService
    {
        Task SaveSettingsAsync(Core.Models.Settings settings);
        Task<Core.Models.Settings> LoadSettingsAsync();
    }
}