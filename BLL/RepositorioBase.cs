using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;

        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="entity">Una instancia de la entidad a guardar</param>
        /// <returns>Retorna True si guardo o Falso si falló </returns>
        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                {
                    _contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Modificar una entidad en la base de datos 
        /// </summary>
        /// <param name="entity">Una instancia de la entidad a guardar</param>
        /// <returns>Retorna True si Modifico o Falso si falló </returns>
        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la entidad que se desea eliminar </param>
        /// <returns>Retorna True si Eliminó o Falso si falló </returns>
        public virtual bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            { throw; }
            return paso;
        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la entidad que se desea encontrar </param>
        /// <returns>Retorna la persona encontrada </returns>
        public virtual T Buscar(int id)
        {
            T entity;
            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        /// <summary>
        /// Permite extraer una lista de Personas de la base de datos
        /// </summary> 
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        ///// <returns>Retorna una lista de entidades</returns>
        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }/*
    internal Contexto _contexto;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Programacion para Buscar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Buscar(int id)
        {
            T entity;

            try
            {
                entity = _contexto.Set<T>().Find(id);


            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }
        /// <summary>
        /// Programamcion Para Eliminar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T Entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(Entity);

                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Programacion para Generar Una Lista 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;

        }

        /// <summary>
        ///     Programacion Para Guardar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                    paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Programacion para modificar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool Modificar(T entity)
        {
            RepositorioBase<T> repositorio = new RepositorioBase<T>(new Contexto());
            bool paso = false;
            _contexto = new Contexto();
            try
            {
                _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }

       /*public object GetList(Expression<Func<global::Entities.Libro, bool>> filtrar)
        {
            throw new NotImplementedException();
        }
    }*/
}
