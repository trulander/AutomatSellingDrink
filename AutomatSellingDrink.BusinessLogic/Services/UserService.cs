using System.Threading.Tasks;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;

namespace AutomatSellingDrink.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<Core.Models.User> CreateUser(string sessionId)
        {
            Core.Models.User user = new User()
            {
                SessionId = sessionId
            };
            return await _userRepository.CreateUser(user);
        }
        
        public async Task<Core.Models.User> GetUser(Core.Models.User user)
        {
            return await _userRepository.GetUser(user);
        }
    }
}