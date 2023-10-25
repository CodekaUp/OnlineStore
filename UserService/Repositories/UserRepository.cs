using AutoMapper;
using UserService.Database;
using UserService.Interfaces;
using UserService.Models;
using UserService.Models.Request;
using UserService.Models.Response;

namespace UserService.Repositories
{
    public class UserRepository : IUser
    {
        private readonly DataContext context;
        public readonly IMapper mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public User Get(int id)
        {
            var user = context.Users.Find(id);
            if(user != null)
            {
                return user;
            }
            else
            {
                throw new InvalidDataException("Пользователь не найден");
            }
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public UserResponse Update(int id, UserRequest request)
        {
            var user = Get(id);
            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Password = request.Password;

                context.SaveChanges();
                var response = mapper.Map<UserResponse>(user);
                return response;
            }
            else
            {
                throw new InvalidDataException("Пользователь не найден");
            }
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidDataException"></exception>
        public void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            else
            {
                throw new InvalidDataException("Пользователь не найден");
            }
        }
    }
}
