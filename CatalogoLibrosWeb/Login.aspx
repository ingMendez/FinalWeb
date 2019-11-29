<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoLibrosWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="/content/bootstrap.min.css" rel="stylesheet" />
    <link href="/content/toastr.css" rel="stylesheet" />
    <script src="/Scripts/jquery-3.0.0.min.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
    <script src="/Scripts/bootstrap.bundle.min.js"></script>
    <script src="/Scripts/toastr.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand" href="#">TodosLibrosWeb.do</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">

                    <span><i class="fab fa-facebook-square"></i></span>
                </div>
            </nav>
        </div>
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4" style="font-style: normal; font-weight: bold">TodosLibrosWeb.do</h1>
                <p class="lead">Tu biblioteca en linea.</p>
                <form class="form-group my-2 my-sm-0">
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="EmailTextBox" class="form-control col-md-3" runat="server"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="PasswordTextBox" class="form-control col-md-3" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" class="btn btn-success btn-sm" Text="Entrar" OnClick="Button1_Click" />
                    <asp:Button ID="ButtonLlama" runat="server" class="btn-sm justify-content-center links btn btn-info" Text="¿No esta registrado?" OnClick="ButtonGuardar_Click"/>
                     <asp:Button ID="OlvidoButton" runat="server" class="btn-sm justify-content-center links btn btn-info" Text="¿Olvido su contraseña?" OnClick="OlvidoButton_Click"/>
                    <%--Controles de registrarse--%>
                    <asp:TextBox ID="NombreTextBox" runat="server" class="form-control col-md-3 input-sm" placeholder="Nombre" Style="font-size: medium" Font-Overline="False"></asp:TextBox>
                    <asp:TextBox ID="TelefonoTextBox" runat="server" class="form-control col-md-3 input-sm" placeholder="Telefono" Style="font-size: medium" Font-Overline="False"></asp:TextBox>
                    <asp:TextBox ID="EmaillTextBox" runat="server" class="form-control col-md-3 input-sm" type="email" placeholder="Email" Style="font-size: medium" TextMode="Email"></asp:TextBox>
                    <asp:TextBox ID="ContraseniaTextBox" runat="server" class="form-control col-md-3 input-sm" placeholder="Password" Style="font-size: medium" TextMode="Password"></asp:TextBox>
                    <asp:TextBox ID="ConfirmacionTextBox" runat="server" class="form-control col-md-3 input-sm" placeholder="Confirmar" Style="font-size: medium" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:Button ID="ButtonRegist" runat="server" class="btn-sm justify-content-center links btn btn-success" Text="Registrarse" OnClick="GuardarButton_Click" />
                    <asp:Button ID="OculRegButton" runat="server" class="btn-sm justify-content-center links btn btn-secondary" Text="Ocultar" OnClick="OculRegButton_Click"/>
                    <%--Hasta Aquí--%>
                     <br />
                     <br />
                    <%--Controles de conrfimación--%>
                    <asp:TextBox ID="CorreoTextBox" runat="server" class="form-control col-md-3 input-sm" placeholder="Correo" Style="font-size: medium" Font-Overline="False"></asp:TextBox>
                    <asp:Button ID="ConfirmarButton" runat="server" class="btn-sm justify-content-center links btn btn-success" Text="Enviar" OnClick="ConfirmarButton_Click"/>
                    <asp:Button ID="OculCOnfButton" runat="server" class="btn-sm justify-content-center links btn btn-secondary" Text="Ocultar" OnClick="OculCOnfButton_Click"/>
                    <br />
                    <%--Hasta Aquí--%>
                </form>
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
        <!-- Modal.// -->
        <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm" style="max-width: 400px!important; min-width: 300px!important">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Registrate</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <%--Body--%>

                        <br />
                        <%--Botones--%>
                        <div class="panel">
                            <div class="text-center">
                                <div class="form-group">

                                    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" class="btn btn-outline-success" OnClick="GuardarButton_Click" />
                                    <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" class="btn btn-outline-danger" />

                                </div>
                            </div>
                        </div>
                        <%--hasta aqui--%>
                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
