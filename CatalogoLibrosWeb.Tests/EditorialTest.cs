using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{
    [TestClass]
    public class EditorialTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            Editorial di = new Editorial();
            bool paso = false;

            di.EditorialID = 1;
            di.Nombre = "Jose";
            di.Dirrecion = "gkfslkdlskdlsdkl";

            paso = repositorio.Guardar(di);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            int id = 1;
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            Editorial edi = new Editorial();
            edi = repositorio.Buscar(id);

            bool paso = false;
            edi.Nombre = "Fernando";
            paso = repositorio.Modificar(edi);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            Editorial edi = new Editorial();
            edi = repositorio.Buscar(id);

            Assert.IsNotNull(edi);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }
}
