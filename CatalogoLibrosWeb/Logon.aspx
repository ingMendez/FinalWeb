<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CatalogoLibrosWeb.Logon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!--===============================================================================================-->
    <a href="Contenidos/images/icons/favicon.ico">Contenidos/images/icons/favicon.ico</a>
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/fonts/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/fonts/Linearicons-Free-v1.0.0/icon-font.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/animate/animate.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/animsition/css/animsition.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/select2/select2.min.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/vendor/daterangepicker/daterangepicker.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <link href="Contenidos/css/util.css" rel="stylesheet" />
    <link href="Contenidos/css/main.css" rel="stylesheet" />
    <!--===============================================================================================-->
    <title></title>
</head>
<body style="background-color: #666666;">
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <form class="login100-form validate-form">
                        <span class="login100-form-title p-b-43">Inicie Sesion
                        </span>


                        <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                            <input class="input100" type="text" name="email">
                            <span class="focus-input100"></span>
                            <span class="label-input100">Email</span>
                        </div>


                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <input class="input100" type="password" name="pass">
                            <span class="focus-input100"></span>
                            <span class="label-input100">Password</span>
                        </div>

                        <div class="flex-sb-m w-full p-t-3 p-b-32">
                            <div class="contact100-form-checkbox">
                                <input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
                                <label class="label-checkbox100" for="ckb1">
                                    Remember me
                                </label>
                            </div>

                            <div>
                                <a href="#" class="txt1">Forgot Password?
                                </a>
                            </div>
                        </div>


                        <div class="container-login100-form-btn">
                            <button class="login100-form-btn">
                                Login
                            </button>
                        </div>

                        <div class="text-center p-t-46 p-b-20">
                            <span class="txt2">or sign up using
                            </span>
                        </div>

                        <div class="login100-form-social flex-c-m">
                            <a href="#" class="login100-form-social-item flex-c-m bg1 m-r-5">
                                <i class="fa fa-facebook-f" aria-hidden="true"></i>
                            </a>

                            <a href="#" class="login100-form-social-item flex-c-m bg2 m-r-5">
                                <i class="fa fa-twitter" aria-hidden="true"></i>
                            </a>
                        </div>
                    </form>

                    <div class="login100-more" style="background-image: url('/Contenidos/images/bg-01.jpg');">
                    </div>
                </div>
            </div>
        </div>

        <!--===============================================================================================-->
        <script src="Contenidos/vendor/jquery/jquery-3.2.1.min.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/vendor/animsition/js/animsition.min.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/vendor/bootstrap/js/popper.js"></script>
        <script src="Contenidos/vendor/bootstrap/js/bootstrap.min.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/vendor/select2/select2.min.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/vendor/daterangepicker/moment.min.js"></script>
        <script src="Contenidos/vendor/daterangepicker/daterangepicker.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/vendor/countdowntime/countdowntime.js"></script>
        <!--===============================================================================================-->
        <script src="Contenidos/js/main.js"></script>

    </form>
</body>
</html>
