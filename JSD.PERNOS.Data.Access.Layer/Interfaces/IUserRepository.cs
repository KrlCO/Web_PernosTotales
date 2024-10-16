using JSD.SUNKU.Business.Entity.Layer;

namespace JSD.SUNKU.Data.Access.Layer.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string userLogin, string passLogin);
    }
}
