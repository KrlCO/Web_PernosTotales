using JSD.SUNKU.Control.Security;
using System;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Base
{
    public class BaseControl
    {
        private readonly ITokenControl _tokencontrol;

        public BaseControl()
        {
            _tokencontrol = new TokenControl();
        }

        #region token
        public void ValidarTokenSesion(string token)
        {
            try
            {
                var paramkeytoken = Util.Util.ObtenerValorParametro(ConstantesParametros.TokenClave);
                _tokencontrol.IsTokenJWTValid(paramkeytoken, token);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string ObtenerValorClaimToken(string token, string tipoclaim)
        {
            try
            {
                token = token.Contains("Bearer ") ? token.Replace("Bearer ", "") : token;

                var paramkeytoken = Util.Util.ObtenerValorParametro(ConstantesParametros.TokenClave);

                var valorclaim = _tokencontrol.GetClaimValueByToken(paramkeytoken, tipoclaim, token);

                return valorclaim;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
