using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersModels.DataModels
{
    [Table("UsuarioAcceso")]
    public class UsuarioAcceso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Username { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string Password { get; set; }
    }
}
