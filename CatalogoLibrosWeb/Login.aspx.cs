using BLL;
using CatalogoLibrosWeb.Utilitarios;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Web.Security;

namespace CatalogoLibrosWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OcultarRegis();
                OcultarConf();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario usuario = new Usuario();

            filtrar = t => t.Email.Equals(EmailTextBox.Text) && t.Contraseña.Equals(PasswordTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(usuario.Email, true);
            else
                Utils.ShowToastr(this, "Email o Contraseña incorrectos", "Error", "error");
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Guardar();
            //Indicas las opciones del servidor smtp mediante el que enviarás el correo (smtp + puerto)
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            string emailPara = EmaillTextBox.Text;
            MailMessage message = new MailMessage("email.From@servidor.com", emailPara, "Confirmacion", "Confirmacion");

            //De forma alternativa, y por si quieres enviar html, puedes especificar el mensaje asi
            message.Body = "Usted ha sido registrado exitosamente en TodosLibrosWeb.do";

            //Si tu servidor smtp necesita credenciales , las pones asi

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("pruebasprogramacion57@gmail.com", "123456789Pp");

            //Finalmente envias el mensaje
            client.Send(message);

            Utils.ShowToastr(this, "Se ha enviado un correro a la dirección proporcionada", "Confirmacion", "success");
            OcultarRegis();
        }

        private void Guardar()
        {
            bool paso = false;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usu = new Usuario();
            usu.UsuarioId = 0;
            usu.Nombres = NombreTextBox.Text;
            usu.Email = EmaillTextBox.Text;
            usu.NoTelefono = TelefonoTextBox.Text;
            usu.Contraseña = ContraseniaTextBox.Text;
            usu.FechaCreacion = DateTime.Now;
            usu.pocision = "Usuario";

            paso = repositorio.Guardar(usu);

            if (paso == true)
            {
                Utils.ShowToastr(this, " Registrado", "Confirmacion", "success");
            }

        }

        private void OcultarRegis()
        {
            NombreTextBox.Visible = false;
            TelefonoTextBox.Visible = false;
            EmaillTextBox.Visible = false;
            ContraseniaTextBox.Visible = false;
            ConfirmacionTextBox.Visible = false;
            ButtonRegist.Visible = false;
            OculRegButton.Visible = false;
        }

        private void MostrarRegis()
        {
            NombreTextBox.Visible = true;
            TelefonoTextBox.Visible = true;
            EmaillTextBox.Visible = true;
            ContraseniaTextBox.Visible = true;
            ConfirmacionTextBox.Visible = true;
            ButtonRegist.Visible = true;
            OculRegButton.Visible = true;
        }

        private void OcultarConf()
        {
            CorreoTextBox.Visible = false;
            ConfirmarButton.Visible = false;
            OculCOnfButton.Visible = false;
        }

        private void MostrarConf()
        {
            CorreoTextBox.Visible = true;
            ConfirmarButton.Visible = true;
            OculCOnfButton.Visible = true;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            MostrarRegis();
        }

        protected void ConfirmarButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario usuario = new Usuario();
            List<Usuario> lista = new List<Usuario>();
            filtrar = t => t.Email.Equals(CorreoTextBox.Text);
            lista = repositorio.GetList(filtrar);
            if (lista.Count() != 0)
            {
                foreach (var item in lista)
                {
                    id = item.UsuarioId;
                }
            }
            usuario = repositorio.Buscar(id);
            string contraseña = "";
            if (usuario != null)
            {
                contraseña = usuario.Contraseña;
            }
            else
            {
                Utils.ShowToastr(this, "Correo invalido", "Error", "error");
                return;
            }

            //Indicas las opciones del servidor smtp mediante el que enviarás el correo (smtp + puerto)
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            string emailPara = CorreoTextBox.Text;
            MailMessage message = new MailMessage("email.From@servidor.com", emailPara, "Confirmacion", "Confirmacion");

            //De forma alternativa, y por si quieres enviar html, puedes especificar el mensaje asi
            message.Body = "Su contraseña es: " + contraseña.ToString();

            //Si tu servidor smtp necesita credenciales , las pones asi

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("pruebasprogramacion57@gmail.com", "123456789Pp");

            //Finalmente envias el mensaje
            client.Send(message);

            Utils.ShowToastr(this, "Se ha enviado un correro a la dirección proporcionada", "Confirmacion", "success");
            OcultarConf();
        }

        protected void OlvidoButton_Click(object sender, EventArgs e)
        {
            MostrarConf();
        }

        protected void OculCOnfButton_Click(object sender, EventArgs e)
        {
            OcultarConf();
        }

        protected void OculRegButton_Click(object sender, EventArgs e)
        {
            OcultarRegis();
        }
    }
}