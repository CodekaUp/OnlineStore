using AutoMapper;
using UserService.Models;
using UserService.Models.Request;
using UserService.Models.Response;

namespace UserService.Helpers
{
    /// <summary>
    /// Сопоставление объектов принадлежащих к разным типам
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponse>();
            CreateMap<RegisterRequest, User>();
        }
    }
}
