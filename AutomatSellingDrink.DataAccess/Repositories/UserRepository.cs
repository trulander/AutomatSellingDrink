using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.DataAccess.Entities;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContex;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext applicationDbContex, IMapper mapper)
        {
            _applicationDbContex = applicationDbContex;
            _mapper = mapper;
        }

        public async Task<Core.Models.User> CreateUser(Core.Models.User user)
        {
            var entity = _applicationDbContex.Users.Add(_mapper.Map<Core.Models.User, Entities.User>(user));
            await _applicationDbContex.SaveChangesAsync();
            user.Id = entity.Entity.Id;
            return user;
        }
        
        public async Task<Core.Models.User> GetUser(Core.Models.User user)
        {
            var entity = await _applicationDbContex.Users.FindAsync(_mapper.Map<Core.Models.User, Entities.User>(user));
            return _mapper.Map<Entities.User, Core.Models.User>(entity);
        }
    }
}