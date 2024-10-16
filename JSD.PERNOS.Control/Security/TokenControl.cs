using JSD.SUNKU.Control.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static JSD.SUNKU.Control.Util.Constants;

namespace JSD.SUNKU.Control.Security
{
    public class TokenControl : ITokenControl
    {
        public ResponseContainerModel GenerateJwtToken(Dictionary<string, string> dictTokenParam, Dictionary<string, string> dictClaims)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var passwordToken = dictTokenParam.FirstOrDefault(x => x.Key == ConstantesToken.Key).Value;
            var minutesToken = int.Parse(dictTokenParam.FirstOrDefault(x => x.Key == ConstantesToken.Minutes).Value);

            List<Claim> claims = new List<Claim>();
            foreach (var item in dictClaims)
            {
                claims.Add(new Claim(item.Key, item.Value));
            }
            //claims.Add(new Claim(ClaimTypes.Role, "rol1"));
            //claims.Add(new Claim(ClaimTypes.Role, "rol2"));
            //claims.Add(new Claim(ClaimTypes.Name, dictClaims[ConstantesUsuario.NombreUsuario]));

            var key = Encoding.ASCII.GetBytes(passwordToken);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(minutesToken),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var responseContainerModel = new ResponseContainerModel()
            {
                Token = tokenHandler.WriteToken(token),
                FechaInicioVigencia = DateTime.Now,
                FechaFinVigencia = tokenDescriptor.Expires ?? DateTime.UtcNow.AddMinutes(minutesToken)
            };

            return responseContainerModel;
        }

        public string GetClaimValueByToken(string paramkeytoken, string tipoclaim, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(paramkeytoken);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var claim = jwtToken.Claims.First(x => x.Type == tipoclaim).Value;

                return claim;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string IsTokenJWTValid(string paramkeytoken, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(paramkeytoken); //_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                //context.Items["User"] = userService.GetById(userId);

                return "";
            }
            catch (Exception ex)
            {
                throw ex;
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
