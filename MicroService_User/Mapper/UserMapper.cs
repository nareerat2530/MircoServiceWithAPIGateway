using MicroService_User.Interfaces;
using MicroService_User.Models;

namespace MicroService_User.Mapper
{
    public class UserMapper : IUserMapper
    {
        public User Map(User model)
        {
            var user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                ProfileImage = model.ProfileImage,
            };
            return user;
        }

        public User Map(PutViewModel model, User user)
        { 
            user.Name = model.Name;
            user.Address = model.Address;
            user.ProfileImage = model.ProfileImage;
            return user;

        }
    }
}
