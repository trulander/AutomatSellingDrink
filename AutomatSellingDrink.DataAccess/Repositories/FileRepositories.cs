using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class FileRepositories : IFileRepositories
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FileRepositories(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void UploadFile()
        {
            
        }
    }
}