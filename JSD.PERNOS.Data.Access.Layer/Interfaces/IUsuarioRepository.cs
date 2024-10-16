using JSD.SUNKU.Business.Entity.Layer;
using System.Collections.Generic;

namespace JSD.SUNKU.Data.Access.Layer.Interfaces
{
    public interface IUsuarioRepository
    {
        bool Registrar(Usuario usuario);
        bool Editar(Usuario usuario);
        IEnumerable<Usuario> GetUsuarios(string estado, string tipoUser);
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioContrasenaById(int id);
        bool ExisteUsuario(string userName);
        bool ChangePassword(Usuario usuario);
        bool Eliminar(Usuario usuario);
    }
}
