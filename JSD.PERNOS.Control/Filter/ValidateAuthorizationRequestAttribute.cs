using JSD.SUNKU.Control.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Filter
{
    public class ValidateAuthorizationRequestAttribute : ActionFilterAttribute
    {
        private readonly BaseControl _basecontrol;

        public ValidateAuthorizationRequestAttribute()
        {
            _basecontrol = new BaseControl();

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string authorization = context.HttpContext.Request.Headers["Authorization"];

                if (string.IsNullOrEmpty(authorization))
                {
                    var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_CABECERA_AUTHORIZATION_NULO_CODIGO, "No se ha encontrado parámetro Authorization en la cabecera de la solicitud.");
                    context.Result = new UnauthorizedObjectResult(mensaje);
                    return;
                }

                string token;
                if (!authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_TOKEN_FORMATO_INCORRECTO_CODIGO, "Formato incorrecto de parámetro Authorization en la cabecera de la solicitud, 'Bearer ' es requerido.");

                    throw new Exception(mensaje);
                }
                else
                    token = authorization.Substring("Bearer ".Length).Trim();

                if (string.IsNullOrEmpty(token))
                {
                    var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_TOKEN_NULO_CODIGO, "No se ha encontrado Token en la cabecera del Request.");

                    throw new Exception(mensaje);
                }

                _basecontrol.ValidarTokenSesion(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
