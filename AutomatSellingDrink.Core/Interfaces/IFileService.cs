using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IFileService
    {
        Task UploadFileAsync(IFormFile uploadedFile);
    }
}