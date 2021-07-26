using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepositories _fileRepositories;

        public FileService(IFileRepositories fileRepositories)
        {
            _fileRepositories = fileRepositories;
        }
        public void UploadFile()
        {
            
        }
    }
}