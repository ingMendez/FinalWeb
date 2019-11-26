using BLL;
using CatalogoLibrosWeb.Utilitarios;
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
    public partial class rLector : System.Web.UI.Page
    {
        RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
        Expression<Func<Lector, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                IdTextBox.Text = "0";
            }
        }
        private void LimpiaObjetos()
        {
            IdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = " ";
            MatriculaTextBox.Text = string.Empty;
            CedulaTextBox.Text= string.Empty;
            TelefonoTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;

        }

        private bool HayErrores()
        {
            bool HayErrores = false;
            string s = MatriculaTextBox.Text;
            filtrar = t => t.Matricula.ToString().Equals(s);
            List<Lector> lista = new List<Lector>();
            lista = repositorio.GetList(filtrar);

            string j = EmailTextBox.Text;
            filtrar = t => t.Email.Equals(j);
            List<Lector> lis = new List<Lector>();
            lis = repositorio.GetList(filtrar);

            string p = PasswordTextBox.Text;
            string cp = ConfirmarPassword.Text;
            int comparacion = 0;
            comparacion = String.Compare(p, cp);
            if (comparacion != 0)
            {
                Utils.ShowToastr(this, "Las Contraseñas no son iguales", "Error", "error");
                PasswwordCustomValidator.Focus();
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            if(string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "debe de llenar el campo", "Error", "error");
                HayErrores = true;
            }
            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
            {
                Utils.ShowToastr(this, "debe de llenar el campo", "Error", "error");
                HayErrores = true;
            }
            if (CedulaTextBox.Text.Length < 11 || CedulaTextBox.Text.Length > 13)
            {
                Utils.ShowToastr(this, "No es una Cedula corrrecto", "Error", "error");
                HayErrores = true;
            }
            if (lista.Count != 0)
            {
                Utils.ShowToastr(this, "Esta Matricula ya existe", "Error", "error");
                HayErrores = true;
            }
            if ( MatriculaTextBox.Text.Length != 8)
            {
                Utils.ShowToastr(this, "No es una Matricula corrrecto", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(MatriculaTextBox.Text))
            {
                Utils.ShowToastr(this, "Matricula no puede estar vacío", "Error", "error");
                HayErrores = true;
            }         
            
            if (String.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                Utils.ShowToastr(this, "Descripcion no puede estar vacío", "Error", "error");
                HayErrores = true;
            }
            if (lis.Count != 0)
            {
                Utils.ShowToastr(this, "Esta Email ya existe", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        public void LlenaCampos(Lector lector)
        {
            IdTextBox.Text = lector.LectorID.ToString();
            FechaTextBox.Text = lector.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = lector.Nombre;
            MatriculaTextBox.Text = lector.Matricula.ToString();
            CedulaTextBox.Text = lector.Cedula;
            TelefonoTextBox.Text = lector.Telefono;
            DireccionTextBox.Text= lector.Direccion;
        }


        private Lector LlenaClase()
        {
          
            Lector lector = new Lector();
            lector.LectorID = Utils.ToInt(IdTextBox.Text);
            lector.Nombre = NombreTextBox.Text;
            lector.Matricula = Utils.ToInt(MatriculaTextBox.Text);
            lector.Cedula = CedulaTextBox.Text;
            lector.Telefono = TelefonoTextBox.Text;
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            lector.Fecha = fecha;
            lector.Direccion = DireccionTextBox.Text;
             
            return lector;
            
        }

        // aqui va la verificacion de base de datos.
        private bool ExisteBasedeDatos()
        {
            Lector lector = new Lector();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            lector = repositorio.Buscar(id);
            return lector != null;
        }
        ///
        //// aqui va el buscar
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Convert.ToInt32(IdTextBox.Text);


                Lector lector = repositorio.Buscar(id);
                if (lector != null)
                {
                    LlenaCampos(lector);
                    Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
                }
                else
                {
                    Utils.ShowToastr(this, "No se encontró", "Error", "error");
                    LimpiaObjetos();
                }
            }
        }
        /// <summary>
        /// Programacio del nuevo
        /// </summary>
        /// <param name="Nuevo"></param>
        /// <param name="e"></param>
        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Guardar"></param>
        /// <param name="e"></param>

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (HayErrores())
            {
                return;
            }
            else
            {
                RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
                bool paso = false;
                Lector lector = new Lector();
                lector = LlenaClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(lector);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    LimpiaObjetos();
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
                        paso = repositorio.Modificar(lector);
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");

                    }
                }
                if (paso)
                {
                    LimpiaObjetos();
                }
            }
        }

        /// <summary>
        /// aqui esta el eliminar Registro
        /// </summary>
        /// <param name="Elimiar"></param>
        /// <param name="e"></param>
        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Lector> repositorio = new RepositorioBase<Lector>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Utils.ToInt(IdTextBox.Text);
                var lector = repositorio.Buscar(id);

                if (lector != null)
                {
                    if (repositorio.Eliminar(id))
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

        ///
        //

    }
}