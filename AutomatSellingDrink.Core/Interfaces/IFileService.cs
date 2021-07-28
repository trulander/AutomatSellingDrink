using System.Threading.Tasks;
using AutomatSellingDrink.Core.Models;
using Microsoft.AspNetCore.Http;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IFileService
    {
        Task<File> UploadFileAsync(IFormFile uploadedFile);
    }
}