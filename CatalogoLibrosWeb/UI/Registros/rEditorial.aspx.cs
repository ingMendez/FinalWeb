using BLL;
using CatalogoLibrosWeb.Utilitarios;
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rEditorial : System.Web.UI.Page
    {
        public Editorial editorial = new Editorial();
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextbox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            IdTextBox.Text = "0";
        }
        private Editorial LlenaClase()
        {
            Editorial editorial = new Editorial();

            editorial.EditorialID = Utils.ToInt(IdTextBox.Text);
            editorial.Nombre = NombreTextBox.Text;
            editorial.Dirrecion = DireccionTextBox.Text;
             bool resultado = DateTime.TryParse(FechaTextbox.Text,out DateTime fecha);
            editorial.Fecha = fecha;
            return editorial;
        }

        public void LlenaCampo(Editorial editorial)
        {
            IdTextBox.Text = editorial.EditorialID.ToString();
            FechaTextbox.Text = editorial.Fecha.ToString("yyyy-MM-dd");
            IdTextBox.Text = editorial.ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            RepositorioBase<Editorial> repositorio = new RepositorioBase<Editorial>();
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

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Editorial> rep = new RepositorioBase<Editorial>();
            bool estado = false;
            Editorial editorial = new Editorial();

            if (validar())
            {
                return;
            }
            else
            {
                editorial = LlenaClase();
                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    estado = rep.Guardar(editorial);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioBase<Editorial> repo = new RepositorioBase<Editorial>();
                    int id = Convert.ToInt32(IdTextBox.Text);
                    Editorial edit = new Editorial();
                    edit = repo.Buscar(id);
                    if(edit != null)
                    {
                        estado = repo.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                    {
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
                    }
                }
                if (estado)
                {
                    Limpiar();
                }
                else
                {
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
                }
            }
        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Editorial> rep = new RepositorioBase<Editorial>();
            int id = Utils.ToInt(IdTextBox.Text);
            var editorial = rep.Buscar(id);

            if(editorial != null)
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