using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Serializable]
    public class PrestamoDetalle
    {
        [Key]
        public int ID { get; set; }
        public int PrestamoID { get; set; }
        public int LibroID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }

        [ForeignKey("PretamoID")]
        public virtual Prestamo _pretamo { get; set; }

        [ForeignKey("LibroID")]
        public virtual Libro Libro { get; set; }

        public PrestamoDetalle()
        {
            ID = 0;
            PrestamoID = 0;
            LibroID = 0;
            Descripcion = string.Empty;
            FechaEntrega = DateTime.Now;
        }

        public PrestamoDetalle(int id, int prestamoid, int libroId, string descripcion, DateTime fechaEntrega)
        {
            ID = id;
            PrestamoID = prestamoid;
            LibroID = libroId;
            Descripcion = descripcion;
            FechaEntrega = fechaEntrega;
        }
    }
}
