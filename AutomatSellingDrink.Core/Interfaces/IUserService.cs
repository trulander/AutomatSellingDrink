using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserService
    {
        Task<Core.Models.User> CreateUser(string sessionId);
        Task<Core.Models.User> GetUser(Core.Models.User user);
    }
}