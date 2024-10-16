using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.DTO;
using System.Collections.Generic;

namespace JSD.SUNKU.Business.Logic.Layer.Interfaces
{
    public interface IUsuarioService
    {
        Result<bool> Registrar(UsuarioDto usuario, UserJWT userJWT);
        Result<bool> Editar(UsuarioDto usuario, UserJWT userJWT);
        Result<bool> Eliminar(int id, UserJWT userJWT);
        Result<bool> ChangePassword(UsuarioPasswordDto usuario, UserJWT userJWT);
        IEnumerable<Usuario> GetUsuarios(string tipoUser);
        Usuario GetUsuarioById(int id);
    }
}
