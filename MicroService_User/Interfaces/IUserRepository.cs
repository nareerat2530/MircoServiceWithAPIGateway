using MicroService_User.Models;

namespace MicroService_User.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> AddNewUser(User user);
        bool UpdatedUser(User user);
        bool DeleteUser(User user);

    }
}
