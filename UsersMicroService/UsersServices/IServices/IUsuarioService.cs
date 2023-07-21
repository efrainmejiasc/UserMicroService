using SharedProject.DTOs;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServices.IServices
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuarioAsync(string key);
        Task<GenericResponse> AddUsuarioAsync(UsuarioDTO x);
        Task<GenericResponse> DeleteUsuarioAsync(int userId);
        Task<GenericResponse> UpdateUsuarioAsync(UsuarioDTO x);
    }
}
