using Microsoft.AspNetCore.Mvc.Filters;
using System;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Filter
{
    public class ValidateAppHeadersRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string appkey = context.HttpContext.Request.Headers["X-AppKey"];
            string appcode = context.HttpContext.Request.Headers["X-AppCode"];

            string appkeyAppSetting = Util.Util.ObtenerValorParametro("AppKey");
            string appCodeAppSetting = Util.Util.ObtenerValorParametro("AppCode");

            if (string.IsNullOrEmpty(appkey))
            {
                var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_PARAMETRO_CABECERA_REQUIREDO_CODIGO, "Cabecera X-AppKey es requerido.");
                throw new Exception(mensaje);
            }

            if (string.IsNullOrEmpty(appcode))
            {
                var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_PARAMETRO_CABECERA_REQUIREDO_CODIGO, "Cabecera X-AppCode es requerido.");
                throw new Exception(mensaje);
            }

            if (appkey != appkeyAppSetting)
            {
                var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_APPKEY_INCORRECCTO_CODIGO, "Cabecera X-AppKey no es correcta.");
                throw new Exception(mensaje);
            }

            if (appcode != appCodeAppSetting)
            {
                var mensaje = string.Format("{0}|{1}", ConstantesError.ERROR_APPCODE_INCORRECCTO_CODIGO, "Cabecera X-AppCode no es correcto.");
                throw new Exception(mensaje);
            }

        }
    }
}
