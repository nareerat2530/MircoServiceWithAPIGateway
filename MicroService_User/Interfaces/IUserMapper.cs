using MicroService_User.Models;

namespace MicroService_User.Interfaces
{
    public interface IUserMapper
    {
        User Map(User model);
        User Map(PutViewModel model, User user );
    }
}
