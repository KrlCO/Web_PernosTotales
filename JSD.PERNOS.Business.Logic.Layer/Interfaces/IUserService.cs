using JSD.SUNKU.DTO;

namespace JSD.SUNKU.Business.Logic.Layer.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(UserCredentialsDto credentialsDto);
    }
}
