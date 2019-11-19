using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;
using System.Linq.Expressions;
using System.Web.UI;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rLibro : System.Web.UI.Page
    {
        RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
        Expression<Func<Libro, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                IdTextBox.Text = "0";
                LlenaCombo();
            }
        }
        private void LlenaCombo()
        {
            RepositorioBase<Categoria> repositoriu = new RepositorioBase<Categoria>();
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();

            CategoriaDropDownList.DataSource = repositoriu.GetList(t => true);
            CategoriaDropDownList.DataValueField = "CategoriaId";
            CategoriaDropDownList.DataTextField = "Nombre";
            CategoriaDropDownList.DataBind();

            EditorialDropDownList.DataSource = repositorio.GetList(t => true);
            EditorialDropDownList.DataValueField = "EditorialID";
            EditorialDropDownList.DataTextField = "Nombre";
            EditorialDropDownList.DataBind();

        }

        // metodos
        private void LimpiaObjetos()
        {
            IdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "0";
            ISBNTextBox.Text = string.Empty;
            CategoriaDropDownList.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            EditorialDropDownList.Text = string.Empty;

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

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:64760/UI/Registros/rCategoria.aspx','_newtab');", true);
        }

        protected void AgregarEditButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:64760/UI/Registros/rEditorial.aspx','_newtab');", true);
        }
    }
}