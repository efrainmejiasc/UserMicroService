using SharedProject.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServices.IServices
{
    public interface IUsuarioAccesoService
    {
        Task<UsuarioAccesoDTO> ValidarUsuarioAccesoAsync(string username, string password);
    }
}
