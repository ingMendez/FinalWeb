<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCategoria.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Registros.rCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    </br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-4">
            <div class="card text-white bg-dark mb-3">
                <div class="card-header text-uppercase text-center">Categoria</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-5 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar"/>
                                    <asp:TextBox class="form-control" ID="CategoriaIdTextBox" type="number" Text="0" runat="server" Width="86px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <div class="col-md-4 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server" Width="170px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                                    <asp:TextBox class="form-control" ID="nombreTextBox" runat="server" Width="263px" Height="33px"></asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
                                    <asp:TextBox class="form-control" ID="DescripcionTextBox" runat="server" Width="319px" Height="42px" TextMode="MultiLine"></asp:TextBox>
                                 
                         
                                </div>
                            </div>
                        </div>
                      <%--  <div class="col-md-6 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Deuda"></asp:Label>
                                    <asp:TextBox class="form-control" ID="DeudaTextBox" runat="server" ReadOnly="True" BackColor="#3399FF"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button class="btn btn-primary" ID="nuevoButton" runat="server" Text="Nuevo"/>
                                    <asp:Button class="btn btn-success" ID="guardarButton" runat="server" Text="Guardar"/>
                                    <asp:Button class="btn btn-danger" ID="eliminarutton" runat="server" Text="Eliminar"/>
                                </div>
                            </div>
                        </div>
                </form>
                </article>
            </div>
    </div>
    
</asp:Content>
