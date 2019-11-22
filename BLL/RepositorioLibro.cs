using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioLibro : RepositorioBase<Prestamo>
    {
        public RepositorioLibro() : base()
        {

        }

        public override bool Modificar(Prestamo entity)
        {
            bool paso = false;
            Prestamo Anterior = Buscar(entity.PrestamoID);
            Contexto db = new Contexto();
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    foreach (var item in Anterior.Detalle.ToList())
                    {
                        if (!entity.Detalle.Exists(x => x.IDDetalle == item.IDDetalle))
                        {

                            contexto.Entry(item).State = EntityState.Deleted;
                            entity.Detalle.Remove(item);
                            // repositorioBase.Dispose();
                        }
                    }
                    contexto.SaveChanges();
                }
                db.Entry(entity).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }

            return paso;
        }
    }
}
    
