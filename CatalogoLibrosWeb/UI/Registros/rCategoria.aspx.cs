using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rCategoria : System.Web.UI.Page
    {
        public Categoria categoria = new Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            IdTextBox.Text = "0";
        }
        private Categoria LlenaClase()
        {
            Categoria categoria = new Categoria();

            categoria.CategoriaID = Utils.ToInt(IdTextBox.Text);
            categoria.Nombre = NombreTextBox.Text;
            categoria.descripcion = DescripcionTextBox.Text;
            bool resultado = DateTime.TryParse(FechaTextbox.Text, out DateTime fecha);
            categoria.FechaCreacion = fecha;
            return categoria;
        }
        public void LlenaCampo(Categoria categoria)
        {
            FechaTextbox.Text = categoria.FechaCreacion.ToString("yyyy-MM-dd");
            IdTextBox.Text = categoria.ToString();
            NombreTextBox.Text = categoria.Nombre;
            DescripcionTextBox.Text = categoria.descripcion;

        }
        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = " ";
            DescripcionTextBox.Text = " ";
        }
        private bool ExisteBasedeDatos()
        {
            Categoria categoria = new Categoria();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            categoria = repositorio.Buscar(id);
            return categoria != null;
        }
        private bool validar()
        {
            bool estado = false;
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe de estar en cero.", "Error", "Error");
                estado = true;

            }
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un nombre para guardar", "Error", "error");
                estado = true;
            }
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener una Descripcion para guardar", "Error", "error");
                estado = true;
            }
            return estado;
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            else
            {
                RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
                bool paso = false;
                Categoria categoria = LlenaClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(categoria);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    if (!ExisteBasedeDatos())
                    {
                        Utils.ShowToastr(this, "No existe", "Error", "Error");
                        return;
                    }
                    else
                    {
                        paso = repositorio.Modificar(categoria);
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");

                    }
                }
                if (paso)
                {
                    Limpiar();
                }
            }


        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {

            RepositorioBase<Categoria> rep = new RepositorioBase<Categoria>();
            int id = Utils.ToInt(IdTextBox.Text);
            var categoria = rep.Buscar(id);

            if (categoria != null)
            {
                if (rep.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categoria> repositorio = new RepositorioBase<Categoria>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Convert.ToInt32(IdTextBox.Text);


                Categoria categoria = repositorio.Buscar(id);
                if (categoria != null)
                {
                    LlenaCampo(categoria);
                    Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                }
                else
                {
                    Utils.ShowToastr(this, "No se encontró", "Error", "error");
                    Limpiar();
                }
            }

        }
    }
}