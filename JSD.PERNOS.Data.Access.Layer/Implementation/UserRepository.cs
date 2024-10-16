using JSD.PERNOS.Data.Access.Layer.Implementation;
using JSD.PERNOS.Data.Access.Layer.Utils;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace JSD.SUNKU.Data.Access.Layer.Implementation
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly string passphrase = null;

        public UserRepository(DataProtector dataProtector, IConfiguration configuration) : base(dataProtector)
        {
            passphrase = configuration.GetValue<string>("PASSPHRASESUNKUU");
        }

        public User GetUser(string userLogin, string passLogin)
        {
            var parameters = new SqlParameter[]
            {
                new("@UserLogin", SqlDbType.VarChar, 50){ Value = userLogin},
                new("@PassLogin", SqlDbType.VarChar, 50){ Value = passLogin},
                new("@Passphrase", SqlDbType.VarChar, 50){ Value = passphrase},
            };

            return GetEntity<User>("Access_Get_User", parameters);
        }
    }
}
