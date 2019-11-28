using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{
    [TestClass]
    public class CategoriaTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            Categoria cat = new Categoria();
            bool paso = false;

            cat.CategoriaID = 1;
            cat.Nombre = "Jose";
            cat.descripcion = "sdsdsdsdsdsdsdsrfvrf";

            paso = repositorio.Guardar(cat);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            int id = 1;
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            Categoria cat = new Categoria();
            cat = repositorio.Buscar(id);

            bool paso = false;
            cat.Nombre = "Fernando";
            paso = repositorio.Modificar(cat);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            Categoria cat = new Categoria();
            cat = repositorio.Buscar(id);

            Assert.IsNotNull(cat);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }
   
    }

