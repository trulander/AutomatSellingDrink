using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using AutomatSellingDrink.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using File = AutomatSellingDrink.Core.Models.File;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ApplicationDbContext _applicationDbContext;
        private string _path;

        public FileService(
            IFileRepository fileRepository,
            IConfiguration configuration, 
            IMapper mapper,
            IWebHostEnvironment appEnvironment
            )
        {
            _fileRepository = fileRepository;
            _configuration = configuration;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            
            _path = configuration.GetSection("PathUploadFiles").Value;
            DirectoryInfo dirInfo = new DirectoryInfo(_path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
       }
        public async Task<File> UploadFileAsync(IFormFile uploadedFile)
        {
            string path = _path + uploadedFile.FileName;
            
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
            
            var result = await _fileRepository.UploadFileAsync(new Core.Models.File()
            {
                Name = uploadedFile.FileName,
                Path = path
            });
            
            return result;
        }
    }
}