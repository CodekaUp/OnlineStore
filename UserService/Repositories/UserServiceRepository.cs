using AutoMapper;
using UserService.Database;
using UserService.Helpers;
using UserService.Interfaces;
using UserService.Models;
using UserService.Models.Request;
using UserService.Models.Response;

namespace UserService.Repositories
{
    public class UserServiceRepository : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserServiceRepository(DataContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        /// <summary>
        /// Аутентификация пользователя 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                throw new AppException("Неверный email или password");
            }

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            return response;
        }

        /// <summary>
        /// Получение пользователя по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return GetUser(id);
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <exception cref="AppException"></exception>
        public void Register(RegisterRequest model)
        {
            if(_context.Users.Any(x => x.Email == model.Email))
            {
                throw new AppException("Email " + model.Email + "уже занят");
            }

            var user = _mapper.Map<User>(model);
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private User GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new KeyNotFoundException("Пользователь не найден");
            }

            return user;
        }
    }
}
