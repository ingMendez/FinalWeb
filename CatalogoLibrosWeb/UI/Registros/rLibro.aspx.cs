using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;
using System.Collections.Generic;
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
            NombreTextBox.Text = "";
            ISBNTextBox.Text = string.Empty;
            CategoriaDropDownList.SelectedIndex = 0;
            DescripcionTextBox.Text = string.Empty;
            EditorialDropDownList.SelectedIndex = 0;

        }
        private Libro LlenaClase()
        {
            Libro libro = new Libro();

            libro.LibroID = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            libro.FechaImpresion = fecha;
            libro.NombreLibro = NombreTextBox.Text;
            libro.ISBN = ISBNTextBox.Text;
            libro.CategoriaID = Convert.ToInt32(CategoriaDropDownList.SelectedValue);
            libro.Descripcion = DescripcionTextBox.Text;
            libro.EditorialID = Convert.ToInt32(EditorialDropDownList.SelectedValue);

            return libro;
        }

        public void LlenaCampos(Libro libro)
        {
            IdTextBox.Text = libro.LibroID.ToString();
            FechaTextBox.Text = libro.FechaImpresion.ToString("yyyy-MM-dd");
            NombreTextBox.Text = libro.NombreLibro;
            ISBNTextBox.Text = libro.ISBN;
            CategoriaDropDownList.SelectedValue = libro.CategoriaID.ToString();
            DescripcionTextBox.Text = libro.Descripcion;
            EditorialDropDownList.SelectedValue = libro.EditorialID.ToString();
        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            filtrar = t => t.ISBN.Equals(ISBNTextBox.Text);
            List<Libro> lista = new List<Libro>();
            lista = repositorio.GetList(filtrar);

            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(CategoriaDropDownList.SelectedIndex) < 0)
            {
                Utils.ShowToastr(this, "Debe tener al menos una Categoria guardado", "Error", "error");
                HayErrores = true;
            }
            if (Utils.ToIntObjetos(EditorialDropDownList.SelectedIndex) < 0)
            {
                Utils.ShowToastr(this, "Debe tener al menos un Editorial guardado", "Error", "error");
                HayErrores = true;
            }
            if (lista.Count != 0)
            {
                Utils.ShowToastr(this, "Este ISBN ya existe", "Error", "error");
                HayErrores = true;
            }
            if (ISBNTextBox.Text.Length < 10 || ISBNTextBox.Text.Length > 13)
            {
                Utils.ShowToastr(this, "No es un ISBN corrrecto", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(ISBNTextBox.Text))
            {
                Utils.ShowToastr(this, "ISBN no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "Nombre no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                Utils.ShowToastr(this, "Descripcion no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:64760/UI/Registros/rCategoria.aspx','_newtab');", true);
        }

        protected void AgregarEditButton_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('http://localhost:64760/UI/Registros/rEditorial.aspx','_newtab');", true);
        }

        private bool ExisteBasedeDatos()
        {
            Libro libro = new Libro();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            libro = repositorio.Buscar(id);
            return libro != null;
        }




        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Convert.ToInt32(IdTextBox.Text);


                Libro libros = repositorio.Buscar(id);
                if (libros != null)
                {
                    LlenaCampos(libros);
                    Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                }
                else
                {
                    Utils.ShowToastr(this, "No se encontró", "Error", "error");
                    LimpiaObjetos();
                }
            }
        }




        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {


            if (HayErrores())
            {
                return;
            }
            else
            {
                RepositorioBase<Libro> repositorio = new RepositorioBase<Libro>();
                bool paso = false;
                Libro libros = new Libro();
                libros = LlenaClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(libros);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
                }
                else
                {
                    if (!ExisteBasedeDatos())
                    {
                        Utils.ShowToastr(this,"No existe", "Error","Error");
                        return;
                    }
                    else
                    {
                        paso = repositorio.Modificar(libros);
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");

                    }
                }
                if (paso)
                {
                    LimpiaObjetos();
                }
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Libro> rep = new RepositorioBase<Libro>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Utils.ToInt(IdTextBox.Text);
                var editorial = rep.Buscar(id);

                if (editorial != null)
                {
                    if (rep.Eliminar(id))
                    {
                        Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                        LimpiaObjetos();
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
                    }

                }
                else
                {
                    Utils.ShowToastr(this, "No existe", "Error", "error");
                }
            }
        }
    }
}
