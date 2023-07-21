using AutoMapper;

using SharedProject.DTOs;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersModels.DataModels;
using UsersModels.IRepositories;
using UsersServices.Application;
using UsersServices.IServices;

namespace UsersServices.Services
{
    public class UsuarioService:IUsuarioService
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            this.usuarioRepository = _usuarioRepository;
            this.mapper = _mapper;
        }

        public async Task<GenericResponse> AddUsuarioAsync(UsuarioDTO model)
        {
            var usuario = this.mapper.Map<Usuario>(model);

            usuario = await this.usuarioRepository.AddUsuarioAsync(usuario);

            if (usuario.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public async Task<UsuarioDTO> GetUsuarioAsync(string key)
        {
            var usuario = await this.usuarioRepository.GetUsuarioAsync(key);
            var userData = mapper.Map<Usuario,UsuarioDTO>(usuario);

            return userData;
        }

        public async Task<GenericResponse> DeleteUsuarioAsync(int userId)
        {
            var result = await this.usuarioRepository.DeleteUsuarioAsync(userId);
            if (result)
                return EngineService.SetGenericResponse(true, "Usuario eliminado exitosamente");

            else
                return EngineService.SetGenericResponse(false, "Fallo eliminar usuario");
        }

        public async Task<GenericResponse> UpdateUsuarioAsync(UsuarioDTO model)
        {
           var usuario = this.mapper.Map<Usuario>(model);

            usuario = await this.usuarioRepository.UpdateUsuarioAsync(usuario);

            if (usuario.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido actualizada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo actualizar la información");
        }

    }
}
