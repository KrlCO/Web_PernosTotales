using JSD.SUNKU.Control.Base;
using JSD.SUNKU.Control.Interface;
using JSD.SUNKU.Control.Model;
using JSD.SUNKU.Control.Security;
using JSD.SUNKU.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Implementation
{
    public class AccessControl : BaseControl, IAccessControl
    {
        private readonly ITokenControl _tokencontrol;
        private readonly IConfiguration _configuration;
        public string TokenSesion { get; set; }

        public AccessControl(IConfiguration configuration)
        {
            _tokencontrol = new TokenControl();
            _configuration = configuration;
        }

        public string generateToken(UserDto user)
        {
            var tokenresponse = GenerarTokenJWT(user);
            return tokenresponse.Token;
        }

        #region private methods
        private ResponseContainerModel GenerarTokenJWT(UserDto user)
        {
            var tokenParams = new Dictionary<string, string>
            {
                { ConstantesToken.Key, _configuration[ConstantesParametros.TokenClave] },
                { ConstantesToken.Minutes, _configuration[ConstantesParametros.TokenMinutos] }
            };

            var claims = new Dictionary<string, string>
            {
                { ConstantesUsuario.IdUser, user.Id.ToString() },
                { ConstantesUsuario.CorreoElectronico, user.Email },
                { ConstantesUsuario.NombreUsuario, user.Nombres },
                { ConstantesUsuario.IdPersona, user.IdPersona.ToString() },
                { ConstantesUsuario.TipoUser, user.TipoUser.ToString() },
                { ConstantesUsuario.CodUsuario, user.CodUsuario },
                { ConstantesGenerico.IdentificadorUnico, Guid.NewGuid().ToString() },
                //{ ConstantesUsuario.Perfil, user.Perfiles },
            };

            var responseToken = _tokencontrol.GenerateJwtToken(tokenParams, claims);

            return responseToken;
        }

        #endregion

    }
}
