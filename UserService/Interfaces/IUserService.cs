using UserService.Models;
using UserService.Models.Request;
using UserService.Models.Response;

namespace UserService.Interfaces
{
    public interface IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public User GetById(int id);
        public void Register(RegisterRequest model);
    }   
}
