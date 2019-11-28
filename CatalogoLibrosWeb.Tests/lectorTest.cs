using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{
    [TestClass]
    public class lectorTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            Lector lect = new Lector();
            bool paso = false;

            lect.LectorID = 1;
            lect.Nombre = "Jose";
            lect.Matricula = 20391211;
            lect.Cedula = "4789658745896";
            lect.Direccion = "wewdnjwnjenwjenwje";
            lect.Telefono = "1212123421";
            lect.Email = "aeerere@gmial.com";
            lect.Pasword = " 1234452312sds";
            lect.Fecha = DateTime.Now;
                

            paso = repositorio.Guardar(lect);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            int id = 1;
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            Lector lect = new Lector();
            lect = repositorio.Buscar(id);

            bool paso = false;
            lect.Nombre = "Fernando";
            paso = repositorio.Modificar(lect);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            Lector lect = new Lector();
            lect = repositorio.Buscar(id);

            Assert.IsNotNull(lect);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }
   
    }

