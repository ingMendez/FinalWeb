using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }
        public string NombreLibro { get; set; }
        public string ISBN { get; set; }
        public int CategoriaID { get; set; }
        public string Descripcion { get; set; }
        public int EditarialID { get; set; }
        public DateTime FechaImpresion { get; set; }
        public bool Disponibilidad { get; set; }
        public Libro()
        {
            LibroID = 0;
            NombreLibro = "";
            ISBN = "";
            Disponibilidad = true;
            CategoriaID = 0;
            Descripcion = " ";
            EditarialID = 0;
            FechaImpresion = DateTime.Now;

        }
    }
}
