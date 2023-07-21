
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersModels.DataModels;
using UsersModels.IRepositories;

namespace UsersModels.Repositories
{
    public class UsuarioAccesoRepository:IUsuarioAccesoRepository
    {
        private readonly DbUserContext _dbUserContext;
        public UsuarioAccesoRepository(DbUserContext dbUserContext)
        {
            this._dbUserContext = dbUserContext;
        }

        public async Task<UsuarioAcceso> GetUsuarioAsync(string username , string password)
        {
            return await this._dbUserContext.UsuarioAcceso.
                         FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

    }
}
