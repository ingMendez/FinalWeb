using DAL;
using Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace BLL
{
    public class RepositorioLibro : RepositorioBase<Prestamo>
    {
        public RepositorioLibro() : base()
        {

        }

        public override Prestamo Buscar(int id)
        {
            Prestamo prestamo = new Prestamo();
            Contexto db = new Contexto();
            try
            {

                prestamo = db.Prestamo.AsNoTracking().Include(x => x.Detalle).Where(x => x.PrestamoID == id).FirstOrDefault();
               
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();
                
            }
            return prestamo;
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
                            entity.Detalle.Remove(item);
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    contexto.SaveChanges();
                }
                foreach (var item in entity.Detalle.ToList())
                {
                    if (item.IDDetalle == 0)
                    {
                        db.Entry(item).State = EntityState.Added;
                    }
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

