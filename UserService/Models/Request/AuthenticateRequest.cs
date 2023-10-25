using System.ComponentModel.DataAnnotations;

namespace UserService.Models.Request
{
    /// <summary>
    /// Запрос(аутентификация)
    /// </summary>
    public class AuthenticateRequest
    {
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
