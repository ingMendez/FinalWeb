using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Prestamo
    {
        [Key]
        public int PrestamoID { get; set; }
        public DateTime Fecha { get; set; }
        public int LectorID { get; set; }
        public int TotalLibros { get; set; }
        public virtual List<PrestamoDetalle> Detalle { get; set; }

        public Prestamo()
        {
            PrestamoID = 0;
            LectorID = 0;
            Fecha = DateTime.Now;
            TotalLibros = 0;
            this.Detalle = new List<PrestamoDetalle>();
        }

        public void AgregarDetalle(int id, int prestamoid, int libroId, string descripcion, DateTime fechaEntrega)
        {
            this.Detalle.Add(new PrestamoDetalle(id, prestamoid, libroId, descripcion, fechaEntrega));
        }
        
        public override string ToString()
        {
            return PrestamoID.ToString();
        }
    }

}
