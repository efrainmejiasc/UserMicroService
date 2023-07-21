using DbUserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersModels.IRepositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AddUsuarioAsync(Usuario x);
        Task<Usuario> GetUsuarioAsync(string key);
        Task<bool> DeleteUsuarioAsync(int userId);
        Task<Usuario> UpdateUsuarioAsync(Usuario x);
    }
}
