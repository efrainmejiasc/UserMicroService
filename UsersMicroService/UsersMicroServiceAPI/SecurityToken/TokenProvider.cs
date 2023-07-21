using Microsoft.IdentityModel.Tokens;
using SharedProject.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsersMicroServiceAPI.SecurityToken
{
    public class TokenProvider
    {
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="jwtTokenOptions">Opciones de configuracion</param>
        public TokenProvider(JwtBearerTokenSettings jwtTokenOptions)
        {
            this._jwtBearerTokenSettings = jwtTokenOptions;
        }

        /// <summary>
        /// General el token de autenticacion
        /// </summary>
        /// <param name="usuarioDTO"></param>
        /// <param name="externo"></param>
        /// <returns></returns>
        public AccessToken GenerarToken(UsuarioAccesoDTO usuarioDTO, bool externo = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerTokenSettings.SecretKey);
            var tokenString = string.Empty;
            var exp = 0;

            try
            {
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuarioDTO.Id.ToString() ?? string.Empty),
                new Claim(ClaimTypes.Name, usuarioDTO.Username ?? string.Empty),
                new Claim(ClaimTypes.Role, "1"?? "2"),
                new Claim(ClaimTypes.Email, usuarioDTO.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
               });


                exp = (externo) ? _jwtBearerTokenSettings.ExpiryTimeInMinutes : _jwtBearerTokenSettings.ExpiryTimeInDays;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    NotBefore = DateTime.UtcNow,
                    Audience = _jwtBearerTokenSettings.Audience,
                    Issuer = _jwtBearerTokenSettings.Issuer,
                    Expires = (externo) ? DateTime.UtcNow.AddMinutes(_jwtBearerTokenSettings.ExpiryTimeInMinutes) : DateTime.UtcNow.AddDays(_jwtBearerTokenSettings.ExpiryTimeInDays),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenString = tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
            }


            return new AccessToken(tokenString, exp, externo);

        }
    }
}
