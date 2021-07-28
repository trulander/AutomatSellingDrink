using AutomatSellingDrink.Core.Interfaces;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FileRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void UploadFile()
        {
            
        }
    }
}