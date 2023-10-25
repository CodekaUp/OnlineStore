using UserService.Interfaces;

namespace UserService.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Метод обработки HTTP-запросов
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userService"></param>
        /// <param name="jwtUtils"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                //прикрепление пользователя к контексту при успешной проверке jwt
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
