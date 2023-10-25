using System.Globalization;

namespace UserService.Helpers
{
    /// <summary>
    /// Исключение
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// Исключение без сообщения
        /// </summary>
        public AppException() : base() { }

        /// <summary>
        /// Исключение с указанным сообщением
        /// </summary>
        /// <param name="message"></param>
        public AppException(string message) : base(message) { }

        /// <summary>
        /// Исключение с форматированным сообщением, в котором можно использовать аргументы 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public AppException(string message, params object[] args) 
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
