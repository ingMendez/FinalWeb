using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoLibrosWeb.UI.Registros
{
    public partial class rPrestamo : System.Web.UI.Page
    {
        public Prestamo prestamo = new Prestamo();
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();
            if (!Page.IsPostBack)
            {
                AjustarFecha();
                IdTextBox.Text = "0";
                LlenaCombo();
                //ViewState["FacturaDetalle"] = new FacturaDetalle();
                ViewState["detalle"] = new Prestamo().Detalle;
                //LlenaReport();
            }

        }

        private void AjustarFecha()
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime date = new DateTime();
            date = DateTime.Now;
            date = date.AddDays(7);
            FechaEntregaTextBox.Text = date.ToString("yyyy-MM-dd");
        }


        private void LlenaCombo()
        {
            RepositorioBase<Libro> repositoriu = new RepositorioBase<Libro>();
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();

            LibroDropDownList.DataSource = repositoriu.GetList(t => true);
            LibroDropDownList.DataValueField = "LibroID";
            LibroDropDownList.DataTextField = "NombreLibro";
            LibroDropDownList.DataBind();

            LectorDropDownList.DataSource = repositorio.GetList(t => true);
            LectorDropDownList.DataValueField = "LectorID";
            LectorDropDownList.DataTextField = "Nombre";
            LectorDropDownList.DataBind();

        }

        public Prestamo LlenaClase()
        {
            Prestamo prestamo = new Prestamo();

            prestamo.PrestamoID = Utils.ToInt(IdTextBox.Text);
            bool resultado = DateTime.TryParse(FechaEntregaTextBox.Text, out DateTime fecha);
            prestamo.Fecha = fecha;
            prestamo.LectorID = Utils.ToIntObjetos(LectorDropDownList.SelectedValue);
            prestamo.TotalLibros = Utils.ToInt(TotalLibrosTextBox.Text);
            prestamo.Detalle = (List<PrestamoDetalle>)ViewState["detalle"];
 
            return prestamo;
        }

        private void LlenaCampo(Prestamo prestamo)
        {
            int id = Utils.ToInt(IdTextBox.Text);
            List<PrestamoDetalle> detalle = Utils.ListaDetalle(id);
            ViewState["detalle"] = detalle;
            FechaEntregaTextBox.Text = prestamo.Fecha.ToString("yyy-MM-dd");
            LectorDropDownList.SelectedValue = prestamo.LectorID.ToString();
            DetalleGridView.DataSource = prestamo.Detalle;
            DetalleGridView.DataBind();
            TotalLibrosTextBox.Text = prestamo.TotalLibros.ToString();
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaEntregaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LectorDropDownList.SelectedIndex = 0;
            LibroDropDownList.SelectedIndex = 0;
            //MatriculaTextBox.Text = string.Empty;
            TotalLibrosTextBox.Text = "0";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
        }

        private bool Validar()
        {
            bool estato = false;

            if (DetalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                estato = true;
            }
            if (Utils.ToIntObjetos(LectorDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Lector guardado.", "Error", "error");
                estato = true;
            }
            if (Utils.ToIntObjetos(LibroDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "Todavía no hay un Libro guardado.", "Error", "error");
                estato = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                estato = true;
            }
            return estato;
        }

        private void LlenaValores()
        {
            int total = 0;
            List<PrestamoDetalle> lista = (List<PrestamoDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                total += 1;
            }

            TotalLibrosTextBox.Text = total.ToString();
        }

        private void QuitaValores()
        {
            int total = 0;
            List<PrestamoDetalle> lista = (List<PrestamoDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                total -= 1;
            }

            TotalLibrosTextBox.Text = total.ToString();
        }


        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            List<PrestamoDetalle> detalles = new List<PrestamoDetalle>();
            if (IsValid)
            {
                DateTime date = DateTime.Now.AddDays(7);

                int LibroId = Utils.ToIntObjetos(LibroDropDownList.SelectedValue);
                string Nombre = Utils.Nombres(LibroId);

                int Lectorid = Utils.ToIntObjetos(LectorDropDownList.SelectedValue);
                string lectors = Utils.Nombres(Lectorid);

                if (DetalleGridView.Rows.Count != 0)
                {
                    prestamo.Detalle = (List<PrestamoDetalle>)ViewState["Detalle"];
                }

                PrestamoDetalle detalle = new PrestamoDetalle();
                prestamo.AgregarDetalle(0, prestamo.PrestamoID, LibroId, Nombre, date);

                ViewState["Detalle"] = prestamo.Detalle;
                DetalleGridView.DataSource = ViewState["Detalle"];
                DetalleGridView.DataBind();
                LlenaValores();
            }

        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            RepositorioLibro repolibro = new RepositorioLibro();
            bool paso = false;
            Prestamo prestamo = new Prestamo();

            if (Validar())
            {
                return;
            }
            else
            {
                prestamo = LlenaClase();
                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repolibro.Guardar(prestamo);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    RepositorioLibro repo = new RepositorioLibro();
                    int id = Convert.ToInt32(IdTextBox.Text);
                    Prestamo pres = new Prestamo();
                    pres = repo.Buscar(id);


                    if(pres != null)
                    {
                        paso = repo.Modificar(LlenaClase());
                    }
                }
            }

        }

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioLibro repositorio = new RepositorioLibro();
            int id = Utils.ToInt(IdTextBox.Text);

            var prestamo = repositorio.Buscar(id);

            if (prestamo != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Prestamo> repositorio = new RepositorioBase<Prestamo>();

            var prestamo = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            if (prestamo != null)
            {
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                LlenaCampo(prestamo);
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No existe el prestamo especificado", "Error", "error");
            }
        }

        protected void LectorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DetalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                ((List<PrestamoDetalle>)ViewState["Detalle"]).RemoveAt(index);
                DetalleGridView.DataSource = ViewState["Detalle"];
                DetalleGridView.DataBind();
                QuitaValores();
            }
        }

        protected void DetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }


}