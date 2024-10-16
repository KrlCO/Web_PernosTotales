using JSD.SUNKU.DTO;

namespace JSD.SUNKU.Control.Interface
{
    public interface IAccessControl
    {
        string generateToken(UserDto user);
    }
}
