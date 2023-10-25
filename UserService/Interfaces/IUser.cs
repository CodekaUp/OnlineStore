using UserService.Models;
using UserService.Models.Request;
using UserService.Models.Response;

namespace UserService.Interfaces
{
    public interface IUser
    {
        public User Get(int id);
        public void Delete(int id);
        public UserResponse Update(int id, UserRequest userRequest);
    }
}
