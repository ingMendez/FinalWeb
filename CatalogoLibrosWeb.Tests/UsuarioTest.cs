using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoLibrosWeb.Tests
{

    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usu = new Usuario();
            bool paso = false;

            usu.UsuarioId = 1;
            usu.Nombres = "Jose";
            usu.NoTelefono = "8098897849";
            usu.Email = "arbert@gffail.com";
            usu.Contraseña = "pelota12345";
            usu.pocision = "Administrador";
            usu.FechaCreacion = DateTime.Now;
            paso = repositorio.Guardar(usu);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            int id = 1;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usu = new Usuario();
            usu = repositorio.Buscar(id);

            bool paso = false;
            usu.Nombres = "Fernando";
            paso = repositorio.Modificar(usu);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            int id = 1;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usu = new Usuario();
            usu = repositorio.Buscar(id);

            Assert.IsNotNull(usu);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            int id = 1;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }
    }
}
