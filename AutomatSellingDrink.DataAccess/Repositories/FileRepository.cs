using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public FileRepository(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<Core.Models.File> UploadFileAsync(File newFile)
        {
            var result = await _applicationDbContext.Files.AddAsync(new Entities.File()
            {
                Name = newFile.Name,
                Path = newFile.Path
            });
            await _applicationDbContext.SaveChangesAsync();
            return _mapper.Map<Entities.File, Core.Models.File>(result.Entity);
        }
    }
}