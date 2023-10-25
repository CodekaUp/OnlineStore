using Microsoft.AspNetCore.Mvc;
using UserService.Interfaces;
using UserService.Models.Request;
using UserService.Repositories;

namespace UserService.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user)
        {
            this.user = user;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("users/{id}")]
        public ActionResult Get(int id)
        {
            var response = user.Get(id);
            return Ok(response);
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut, Route("users/{id}")]
        public IActionResult Update(int id, UserRequest request)
        {
            var respone = user.Update(id, request);
            return Ok(respone);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("users/{id}")]
        public IActionResult Delete(int id)
        {
            var response = Delete(id);
            return Ok();
        }
    }
}
