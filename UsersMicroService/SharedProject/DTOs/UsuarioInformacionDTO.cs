using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.DTOs
{
    public class UsuarioInformacionDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public string KeyUsuario { get; set; }

        public DateTimeOffset FechaRegistro { get; set; }
        public decimal Balance { get; set; }
        public string BalanceDate { get; set; }
        public decimal VirtualBalance { get; set; }
        public string VirtualBalanceDate { get; set; }
    }
}
