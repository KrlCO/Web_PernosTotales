using System.Net;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Handlers
{
    public static class ErroresControl
    {
        public static void ManejarErrores(string tipoerror, out HttpStatusCode httpstatuscode, out string titulo)
        {
            switch (tipoerror)
            {
                case ConstantesError.ERROR_TOKEN_FORMATO_INCORRECTO_CODIGO:
                    httpstatuscode = HttpStatusCode.Unauthorized;
                    titulo = ConstantesError.ERROR_TOKEN_FORMATO_INCORRECTO_MENSAJE;
                    break;
                case ConstantesError.ERROR_TOKEN_NULO_CODIGO:
                    httpstatuscode = HttpStatusCode.Unauthorized;
                    titulo = ConstantesError.ERROR_TOKEN_NULO_MENSAJE;
                    break;
                case ConstantesError.ERROR_CABECERA_AUTHORIZATION_NULO_CODIGO:
                    httpstatuscode = HttpStatusCode.Unauthorized;
                    titulo = ConstantesError.ERROR_CABECERA_AUTHORIZATION_NULO_MENSAJE;
                    break;
                case ConstantesError.ERROR_USUARIO_NO_AUTORIZADO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_USUARIO_NO_AUTORIZADO_MENSAJE;
                    break;
                case ConstantesError.ERROR_NO_AUTENTICADO_EN_AD_CODIGO:
                    httpstatuscode = HttpStatusCode.Unauthorized;
                    titulo = ConstantesError.ERROR_NO_AUTENTICADO_EN_AD_MENSAJE;
                    break;
                case ConstantesError.ERROR_FALLA_INICIO_SESION_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_FALLA_INICIO_SESION_MENSAJE;
                    break;
                case ConstantesError.ERROR_PARAMETRO_CABECERA_REQUIREDO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_PARAMETRO_CABECERA_REQUIREDO_MENSAJE;
                    break;
                case ConstantesError.ERROR_USUARIO_NO_EXISTE_CODIGO:
                    httpstatuscode = HttpStatusCode.NotFound;
                    titulo = ConstantesError.ERROR_USUARIO_NO_EXISTE_MENSAJE;
                    break;
                case ConstantesError.ERROR_CONTRASENA_INCORRECTO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_CONTRASENA_INCORRECTO_MENSAJE;
                    break;
                case ConstantesError.ERROR_APLICACION_NO_EXISTE_CODIGO:
                    httpstatuscode = HttpStatusCode.NotFound;
                    titulo = ConstantesError.ERROR_APLICACION_NO_EXISTE_MENSAJE;
                    break;
                case ConstantesError.ERROR_INVOCAR_AD_SERVICIO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadGateway;
                    titulo = ConstantesError.ERROR_INVOCAR_AD_SERVICIO_MENSAJE;
                    break;
                case ConstantesError.ERROR_AD_USUARIO_CONTRASENA_INVALIDO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_AD_USUARIO_CONTRASENA_INVALIDO_MENSAJE;
                    break;
                case ConstantesError.ERROR_AD_USUARIO_NO_ACTIVO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_AD_USUARIO_NO_ACTIVO_MENSAJE;
                    break;
                case ConstantesError.ERROR_TOKEN_EXPIRADO_CODIGO:
                    httpstatuscode = HttpStatusCode.Unauthorized;
                    titulo = ConstantesError.ERROR_TOKEN_EXPIRADO_MENSAJE;
                    break;
                case ConstantesError.ERROR_VALOR_NULO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_VALOR_NULO_MENSAJE;
                    break;
                case ConstantesError.ERROR_USUARIO_NO_ACTIVO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_USUARIO_NO_ACTIVO_MENSAJE;
                    break;
                case ConstantesError.ERROR_CONTRASENA_NO_VALIDO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_CONTRASENA_NO_VALIDO_MENSAJE;
                    break;
                case ConstantesError.ERROR_MODULO_ENTIDAD_REGISTRAR_FALLA_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_MODULO_ENTIDAD_REGISTRAR_FALLA_MENSAJE;
                    break;
                case ConstantesError.ERROR_MODULO_ENTIDAD_ACTUALIZAR_FALLA_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_MODULO_ENTIDAD_ACTUALIZAR_FALLA_MENSAJE;
                    break;
                case ConstantesError.ERROR_INVOCAR_SERVICIO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_INVOCAR_SERVICIO_MENSAJE;
                    break;
                case ConstantesError.ERROR_INVOCAR_SERVICIO_RESULTADO_NULO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_INVOCAR_SERVICIO_RESULTADO_NULO_MENSAJE;
                    break;
                case ConstantesError.ERROR_ENTIDAD_NO_EXISTE_ID_CODIGO:
                    httpstatuscode = HttpStatusCode.NotFound;
                    titulo = ConstantesError.ERROR_ENTIDAD_NO_EXISTE_ID_MENSAJE;
                    break;
                case ConstantesError.ERROR_ENTIDAD_CAMPO_REQUERIDO_CODIGO:
                    httpstatuscode = HttpStatusCode.BadRequest;
                    titulo = ConstantesError.ERROR_ENTIDAD_CAMPO_REQUERIDO_MENSAJE;
                    break;
                default:
                    httpstatuscode = HttpStatusCode.InternalServerError;
                    titulo = ConstantesError.ERROR_NO_CONTROLADO_MENSAJE;
                    break;
            }
        }
    }
}
