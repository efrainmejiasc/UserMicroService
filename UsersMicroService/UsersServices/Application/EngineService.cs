using SharedProject.DTOs;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersKeyServices.Models;

namespace UsersServices.Application
{
    public class EngineService
    {
        public static GenericResponse SetGenericResponse(bool ok, string mensaje, int id = 0)
        {
            var response = new GenericResponse()
            {
                Id = id,
                Ok = ok,
                Mensaje = mensaje
            };

            return response;
        }

        public static UsuarioInformacionDTO SetUsuarioInformacionDTO
            (UsuarioDTO usuarioDTO,
            BalanceInformacionUsuarioKey balanceInformacionUsuarioKey)
        {
            var usuarioInformacionDTO = new UsuarioInformacionDTO()
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                TipoDocumento = usuarioDTO.TipoDocumento,
                Documento = usuarioDTO.Documento,
                KeyUsuario = usuarioDTO.KeyUsuario,
                FechaRegistro = usuarioDTO.FechaRegistro,
                Balance = balanceInformacionUsuarioKey.Balance,
                BalanceDate = balanceInformacionUsuarioKey.BalanceDate,
                VirtualBalance = balanceInformacionUsuarioKey.VirtualBalance,
                VirtualBalanceDate = balanceInformacionUsuarioKey.VirtualBalanceDate
            };

            return usuarioInformacionDTO;
        }
    }
}
