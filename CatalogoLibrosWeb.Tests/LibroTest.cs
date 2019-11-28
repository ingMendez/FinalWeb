using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{
    [TestClass]
    public class LibroTest
    {

        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            Libro lib = new Libro();
            bool paso = false;

            lib.LibroID = 1;
            lib.NombreLibro = "Jose";
            lib.ISBN = "isbn20391211sd";
            lib.CategoriaID = 1;
            lib.Descripcion = "stridnfdjfdn";
            lib.EditorialID = 2;
            lib.FechaImpresion = DateTime.Now;
           
       
        paso = repositorio.Guardar(lib);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            int id = 1;
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            Libro lect = new Libro();
            lect = repositorio.Buscar(id);

            bool paso = false;
            lect.NombreLibro = "Fernando";
            paso = repositorio.Modificar(lect);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            Libro lect = new Libro();
            lect = repositorio.Buscar(id);

            Assert.IsNotNull(lect);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }

}

