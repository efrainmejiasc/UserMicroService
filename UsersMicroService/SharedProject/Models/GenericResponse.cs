using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Models
{
    public class GenericResponse
    {
        public int Id { get; set; }
        public bool Ok { get; set; }
        public string Mensaje { get; set; }
    }
}
