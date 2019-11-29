<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCategoria.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Registros.rCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card text-white bg-dark mb-3">
        <div class="card-header text-uppercase text-center">Registro Categoria</div>
        <article class="card-body">
            <div class="rounded  " style="background-color: #C0C0C0; text-align: center;">
            </div>
            </br>
    </br>
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">


            <%--Id--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label style="font-size: medium;" for="IdTextBox" class="col-md-1   input-sm">Id</label>
                <div class="col-md-2 col-sm-6 col-xs-3">
                    <asp:TextBox ID="IdTextBox" runat="server" placeholder="0" class="form-control input-sm" type="number"  Style="font-size: medium"></asp:TextBox>
                </div>
                <div class="col-md-1 col-sm-2 col-xs-4">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" ValidationGroup="ValidacionBE" class="btn btn-info btn-md" OnClick="BuscarButton_Click"/>
                </div>
                <label style="font-size: small;" for="FechaTextbox" class="col-md-1   input-sm">Fecha</label>
                <div class="col-md-2 col-sm-3 col-xs-0">
                    <asp:TextBox ID="FechaTextbox" runat="server" class="form-control input-sm" Style="font-size: medium" TextMode="Date"></asp:TextBox>
                </div>
            </div>
            <%--hasta aqui--%>

            <%--Nombre--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label style="font-size: small;" for="NombreTextBox" class="col-md-1 input-sm">Nombre </label>
                <div class="col-md-3 col-sm-6 col-xs-6">
                    <asp:TextBox ID="NombreTextBox" runat="server" class="form-control input-sm" placeholder="Nombre" Style="font-size: medium"></asp:TextBox>
                </div>
            </div>
            <%--hasta aqui--%>

            <%--Descripcion--%>
            <div class="form-group row control-label" style="align-items: center;">
                <label style="font-size: small;" for="DescripcionTextBox" class="col-md-1   input-sm">Descripcion</label>
                <div class="col-md-3 col-sm-6 col-xs-6">
                    <asp:TextBox ID="DescripcionTextBox" runat="server" class="form-control input-sm" placeholder="Descripcion" Style="font-size: medium" TextMode="MultiLine"></asp:TextBox>       
                    </div>
            </div>
            <%--hasta aqui--%>
          
      
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="ButtonNuevo" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="ButtonNuevo_Click"/>
                        <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="ButtonGuardar_Click"/>
                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="ButtonEliminar_Click"/>
                    </div>
                </div>
            </div>
            <%--hasta aqui--%>
    </div>
</asp:Content>
