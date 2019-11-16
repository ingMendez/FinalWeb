using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Lector> Lectores { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Prestamo> Prestamo { get; set; }
        public DbSet<TipoEditorial> Editorial { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Categoria> _categoria { get; set; }
        // public DbSet<PrestamoDetalle> Detalle { get; set; }


        public Contexto() : base("ConStr")
        {

        }
    }
}
