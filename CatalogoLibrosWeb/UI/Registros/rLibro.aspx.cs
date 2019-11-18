using BLL;
using CatalogoLibrosWeb.Utilitarios;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rLibro : System.Web.UI.Page
    {
        RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>(new Contexto());
        Expression<Func<Libro, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        private void LlenaCombo()
        {
            RepositorioBase<Categoria> repositoriu = new RepositorioBase<Categoria>(new Contexto());
            RepositorioBase<TipoEditorial> repositorio = new RepositorioBase<TipoEditorial>(new Contexto());
           // Repositorio<Cliente> repositorio = new Repositorio<Cliente>();
       ///    Repositorio<Producto> repository = new Repositorio<Producto>();

            CategoriaDropDownList.DataSource = repositoriu.GetList(t => true);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Nombres";
            CategoriaDropDownList.DataBind();

            EditorialDropDownList.DataSource = repositorio.GetList(t => true);
            EditorialDropDownList.DataValueField = "EditorialId";
            EditorialDropDownList.DataTextField = "Nombres";
            EditorialDropDownList.DataBind();

          /*  productoDropDownList.DataSource = repository.GetList(t => true);
            productoDropDownList.DataValueField = "ProductoId";
            productoDropDownList.DataTextField = "Descripcion";
            productoDropDownList.DataBind();*/
        }
       // metodos
        private void LimpiaObjetos()
        { 
            IdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "0";
            ISBNTextBox.Text =string.Empty;
            CategoriaDropDownList.Text =string.Empty;
            DescripcionTextBox.Text =string.Empty;
            EditorialDropDownList.Text =string.Empty;
      
         }
        private Libro LlenaClase()
        {
            Libro libro = new Libro();

            libro.LibroID = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            libro.FechaImpresion = fecha;
            libro.NombreLibro = NombreTextBox.Text;
            libro.ISBN = ISBNTextBox.Text;
            libro.CategoriaID = CategoriaDropDownList.SelectedIndex;
            libro.Descripcion = DescripcionTextBox.Text;
            libro.EditorialID = EditorialDropDownList.SelectedIndex;

            return libro;
        }

        public void LlenaCampos(Libro libro)
        {
            LimpiaObjetos();
            IdTextBox.Text = libro.LibroID.ToString();
            FechaTextBox.Text = libro.FechaImpresion.ToString("yyyy-MM-dd");
            NombreTextBox.Text = libro.NombreLibro;
            ISBNTextBox.Text = libro.ISBN;
            CategoriaDropDownList.SelectedValue = libro.CategoriaID.ToString();
            DescripcionTextBox.Text = libro.Descripcion;
            EditorialDropDownList.SelectedValue = libro.EditorialID.ToString();
        }

        //validaciones de libro
      /*  private bool HayErrores()
        {
            bool HayErrores = false;
            // filtrar = t => t.NoCedula.Equals(noCedulaTextBox.Text);
            filtrar = t => t.ISBN.Equals(ISBNTextBox.Text);

          /*  if (repositorio.GetList(filtrar).Count() != 0)
            {
                Utils.ShowToastr(this, "Esta ISBN ya existe", "Error", "error");
                HayErrores = true;
            }*/
            /*if (repositorio.GetList(filtro).Count() != 0)
            {
                Utils.ShowToastr(this, "Este Nombre ya existe", "Error", "error");
                HayErrores = true;
            }*/
           /* if (noTelefonoTextBox.Text.Length != 10)
            {
                Utils.ShowToastr(this, "No es un Número de Teléfono correcto", "Error", "error");
                HayErrores = true;
            }
            if (noCedulaTextBox.Text.Length != 11)
            {
                Utils.ShowToastr(this, "No es un Número de Cédula correcto", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(clienteIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }*/
    }
}