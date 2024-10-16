using JSD.SUNKU.Control.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace JSD.SUNKU.Control.Util
{
    public static class Util
    {
        // public static object Util { get; internal set; }

        public static string ObtenerValorParametro(string parametro)
        {
            var parametros = ObtenerParametros();

            var valorParametro = parametros.Find(x => x.llave == parametro) == null ? "" : parametros.Find(x => x.llave == parametro).valor;
            return valorParametro;
        }

        public static List<ParametroControlDto> ObtenerParametros()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false)
                   .Build();

                var responseParametros = new List<ParametroControlDto> {
                                                        new ParametroControlDto {llave = "TokenClave" , valor = configuration["TokenClave"] },
                                                        new ParametroControlDto {llave = "TokenMinutos" , valor = configuration["TokenMinutos"] },
                                                        new ParametroControlDto {llave = "AppKey" , valor = configuration["AppKey"] },
                                                        new ParametroControlDto {llave = "AppCode" , valor = configuration["AppCode"] },
                                                        new ParametroControlDto {llave = "APIrutaLogsError" , valor = configuration["APIrutaLogsError"] },
                                                        new ParametroControlDto {llave = "SQLApplicationNameEnableEncrip" , valor = configuration["SQLApplicationNameEnableEncrip"] },
                                                        new ParametroControlDto {llave = "SQLRegeditFolder" , valor = configuration["SQLRegeditFolder"] },
                                                        new ParametroControlDto {llave = "RegeditPass" , valor = configuration["RegeditPass"] }


                };

                return responseParametros;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
