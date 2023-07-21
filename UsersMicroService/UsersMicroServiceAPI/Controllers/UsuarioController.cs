using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedProject.DTOs;
using SharedProject.Models;
using System.Net;
using UsersServices.Application;
using UsersServices.IServices;
using Microsoft.AspNetCore.Authorization;
using UsersKeyServices.IServices;

namespace UsersMicroServiceAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRequestUserKey _requetUserKey;
        public UsuarioController(IUsuarioService usuarioService, IRequestUserKey requetUserKey)
        {
            this._usuarioService = usuarioService;
            this._requetUserKey = requetUserKey;
        }

        /// <summary>
        /// Crea un nuevo Usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> PostUsuarioAsync([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var balanceInformation = this._requetUserKey.GetBalanceAndInformationCard(usuarioDTO.KeyUsuario, usuarioDTO.TokenRequest);
                usuarioDTO.Id = 0;
                var genericResponse = await this._usuarioService.AddUsuarioAsync(usuarioDTO);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }

        }

        /// <summary>
        ///Obtiene datos del usuario por llave
        ///</summary>
        ///<returns>Datos del usuario</returns>
        [HttpGet("{key}", Name = "GetUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> GetUsuarioAsync(string key)
        {
            if(string.IsNullOrEmpty(key))
                return BadRequest(EngineService.SetGenericResponse(false, "La llave no puede ser vacia"));

            try
            {
                var usuarioDTO = await this._usuarioService.GetUsuarioAsync(key);

                if (usuarioDTO != null)
                    return Ok(usuarioDTO);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Actualizar informacion de usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut(Name = "UpdateUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> UpdateUsuarioAsync([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var genericResponse = await this._usuarioService.UpdateUsuarioAsync(usuarioDTO);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Eliminar registro de usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpDelete("{id}", Name = "DeleteUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> DeleteUsuarioAsync(int id)
        {
            try
            {
                var genericResponse = await this._usuarioService.DeleteUsuarioAsync(id);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

    }
}
