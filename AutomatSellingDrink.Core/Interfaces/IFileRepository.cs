using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IFileRepository
    {
        Task<Core.Models.File> UploadFileAsync(File newFile);
    }
}