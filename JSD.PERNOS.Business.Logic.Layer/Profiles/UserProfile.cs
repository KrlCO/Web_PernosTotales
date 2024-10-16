using AutoMapper;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.DTO;

namespace JSD.SUNKU.Business.Logic.Layer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
