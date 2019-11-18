using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Lector
    {

        [Key]
        public int LectorID { get; set; }
        public string Nombre { get; set; }
        public int Matricula { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Direccion { get; set; }

        public Lector()
        {
            LectorID = 0;
            Nombre = string.Empty;
            Matricula = 0;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Fecha = DateTime.Now;
        }

    }
}
