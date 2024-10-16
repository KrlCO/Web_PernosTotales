using AutoMapper;
using JSD.SUNKU.Business.Logic.Layer.Interfaces;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using JSD.SUNKU.DTO;

namespace JSD.SUNKU.Business.Logic.Layer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public UserDto GetUser(UserCredentialsDto credentialsDto)
        {
            var user = _UserRepository.GetUser(credentialsDto.UserLogin, credentialsDto.PassLogin);
            return _mapper.Map<UserDto>(user);
        }
    }
}
