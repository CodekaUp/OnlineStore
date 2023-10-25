namespace UserService.Authorization
{
    /// <summary>
    /// Атрибут для определения методов, которые могут быть вызваны анонимно,
    /// без необходимости аутентификации или авторизации
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    {

    }
}
