using System.IO;
using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutomatSellingDrink.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController: ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(
            IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadFileAsync(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                await _fileService.UploadFileAsync(uploadedFile);
            }

            return Ok();

        }
    }
}