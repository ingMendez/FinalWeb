<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rRegistrar.aspx.cs" Inherits="CatalogoLibrosWeb.UI.Registros.rRegistrar" %>

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
            <div class="container login-container">
                <div class="row">
                    <div class="col-md-6 login-form-1">
                        <h3>Login for Form 1</h3>
                        <form>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Your Email *" value="" />
                            </div>
                            <div class="form-group">
                                <input type="password" class="form-control" placeholder="Your Password *" value="" />
                            </div>
                            <div class="form-group">
                                <input type="submit" class="btnSubmit" value="Login" />
                            </div>
                            <div class="form-group">
                                <a href="#" class="ForgetPwd">Forget Password?</a>
                            </div>
                        </form>
                    </div>
                    <div class="col-md-6 login-form-2">
                        <h3>Login for Form 2</h3>
                        <form>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Your Email *" value="" />
                            </div>
                            <div class="form-group">
                                <input type="password" class="form-control" placeholder="Your Password *" value="" />
                            </div>
                            <div class="form-group">
                                <input type="submit" class="btnSubmit" value="Login" />
                            </div>
                            <div class="form-group">

                                <a href="#" class="ForgetPwd" value="Login">Forget Password?</a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
