<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamo.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Registros.rPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-white bg-dark mb-3">
        <div class="card-header text-uppercase text-center">Registro Libro</div>
        <article class="card-body">
            <div class="rounded  " style="background-color: #C0C0C0; text-align: center;">
            </div>
            </br>
    </br>
    <div class="panel-body">
        <div class="form-horizontal col-md-10" role="form">


            <%--Id--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label style="font-size: medium;" for="IdTextBox" class="col-md-3   input-sm">Id</label>
                <div class="col-md-3 col-sm-6 col-xs-3">
                    <asp:TextBox ID="IdTextBox" runat="server" placeholder="0" class="form-control input-sm" type="number" Style="font-size: medium"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" ValidationGroup="ValidacionBE" class="btn btn-info btn-md" />
                </div>
                <label style="font-size: medium;" for="FechaTextbox" class="col-md-2   input-sm">Fecha</label>
                <div class="col-md-2 col-sm-6 col-xs-3">
                    <asp:TextBox ID="FechaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <%--hasta aqui--%>

            <%--Lector--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label for="LectorDropDownList" class="col-md-3 input-sm" style="font-size: medium">Lector</label>
                <div class="col-md-3 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="LectorDropDownList" Style="font-size: medium" class="form-control input-sm " runat="server"></asp:DropDownList>
                </div>
            </div>
            <%--hasta aqui--%>

            <%--Libro--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label for="LibroDropDownList" class="col-md-3 input-sm" style="font-size: medium">Libro</label>
                <div class="col-md-3 col-sm-6 col-xs-6">
                    <asp:DropDownList ID="LibroDropDownList" class="form-control input-sm " Style="font-size: medium" runat="server"></asp:DropDownList>
                </div>
            </div>
            <%--hasta aqui--%>

            <%--Matricula--%>
            <div class="form-group  row control-label" style="align-items: center;">
                <label style="font-size: medium;" for="MatriculaTextBox" class="col-md-3   input-sm">Matricula</label>
                <div class="col-md-3 col-sm-6 col-xs-6">
                    <asp:TextBox ID="MatriculaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="AgregarButton" runat="server" Text="+" ValidationGroup="ValidacionGM" class="btn btn-success btn-md" Font-Size="Medium" />
                </div>
            </div>
            <%--hasta aqui--%>
        </div>
    </div>
            <%--GridView--%>
            <div class="form-group  control-label" style="align-items: center;">
                <div class="table-responsive ">
                    <asp:GridView ID="DetalleGridView" runat="server" class="table table-condensed" CellPadding="6" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" />
                            <asp:BoundField DataField="PrestamoID" HeaderText="PrestamoID" />
                            <asp:BoundField DataField="LectorID" HeaderText="LectorID" />
                            <asp:BoundField DataField="LibroID" HeaderText="LibroID" />
                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                            <asp:ButtonField ButtonType="Link" CommandName="Delete" HeaderText="Opcion" ShowHeader="True" Text="Remover" />
                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="true" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:GridView>
                </div>
            </div>
            <%--hasta aqui--%>
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="ButtonNuevo" runat="server" Text="Nuevo" class="btn btn-info" />
                        <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" class="btn btn-success" />
                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" class="btn btn-danger" />
                    </div>
                </div>
            </div>
            <%--hasta aqui--%>
    </div>
</asp:Content>
