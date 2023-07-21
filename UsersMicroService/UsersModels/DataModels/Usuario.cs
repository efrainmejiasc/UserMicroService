using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbUserService.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string Apellido { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string TipoDocumento { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Documento { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(100)")]
        public string KeyUsuario { get; set; }

        [Column(Order = 7, TypeName = "timestamp with time zone")]
        public DateTimeOffset FechaRegistro { get; set; }

    }
}
