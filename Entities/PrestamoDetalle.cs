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
        public int LectorID { get; set; }
        public int LibroID { get; set; }
        public int Matricula { get; set; }

        [ForeignKey("PretamoID")]
        public virtual Prestamo _pretamo { get; set; }

        [ForeignKey("LibroID")]
        public virtual Libro Libro { get; set; }

        public PrestamoDetalle()
        {
            ID = 0;
            PrestamoID = 0;
            LectorID = 0;
            LibroID = 0;
            Matricula = 0;
        }

        public PrestamoDetalle(int id, int prestamoid, int matricula, int libroId, int lectorid)
        {
            ID = id;
            PrestamoID = prestamoid;
            Matricula = matricula;
            LibroID = libroId;
            LectorID = lectorid;
        }
    }
}
