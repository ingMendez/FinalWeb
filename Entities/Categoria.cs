

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Categoria()
        {
            CategoriaID = 0;
            Nombre = string.Empty;
            descripcion = string.Empty;
            FechaCreacion = DateTime.Now;
        }
    }
}
