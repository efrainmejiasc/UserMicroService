using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersModels.DataModels;

namespace UsersModels.IRepositories
{
    public interface IUsuarioAccesoRepository
    {
        Task<UsuarioAcceso> GetUsuarioAsync(string username, string password);
    }
}
