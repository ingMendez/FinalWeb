using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;

namespace CatalogoLibrosWeb.Utilitarios
{
 
    public static class Utils
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static int ToIntObjetos(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public static double ToDouble(string valor)
        {
            double retorno = 0;
            double.TryParse(valor, out retorno);

            return retorno;
        }

        public static double ToDoubleObjetos(object valor)
        {
            double retorno = 0;
            double.TryParse(valor.ToString(), out retorno);

            return Convert.ToDouble(retorno);
        }

        public static decimal ToDecimal(string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }

        public static DateTime ToDateTime(string valor)
        {
            DateTime retorno = DateTime.Now;
            DateTime.TryParse(valor, out retorno);

            return retorno;
        }

        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static void MostrarMensaje(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                 String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
        public static string Nombres(int IdLista)
        {
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            Libro lib = new Libro();
            int id = IdLista;
            lib = repositorio.Buscar(id);

            string desc = lib.NombreLibro;

            return desc;
        }

        //Lista para el Detalle.
        public static List<PrestamoDetalle> ListaDetalle(int IdLista)
        {
            RepositorioBase<PrestamoDetalle> repositorio = new RepositorioBase<PrestamoDetalle>();
            List<PrestamoDetalle> list = new List<PrestamoDetalle>();
            int id = IdLista;
            list = repositorio.GetList(c => c.PrestamoID == id);

            return list;
        }

        /// aqui se programa el buscar de los Editoriales
        public static List<Editorial> FiltrarEditrial(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Editorial, bool>> filtro = p => true;
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            List<Editorial> list = new List<Editorial>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.EditorialID == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
     
            }

            list = repositorio.GetList(filtro);

            return list;
        }

        /// aqui se programa el buscar de los lectores
        public static List<Lector> FiltrarLector(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Lector, bool>> filtro = p => true;
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            List<Lector> list = new List<Lector>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.LectorID == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

            }

            list = repositorio.GetList(filtro);

            return list;
        }

        /// aqui se programa el buscar de los Categoria
        public static List<Categoria> FiltrarCategoria(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Categoria, bool>> filtro = p => true;
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            List<Categoria> list = new List<Categoria>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.FechaCreacion >= desde && p.FechaCreacion <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.CategoriaID == id && p.FechaCreacion >= desde && p.FechaCreacion <= hasta;
                    break;

            }

            list = repositorio.GetList(filtro);

            return  list;
        }
        /// aqui se programa el buscar de los Libro
        public static List<Libro> FiltrarLibro(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Libro, bool>> filtro = p => true;
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            List<Libro> list = new List<Libro>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.FechaImpresion >= desde && p.FechaImpresion <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.LibroID == id && p.FechaImpresion >= desde && p.FechaImpresion <= hasta;
                    break;

            }

            list = repositorio.GetList(filtro);

            return list;
        }
        
        /// aqui se programa el buscar de los Usuario
        public static List<Usuario> FiltrarUsuario(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuario, bool>> filtro = p => true;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            List<Usuario> list = new List<Usuario>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.FechaCreacion >= desde && p.FechaCreacion <= hasta;
                    break;

                case 2://FacturaId
                    filtro = p => p.UsuarioId == id && p.FechaCreacion >= desde && p.FechaCreacion <= hasta;
                    break;

            }

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}