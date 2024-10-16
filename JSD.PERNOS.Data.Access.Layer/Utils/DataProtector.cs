using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

namespace JSD.PERNOS.Data.Access.Layer.Utils
{
    public class DataProtector
    {
        public IDataProtector Protector { get; }
        public readonly string cadenaConexion = null;

        public DataProtector(IConfiguration configuration, IDataProtectionProvider protectorProvider)
        {
            //var purpose = configuration.GetValue<string>("PASSPHRASESUNKUU");
            //Protector = protectorProvider.CreateProtector(purpose);
            //cadenaConexion = Protector.Unprotect(configuration.GetConnectionString("DefaultConnection"));
            cadenaConexion = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
