using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IFileRepository
    {
        Task UploadFileAsync(Core.Models.File newFile);
    }
}