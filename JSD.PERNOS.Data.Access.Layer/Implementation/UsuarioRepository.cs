using JSD.PERNOS.Data.Access.Layer.Implementation;
using JSD.PERNOS.Data.Access.Layer.Utils;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JSD.SUNKU.Data.Access.Layer.Implementation
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly string passphrase = null;
        public UsuarioRepository(DataProtector dataProtector, IConfiguration configuration) : base(dataProtector) 
        {
            passphrase = configuration.GetValue<string>("PASSPHRASESUNKUU");
        }

        public bool Registrar(Usuario usuario)
        {
            var sqlParams = new SqlParameter[]
            {
                new("@IdPersona", SqlDbType.Int){ Value = usuario.IdPersona},
                new("@TipoUser", SqlDbType.Char, 1){ Value = usuario.TipoUser},
                new("@CodUsuario", SqlDbType.VarChar, 20){ Value = usuario.CodUsuario},
                new("@Nombres", SqlDbType.VarChar, 50){ Value = usuario.Nombres},
                new("@ApePaterno", SqlDbType.VarChar, 50){ Value = usuario.ApePaterno},
                new("@ApeMaterno", SqlDbType.VarChar, 50){ Value = usuario.ApeMaterno},
                new("@NroContacto", SqlDbType.VarChar, 9){ Value = usuario.NroContacto},
                new("@Email", SqlDbType.VarChar, 100){ Value = usuario.Email},
                new("@UserName", SqlDbType.VarChar, 20){ Value = usuario.UserName},
                new("@PassUser", SqlDbType.VarChar, 50){ Value = usuario.PassUser},
                new("@Estado", SqlDbType.VarChar, 1){ Value = usuario.Estado},
                new("@UsrRegistra", SqlDbType.VarChar, 20){ Value = usuario.UsrRegistra},
                new("@FecRegistra", SqlDbType.DateTime){ Value = usuario.FecRegistra}
            };
            return ExecuteProcedureCRUD("dbo.USP_INSERT_USUARIO", sqlParams);
        }

        public bool Editar(Usuario usuario)
        {
            var sqlParams = new SqlParameter[]
            {
                new("@Id", SqlDbType.Int){ Value = usuario.Id},
                new("@Nombres", SqlDbType.VarChar, 50){ Value = usuario.Nombres},
                new("@CodUsuario", SqlDbType.VarChar, 20){ Value = usuario.CodUsuario},
                new("@ApePaterno", SqlDbType.VarChar, 50){ Value = usuario.ApePaterno},
                new("@ApeMaterno", SqlDbType.VarChar, 50){ Value = usuario.ApeMaterno},
                new("@NroContacto", SqlDbType.VarChar, 9){ Value = usuario.NroContacto},
                new("@Email", SqlDbType.VarChar, 100){ Value = usuario.Email},
                new("@UsrModifica", SqlDbType.VarChar, 20){ Value = usuario.UsrModifica},
                new("@FecModifica", SqlDbType.DateTime){ Value = usuario.FecModifica}
            };
            return ExecuteProcedureCRUD("dbo.USP_UPDATE_USUARIO", sqlParams);
        }

        public IEnumerable<Usuario> GetUsuarios(string estado, string tipoUser)
        {
            return GetEntities<Usuario>(
                "dbo.USP_LISTAR_USUARIOS",
                new SqlParameter("@Estado", SqlDbType.VarChar, 1) { Value = estado },
                new SqlParameter("@TipoUser", SqlDbType.Char, 1) { Value = tipoUser }
            );
        }

        public Usuario GetUsuarioById(int id)
        {
            return GetEntity<Usuario>(
                "dbo.USP_OBTENER_USUARIO",
                new SqlParameter("@Id", SqlDbType.Int) { Value = id }
            );
        }

        public bool ExisteUsuario(string userName)
        {
            return ExisteEntidad(
                "dbo.USP_EXISTE_USUARIO",
                new SqlParameter("@UserName", SqlDbType.VarChar, 20) { Value = userName }
            );
        }

        public bool Eliminar(Usuario usuario)
        {
            var sqlParams = new SqlParameter[]
            {
                new("@Id", SqlDbType.Int) { Value = usuario.Id },
                new("@Estado", SqlDbType.VarChar, 1) { Value = usuario.Estado },
                new("@UsrModifica", SqlDbType.VarChar, 20) { Value = usuario.UsrModifica },
                new("@FecModifica", SqlDbType.DateTime) { Value = usuario.FecModifica }
            };
            return ExecuteProcedureCRUD("dbo.USP_DELETE_USUARIO", sqlParams);
        }

        public bool ChangePassword(Usuario usuario)
        {
            var sqlParams = new SqlParameter[]
              {
                new("@Id", SqlDbType.Int) { Value = usuario.Id },
                new("@Password", SqlDbType.VarChar, 50) { Value = usuario.PassUser },
                new("@UsrModifica", SqlDbType.VarChar, 20) { Value = usuario.UsrModifica },
                new("@Passphrase", SqlDbType.VarChar, 50) { Value = passphrase },
              };

            return ExecuteProcedureCRUD("USP_CHANGE_PASSWORD_USUARIO", sqlParams);
        }

        public Usuario GetUsuarioContrasenaById(int id)
        {
            return GetEntity<Usuario>(
                "dbo.USP_OBTENER_USUARIO_CONTRASENA",
                new SqlParameter("@Id", SqlDbType.Int) { Value = id }
            );
        }
    }
}
