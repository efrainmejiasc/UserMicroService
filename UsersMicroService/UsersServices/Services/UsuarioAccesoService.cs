using AutoMapper;

using SharedProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersModels.DataModels;
using UsersModels.IRepositories;
using UsersServices.IServices;

namespace UsersServices.Services
{
    public class UsuarioAccesoService : IUsuarioAccesoService
    {
        private readonly IUsuarioAccesoRepository usuarioAccesoRepository;
        private readonly IMapper mapper;

        public UsuarioAccesoService(IUsuarioAccesoRepository _usuarioAccesoRepository, IMapper _mapper)
        {
            this.usuarioAccesoRepository = _usuarioAccesoRepository;
            this.mapper = _mapper;
        }

        public async Task<UsuarioAccesoDTO> ValidarUsuarioAccesoAsync(string username, string password)
        {
            var usuario = await this.usuarioAccesoRepository.GetUsuarioAsync(username, password);
            var userData = mapper.Map<UsuarioAcceso, UsuarioAccesoDTO>(usuario);

            return userData;
        }
    }
}
