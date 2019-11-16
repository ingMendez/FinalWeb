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
                <a class="navbar-brand" href="/Default.aspx">BibliotecaWeb.do</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <form class="form-inline my-2 my-lg-0">
                    </form>
                </div>
            </nav>
            <div class="jumbotron jumbotron-fluid">
                <div class="container">
                    <h1 class="display-4" style="font-weight: bold">BibliotecaWeb</h1>
                    <p class="lead">Biblioteca para todos.</p>
                    <form class="col-md-4 col-md-offset-2">
                        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="emailTextBox" class="form-control mr-md-2" runat="server"></asp:TextBox>
                        <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
                        <asp:TextBox ID="passwordTextBox" type="password" class="form-control mr-md-2" runat="server"></asp:TextBox>
                        <asp:Button ID="LoginButton" class="btn btn-success my-2 my-sm-3" runat="server" Text="Login" />
                    </form>
                </div>
            </div>
        </div>
        <hr />
        <footer>
            <p>&copy; <%: DateTime.Now.Year %> - BibliotecaWeb.do</p>
        </footer>
    </form>
</body>
</html>
