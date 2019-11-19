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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaEntregaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                IdTextBox.Text = "0";
                //LlenaCombo();
                //ViewState["FacturaDetalle"] = new FacturaDetalle();
                //ViewState["Detalle"] = new Factura().Detalle;
                //LlenaReport();
            }
        }
    }
}