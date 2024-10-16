using JSD.SUNKU.Business.Entity.Layer.Utils;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
//using static JSD.SUNKU.Control.Util.Constants;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthenticationExtensions
    {
        //public static void AddAutenticacion(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var secretKey = configuration.GetValue<string>("TokenClave");
        //    services.AddAuthentication(auth =>
        //    {
        //        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(jwt =>
        //    {
        //        jwt.RequireHttpsMetadata = false;
        //        jwt.SaveToken = false;
        //        jwt.TokenValidationParameters = new TokenValidationParameters()
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        //            ValidateIssuer = false,
        //            ValidateAudience = false,
        //            ClockSkew = TimeSpan.Zero
        //        };

        //        jwt.Events = new JwtBearerEvents
        //        {
        //            OnMessageReceived = context =>
        //            {
        //                var accessToken = context.Request.Query["access_token"];

        //                // If the request is for our hub...
        //                var path = context.HttpContext.Request.Path;
        //                if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chatHub")))
        //                {
        //                    // Read the token out of the query string
        //                    context.Token = accessToken;
        //                }
        //                return Task.CompletedTask;
        //            }
        //        };
        //    });

        //    services.AddAuthorization(opciones =>
        //    {
        //        const string TIPO_USER = ConstantesUsuario.TipoUser;
        //        opciones.AddPolicy(Policys.Admin, policy => policy.RequireClaim(TIPO_USER, Perfiles.ADMIN));
        //        opciones.AddPolicy(Policys.Cliente, policy => policy.RequireClaim(TIPO_USER, Perfiles.CLIENTE));
        //        opciones.AddPolicy(Policys.Tecnico, policy => policy.RequireClaim(TIPO_USER, Perfiles.TECNICO));
        //        opciones.AddPolicy(Policys.Operador, policy => policy.RequireClaim(TIPO_USER, Perfiles.OPERADOR));

        //        opciones.AddPolicy(Policys.OperadorOrAdmin, policy =>
        //        {
        //            policy.RequireClaim(TIPO_USER, Perfiles.ADMIN, Perfiles.OPERADOR);
        //        });
        //        opciones.AddPolicy(Policys.ClienteOrTecnico, policy =>
        //        {
        //            policy.RequireClaim(TIPO_USER, Perfiles.CLIENTE, Perfiles.TECNICO);
        //        });


        //        //opciones.AddPolicy(Policys.Reporteador, policy =>
        //        //{
        //        //    policy.RequireClaim(claimPerfil, Perfiles.FUL, Perfiles.ADMIN);
        //        //});
        //    });
        //}
    }
}
