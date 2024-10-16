using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static JSD.SUNKU.Control.Util.Constants;


namespace JSD.SUNKU.Control.Handlers
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public ErrorHandlingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {

            try { context.Request.EnableBuffering(); } catch { }

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptioncontent = ex.Message;
            var arrexcepcion = exceptioncontent.Split("|");
            string exceptionCodigo;
            string exceptionMensaje;

            if (exceptioncontent.Contains(ConstantesToken.ExpiradoCodigoJWT))
            {
                exceptionCodigo = ConstantesError.ERROR_TOKEN_EXPIRADO_CODIGO;
                exceptionMensaje = exceptioncontent;
            }
            else
            {
                exceptionCodigo = arrexcepcion.Length == 1 ? ConstantesError.ERROR_NO_CONTROLADO_CODIGO : arrexcepcion[0];
                exceptionMensaje = arrexcepcion.Length == 1 ? ex.Message : arrexcepcion[1];
            }

            string mensaje = exceptionMensaje;

            ErroresControl.ManejarErrores(exceptionCodigo, out HttpStatusCode httpstatuscode, out string titulo);

            var result = JsonConvert.SerializeObject(new RespuestaError
            {
                error = new RespuestaErrorDetalle
                {
                    codigo = exceptionCodigo,
                    mensaje = mensaje,
                    titulo = titulo
                }
            });

            var mensajeexcepcion = string.Format("Mensaje: {0} , Detalle: {1}", ex.Message, ex.ToString());

            var resultexcepcioncompleta = JsonConvert.SerializeObject(new RespuestaError
            {
                error = new RespuestaErrorDetalle
                {
                    codigo = exceptionCodigo,
                    mensaje = mensajeexcepcion,
                    titulo = titulo
                }
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpstatuscode;

            dynamic jsonrquest = null;

            if (context.Request.Body.CanSeek)
            {
                using (var body = new StreamReader(context.Request.Body))
                {
                    body.BaseStream.Seek(0, SeekOrigin.Begin);
                    var requestBody = await body.ReadToEndAsync();
                    jsonrquest = JsonConvert.DeserializeObject(requestBody);
                }
            }

            var request = new
            {
                headers = context.Request.Headers,
                body = jsonrquest
            };

            GrabarLogError(context.Request.Path, JsonConvert.SerializeObject(request), resultexcepcioncompleta);

            await context.Response.WriteAsync(result);
        }

        private void GrabarLogError(string api, string request, string response)
        {
            StringBuilder sb = new();
            sb.AppendLine($"SGSV.API {DateTime.Now}");
            sb.AppendLine($"REQUEST PATH: {api}");
            sb.AppendLine($"REQUEST: {request}");
            sb.AppendLine($"REPONSE: {response}");
            sb.AppendLine($"{new string('-', 120)}\n");

            GenerarArchivoLog(sb.ToString());
        }

        private void GenerarArchivoLog(string strLog)
        {
            string carpetaLogs = configuration["APIrutaLogsError"];
            string logFilePath = $"{carpetaLogs}Log_SGSV_{DateTime.Today.ToString("dd-MM-yyyy")}.txt";

            var logDirInfo = new DirectoryInfo(carpetaLogs);
            if (!logDirInfo.Exists)
            {
                logDirInfo.Create();
            }

            File.AppendAllText(logFilePath, strLog);
        }
    }
}
