using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Editorial
    {
        [Key]
        public int EditorialID { get; set; }
        public string Nombre { get; set; }
        public string Dirrecion { get; set; }
        public DateTime Fecha { get; set; }

        public Editorial()
        {
            EditorialID = 0;
            Nombre = string.Empty;
            Dirrecion = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
