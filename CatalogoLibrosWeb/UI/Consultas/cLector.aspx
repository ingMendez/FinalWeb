<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cLector.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Consultas.cLector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %><%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="card-header text-uppercase text-center">Consultar Lector</div>
    <div class="card-body">
        <div class="form-row justify-content-center">
            <%--Filtro--%>
            <div class="form-group col-md-2">
                <asp:Label Text="Filtro" runat="server" />
                <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem>Todo</asp:ListItem>
                    <asp:ListItem>Todo por Fecha</asp:ListItem>
                    <asp:ListItem>LectorID</asp:ListItem>
                    <asp:ListItem>Nombre</asp:ListItem>
                </asp:DropDownList>
            </div>
            <%--Criterio--%>
            <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server">Criterio</asp:Label>
                <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-1 p-0">
                <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-dark mt-4" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
                </asp:LinkButton>
            </div>
        </div>
        <%--Rango fecha--%>
        <div class="form-row justify-content-center">
            <div class="form-group col-md-2">
                <asp:Label Text="Desde" runat="server" />
                <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
            <div class="form-group col-md-2">
                <asp:Label Text="Hasta" runat="server" />
                <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
            </div>
        </div>
        <div class="card">
            <div class="card-body">
                <asp:Label ID="criterioLabel" runat="server" Text="" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                <div class="form-row justify-content-center">
                    <asp:GridView ID="ConsultaGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="LightSkyBlue" />
                        <Columns>
                            <asp:BoundField DataField="LectorID" HeaderText=" Lector ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        </Columns>
                        <HeaderStyle BackColor="LightGreen" Font-Bold="True" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <%--Botones--%>
        <div class="card-footer">
            <div class="justify-content-start">
                <div class="form-group" style="display: inline-block">
                    <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-info mt-4" runat="server" data-toggle="modal" data-target=".bd-example-modal-lg">
                            <span class="fas fa-print"></span>
                            Imprimir
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    </div>
      <!-- Modal para mi Reporte.// -->
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm" style="max-width: 800px!important; min-width: 500px!important">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">REPORTE</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <%--Viewer--%>
                    <rsweb:reportviewer id="MyReportViewer" runat="server" processingmode="Remote" height="400px" width="750px">
                            <ServerReport ReportPath="" ReportServerUrl="" />
                        </rsweb:reportviewer>
                </div>
                <div class="modal-footer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
