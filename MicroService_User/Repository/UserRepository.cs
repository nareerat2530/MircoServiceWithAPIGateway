using MicroService_User.Data;
using MicroService_User.Interfaces;
using MicroService_User.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroService_User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewUser(User user)
        {
            try
            {
               await _context.Users.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool UpdatedUser(User user)
        {

            try
            {
                _context.Users.Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
