using AutoMapper;
using JSD.PERNOS.Business.Logic.Layer.Utils;
using JSD.SUNKU.Business.Entity.Layer;
using JSD.SUNKU.Business.Logic.Layer.Interfaces;
using JSD.SUNKU.Data.Access.Layer.Implementation;
using JSD.SUNKU.Data.Access.Layer.Interfaces;
using JSD.SUNKU.DTO;
using System;
using System.Collections.Generic;

namespace JSD.SUNKU.Business.Logic.Layer.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
            => (_usuarioRepository, _mapper) = (usuarioRepository, mapper);

        public Result<bool> Registrar(UsuarioDto usuarioDto, UserJWT userJWT)
        {
            var result = new Result<bool>();
            var existe = _usuarioRepository.ExisteUsuario(usuarioDto.CodUsuario);
            if (existe)
            {
                return result.BadRequest($"El usuario con DNI: {usuarioDto.CodUsuario} ya fue registrado.");
            }
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.UserName = usuario.CodUsuario;
            usuario.Estado = Constantes.Estado.Activo;
            usuario.FecRegistra = DateTime.Now;
            usuario.UsrRegistra = userJWT.CodUsuario;
            result.Resultado = _usuarioRepository.Registrar(usuario);
            return result;
        }

        public Result<bool> Editar(UsuarioDto usuarioDto, UserJWT userJWT)
        {
            var result = new Result<bool>();

            var usuarioExistente = _usuarioRepository.GetUsuarioContrasenaById(usuarioDto.Id);
            if (usuarioExistente == null || usuarioExistente.Id == 0)
            {
                return result.BadRequest($"El usuario no existe.");
            }

            var usuario = _mapper.Map<Usuario>(usuarioDto);
            usuario.UsrModifica = userJWT.CodUsuario;
            usuario.FecModifica = DateTime.Now;

            result.Resultado = _usuarioRepository.Editar(usuario);
            return result;
        }

        public Result<bool> Eliminar(int id, UserJWT userJWT)
        {
            var result = new Result<bool>();

            var usuarioExistente = _usuarioRepository.GetUsuarioById(id);
            if (usuarioExistente == null || usuarioExistente.Id == 0)
            {
                return result.BadRequest($"El usuario no existe.");
            }

            var usuario = new Usuario();
            usuario.Id = id;
            usuario.Estado = Constantes.Estado.Inactivo;
            usuario.UsrModifica = userJWT.CodUsuario;
            usuario.FecModifica = DateTime.Now;
            result.Resultado = _usuarioRepository.Eliminar(usuario);
            return result;
        }

        public Result<bool> ChangePassword(UsuarioPasswordDto usuarioDto, UserJWT userJWT)
        {
            var result = new Result<bool>();
            var usuario = _mapper.Map<Usuario>(new UsuarioDto()
            {
                Id = userJWT.IdUser,
                PassUser = usuarioDto.Password
            });
            usuario.UsrModifica = userJWT.CodUsuario;
            result.Resultado = _usuarioRepository.ChangePassword(usuario);
            if (!result.Resultado)
            {
                return result.NotFound("Usuario no encontrado.");
            }
            return result;
        }

        public IEnumerable<Usuario> GetUsuarios(string tipoUser) => 
            _usuarioRepository.GetUsuarios(Constantes.Estado.Activo, tipoUser);

        public Usuario GetUsuarioById(int id) => 
            _usuarioRepository.GetUsuarioById(id);
    }
}
