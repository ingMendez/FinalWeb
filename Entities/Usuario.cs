using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nombres { get; set; }

        public string NoTelefono { get; set; }

        public string Email { get; set; }

        public string Contraseña { get; set; }

        public bool pocision { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Usuario()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            NoTelefono = string.Empty;
            Email = string.Empty;
            Contraseña = string.Empty;
            pocision = true;
            FechaCreacion = DateTime.Now;
        }
    }
}
