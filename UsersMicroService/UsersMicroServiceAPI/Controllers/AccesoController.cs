using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedProject.DTOs;
using System.Net;
using UsersMicroServiceAPI.SecurityToken;
using UsersServices.Application;
using UsersServices.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersMicroServiceAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccesoController : ControllerBase
    {
        private readonly IUsuarioAccesoService _usuarioAccesoService;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        public AccesoController(IUsuarioAccesoService usuarioAccesoService, IOptions<JwtBearerTokenSettings> jwtTokenOptions)
        {
            this._usuarioAccesoService = usuarioAccesoService;
            this._jwtBearerTokenSettings = jwtTokenOptions.Value;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(AccessToken))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] CredencialesDTO credencialesDTO)
        {

            if (credencialesDTO == null)
            {
                return BadRequest(new { Message = "No se envió la información de las credenciales" });
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var usuarioDTO = await this._usuarioAccesoService.ValidarUsuarioAccesoAsync(credencialesDTO.Username, credencialesDTO.Password);

                if (usuarioDTO != null)
                {
                    TokenProvider tokenProvider = new TokenProvider(_jwtBearerTokenSettings);

                    AccessToken token = tokenProvider.GenerarToken(usuarioDTO);

                    return Ok(token);
                }
                else
                {
                    return BadRequest(EngineService.SetGenericResponse(false, "Acceso denegado"));
                }
            }

        }

    }
}
