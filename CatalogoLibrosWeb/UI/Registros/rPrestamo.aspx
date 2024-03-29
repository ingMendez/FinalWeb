﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamo.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Registros.rPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card text-white bg-dark mb-3">
        <div class="card-header text-uppercase text-center">Registro Prestamo</div>
        <article class="card-body">
            <div class="rounded  " style="background-color: #C0C0C0; text-align: center;">
            </div>
            <br>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">


                    <%--Id--%>
                    <div class="form-group row control-label" style="align-items: center;">
                        <label style="font-size: medium;" for="IdTextBox" class="col-md-1   input-sm">Id</label>
                        <div class="col-md-2 col-sm-6 col-xs-3">
                            <asp:TextBox ID="IdTextBox" runat="server" placeholder="0" class="form-control input-sm" type="number" Style="font-size: medium"></asp:TextBox>
                        </div>
                        <div class="col-md-1 col-sm-2 col-xs-4">
                            <asp:Button ID="BuscarButton" runat="server" Text="Buscar" ValidationGroup="ValidacionBE" class="btn btn-info btn-md" OnClick="BuscarButton_Click" />
                        </div>
                        <label style="font-size: medium;" for="FechaTextbox" class="col-md-1   input-sm">Fecha</label>
                        <div class="col-md-2 col-sm-3 col-xs-0">
                            <asp:TextBox ID="FechaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Date" ReadOnly="True"></asp:TextBox>
                        </div>
                        <label style="font-size: medium;" for="FechaEntregaTextBox" class="col-md-1   input-sm">Fecha de Entrega</label>
                        <div class="col-md-2 col-sm-3 col-xs-3">
                            <asp:TextBox ID="FechaEntregaTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Date" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <%--hasta aqui--%>

                    <%--Lector--%>
                    <div class="form-group row control-label" style="align-items: center;">
                        <label for="LectorDropDownList" class="col-md-1 input-sm" style="font-size: medium">Lector</label>
                        <div class="col-md-3 col-sm-6 col-xs-6">
                            <asp:DropDownList ID="LectorDropDownList" Style="font-size: medium" class="form-control input-sm " runat="server" OnSelectedIndexChanged="LectorDropDownList_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <%--hasta aqui--%>

                   <%--Matricula--%>
                    <div class="form-group  row control-label" style="align-items: center;">
                        <label for="LibroDropDownList" class="col-md-1 input-sm" style="font-size: medium">Libro</label>
                        <div class="col-md-3 col-sm-6 col-xs-6">
                            <asp:DropDownList ID="LibroDropDownList" class="form-control input-sm " Style="font-size: medium" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-1 col-sm-2 col-xs-4">
                            <asp:Button ID="AgregarButton" runat="server" Text="+" ValidationGroup="ValidacionGM" class="btn btn-warning btn-md" Font-Size="Medium" OnClick="AgregarButton_Click" />
                        </div>
                    </div>
                    <%--hasta aqui--%>
                </div>
            </div>
            <%--GridView--%>

            <hr>
            <div class="form-group  control-label" style="align-items: center;">
                <div class="table-responsive ">
                    <asp:GridView ID="DetalleGridView" runat="server" class="table table-condensed" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False"
                        OnRowCommand="DetalleGridView_RowCommand" OnPageIndexChanging="DetalleGridView_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="removerLinkButton" runat="server" class="btn btn-danger" CausesValidation="False" CommandArgument="<%#((GridViewRow) Container).DataItemIndex %>" CommandName="Select" Text="Remover"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="LibroID" HeaderText="LibroID" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha de Entrega" />
                        </Columns>
                        <HeaderStyle BackColor="Black" Font-Bold="true" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:GridView>
                </div>
            </div>
            <hr>
            <%--hasta aqui--%>

            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--TotalLibros--%>
                    <div class="form-group row control-label" style="align-items: center;">
                        <label style="font-size: medium;" for="TotalLibrosTextBox" class="col-md-1   input-sm">Total Libros</label>
                        <div class="col-md-3 col-sm-6 col-xs-6">
                            <asp:TextBox ID="TotalLibrosTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: medium" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                    </div>
                    <%--hasta aqui--%>
                </div>
            </div>
            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="ButtonNuevo" runat="server" Text="Nuevo" class="btn btn-primary" OnClick="ButtonNuevo_Click" />
                        <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="ButtonGuardar_Click" />
                        <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="ButtonEliminar_Click" />
                    </div>
                </div>
            </div>
            <%--hasta aqui--%>
    </div>
</asp:Content>
