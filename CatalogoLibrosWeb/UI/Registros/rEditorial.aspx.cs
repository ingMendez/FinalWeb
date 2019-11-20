using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rEditorial : System.Web.UI.Page
    {
        public Editorial editorial = new Editorial();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                IdTextBox.Text = "0";
            }

        }
        private bool ExisteBasedeDatos()
        {
            Editorial editorial = new Editorial();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            editorial = repositorio.Buscar(id);
            return editorial != null;
        }
        private Editorial LlenaClase()
        {
            Editorial editorial = new Editorial();

            editorial.EditorialID = Utils.ToInt(IdTextBox.Text);
            editorial.Nombre = NombreTextBox.Text;
            editorial.Dirrecion = DireccionTextBox.Text;
            bool resultado = DateTime.TryParse(FechaTextbox.Text, out DateTime fecha);
            editorial.Fecha = fecha;
            return editorial;
        }

        public void LlenaCampo(Editorial editorial)
        {
            IdTextBox.Text = editorial.EditorialID.ToString();
            FechaTextbox.Text = editorial.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = editorial.Nombre;
            DireccionTextBox.Text = editorial.Dirrecion;
            //FechaTextbox.Text = editorial.Fecha.ToString("yyyy-MM-dd");
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = " ";
            DireccionTextBox.Text = " ";
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
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener una direccion para guardar", "Error", "error");
                estado = true;
            }

            return estado;
        }


        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Convert.ToInt32(IdTextBox.Text);


                Editorial editorial = repositorio.Buscar(id);
                if (editorial != null)
                {
                    LlenaCampo(editorial);
                    Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                }
                else
                {
                    Utils.ShowToastr(this, "No se encontró", "Error", "error");
                    Limpiar();
                }
            }
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                return;
            }
            else
            {
                RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
                bool paso = false;
                Editorial edit = LlenaClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(edit);
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
                        paso = repositorio.Modificar(edit);
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
            RepositorioBase<Editorial> rep = new RepositorioBase<Editorial>();
            int id = Utils.ToInt(IdTextBox.Text);
            var editorial = rep.Buscar(id);

            if (editorial != null)
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

    }
}