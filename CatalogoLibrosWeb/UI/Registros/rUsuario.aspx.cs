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
    public partial class rUsuario : System.Web.UI.Page
    {
        RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
        Expression<Func<Usuario, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            TelefonoTextBox.Text = string.Empty;
            ContraseniaTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NivelDropDownList.Text = string.Empty;
        }

        public void LlenaCampos(Usuario usuario)
        {
            IdTextBox.Text = usuario.UsuarioId.ToString();
            FechaTextBox.Text = usuario.FechaCreacion.ToString("yyyy-MM-dd");
            NombreTextBox.Text = usuario.Nombres;
            EmailTextBox.Text = usuario.Email;
            TelefonoTextBox.Text = usuario.NoTelefono;
            ContraseniaTextBox.Text = usuario.Contraseña;
            NivelDropDownList.Text = usuario.pocision;
           // DireccionTextBox.Text = usuario.Direccion;
        }

        private Usuario LlenaClase()
        {

            Usuario usuario = new Usuario();
            usuario.UsuarioId = Utils.ToInt(IdTextBox.Text);
            usuario.Nombres = NombreTextBox.Text;
            usuario.Email = EmailTextBox.Text;
            usuario.NoTelefono = TelefonoTextBox.Text;
            usuario.Contraseña = ContraseniaTextBox.Text;
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            usuario.FechaCreacion = fecha;
            usuario.pocision = NivelDropDownList.Text;
          //  usuario.Direccion = DireccionTextBox.Text;

            return usuario;

        }

        // aqui va la verificacion de base de datos.
        private bool ExisteBasedeDatos()
        {
            Usuario usuario = new Usuario();
            int id = Convert.ToInt32(IdTextBox.Text);
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            usuario = repositorio.Buscar(id);
            return usuario != null;
        }
        private bool HayErrores()
        {
            bool HayErrores = false;
            string s = EmailTextBox.Text;
            filtrar = t => t.Email.Equals(s);
            List<Usuario> lista = new List<Usuario>();
            lista = repositorio.GetList(filtrar);

            string p = ContraseniaTextBox.Text;
            string cp = ConfirmacionTextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(p,cp);
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
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                Utils.ShowToastr(this, "debe de llenar el campo", "Error", "error");
                HayErrores = true;
            }
            if (string.IsNullOrWhiteSpace(TelefonoTextBox.Text))
            {
                Utils.ShowToastr(this, "debe de llenar el campo", "Error", "error");
                HayErrores = true;
            }
            if (ContraseniaTextBox.Text.Length < 10 || ContraseniaTextBox.Text.Length > 20)
            {
                Utils.ShowToastr(this, "No es una contraseña corrrecta", "Error", "error");
                HayErrores = true;
            }
            if (TelefonoTextBox.Text.Length !=10)
            {
                Utils.ShowToastr(this, "No es es correcto el numero", "Error", "error");
                HayErrores = true;
            }
            if (lista.Count != 0)
            {
                Utils.ShowToastr(this, "Esta Email ya existe", "Error", "error");
                HayErrores = true;
            }          
          
            return HayErrores;
        }
        /// <summary>
        /// Buscar
        /// </summary>
        /// <param name="Buscar"></param>
        /// <param name="e"></param>
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Convert.ToInt32(IdTextBox.Text);


                Usuario usuario = repositorio.Buscar(id);
                if (usuario != null)
                {
                    LlenaCampos(usuario);
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
        /// Nuevo
        /// </summary>
        /// <param name="nuevo"></param>
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
                RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                bool paso = false;
                Usuario usuario = new Usuario();
                usuario = LlenaClase();

                if (Convert.ToInt32(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(usuario);
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
                        paso = repositorio.Modificar(usuario);
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
        /// Programacion Eliminar
        /// </summary>
        /// <param name="Eliminar"></param>
        /// <param name="e"></param>

        protected void ButtonEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id no puede estar vacío", "Error", "error");

            }
            else
            {
                int id = Utils.ToInt(IdTextBox.Text);
                var usuario = repositorio.Buscar(id);

                if (usuario != null)
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
    }
}