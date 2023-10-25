using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Interfaces;
using UserService.Models.Request;

namespace UserService.Controllers
{
    [Authorization.Authorize]
    [Route("")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;

        public AuthenticationController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Аутентификация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorization.AllowAnonymous]
        [HttpPost, Route("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = userService.Authenticate(model);
            return Ok(response);
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorization.AllowAnonymous]
        [HttpPost, Route("register")]
        public IActionResult Register(RegisterRequest model)
        {
            userService.Register(model);
            return Ok(new { message = "Регистрация успешна" });
        }

        /// <summary>
        /// Получение пользователя по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = userService.GetById(id);
            return Ok(user);
        }
    }
}
