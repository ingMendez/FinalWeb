using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{
    [TestClass]
    public class PrestamoTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            Prestamo pres = new Prestamo();
            bool paso = false;

            pres.PrestamoID= 8;
            pres.Fecha = DateTime.Now;
            pres.LectorID = 1;
            pres.TotalLibros = 1;
            pres.Detalle.Add(new PrestamoDetalle(3,8,2,"Juan",DateTime.Now));    

            paso = repositorio.Guardar(pres);
            Assert.AreEqual(true, paso);
        }

        

        [TestMethod]
        public void Modificar()
        {
            int id = 8;
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            Prestamo pres = new Prestamo();
            pres = repositorio.Buscar(id);

            bool paso = false;
            pres.TotalLibros = 4;
            paso = repositorio.Modificar(pres);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 8;
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            Prestamo cliente = new Prestamo();
            cliente = repositorio.Buscar(id);

            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            int id = 8;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }

    }

