using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class TipoEditorial
    {
        [Key]
        public int EditarialID { get; set; }
        public string Nombre { get; set; }
        public string Dirrecion { get; set; }
        public DateTime Fecha { get; set; }
        public TipoEditorial()
        {
            EditarialID = 0;
            Nombre = string.Empty;
            Dirrecion = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
