﻿using CatalogoLibrosWeb.Utilitarios;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoLibrosWeb.UI.Consultas
{
    public partial class cLector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                LlenaReport();
            }
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        public void LlenaReport()
        {
            MyReportViewer.ProcessingMode = ProcessingMode.Local;
            MyReportViewer.Reset();
            MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ListadoLector.rdlc");
            MyReportViewer.LocalReport.DataSources.Clear();
            MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("LibroDS", Utils.FLibro()));
            MyReportViewer.LocalReport.Refresh();
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            int id = Utils.ToInt(CriterioTextBox.Text);
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            DateTime desde = Utils.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Utils.ToDateTime(HastaTextBox.Text);
            ConsultaGridView.DataSource = Utils.FiltrarLector(index, CriterioTextBox.Text, desde, hasta);
            ConsultaGridView.DataBind();

            criterioLabel.Text = FiltroDropDownList.Text.ToString();
        }
    }
}