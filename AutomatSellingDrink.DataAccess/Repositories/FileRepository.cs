using System.Threading.Tasks;
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
        public async Task UploadFileAsync(Core.Models.File newFile)
        {
            Entities.File file = new Entities.File()
            {
                Name = newFile.Name,
                Path = newFile.Path
            };
            await _applicationDbContext.Files.AddAsync(file);
            await _applicationDbContext.SaveChangesAsync(); 
        }
    }
}