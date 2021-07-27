using System.Threading.Tasks;

namespace AutomatSellingDrink.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<Core.Models.User> CreateUser(Core.Models.User user);
        Task<Core.Models.User> GetUser(Core.Models.User user);
    }
}