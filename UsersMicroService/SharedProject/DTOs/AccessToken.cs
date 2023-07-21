using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.DTOs
{
    public sealed class AccessToken
    {
        public string Token { get; }
        public DateTime Expires { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token">Cadena del token</param>
        /// <param name="expiresIn">Tiempo de expiracion</param>
        public AccessToken(string token, int expiresIn, bool UsExterno = false)
        {
            Token = token;
            Expires = UsExterno ? System.DateTime.Now.AddMinutes(expiresIn) : System.DateTime.Now.AddDays(expiresIn);
        }
    }
}
