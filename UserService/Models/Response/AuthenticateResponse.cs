namespace UserService.Models.Response
{
    /// <summary>
    /// Ответ(аутентификация)
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// ИД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; }
    }
}
