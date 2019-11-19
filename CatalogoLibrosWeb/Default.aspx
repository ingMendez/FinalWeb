<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoLibrosWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <h1 class="display-4" style="font-style: normal; font-weight: bold">TodosLibrosWeb.do</h1>
            <p class="lead">Tu biblioteca en linea.</p>
        </div>
    </div>

    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="Imagenes/5ab10d4485600a3d195f6753.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Imagenes/_103401128_gettyimages-1028739954.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Imagenes/En-el-mundo-existen-150.000.000-de-libros…-y-estos-son-los-100-mejores.jpg" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Imagenes/shutterstock_522019972.jpg" class="d-block w-100" alt="...">
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
</asp:Content>
