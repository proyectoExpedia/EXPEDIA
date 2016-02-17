<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EXPEDIA.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/half-slider.css" rel="stylesheet"/>
    <link href="css/boostrap-snipp.css" rel="stylesheet" />
    <%--<link rel="icon" href="img/ExpediaLogo.png"/>--%>
    <link href="css/indexCSS.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <script src="js/jquery.bxslider.js"></script>
</head>
<body>
  <!--Menu-->
    <nav class="navbar" role="navigation" style="margin-top:20px;">
        <div class="container">
            <ul class="bxslider">
                <li><img src="img/colegioAbogadoscr.png" style="width:100px; height:100px;float:left" alt="" /></li>
                <li><img src="img/ExpediaLogo.png" alt="" style="width:100px; height:100px;float:left" /></li>
            </ul>
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" style="float:right" href="#"><h3>Colegio de Abogados y Abogadas de Costa Rica</h3></a>
            </div>
            <!-- Opciones menu -->
            <div class="col-md-6" style="margin-top:15px;">
                <div class="panel-heading">
                    <ul class="nav nav-tabs">
                        <li class="active"><a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">Ingresar</a></li>
                        <li><a href="#tab2primary" data-toggle="tab">Conózcanos</a></li>
                        <li><a href="#tab3primary" data-toggle="tab">Contacto</a></li>
                        <!--<li class="dropdown">
                            <a href="#" data-toggle="dropdown">Dropdown <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#tab4primary" data-toggle="tab">Primary 4</a></li>
                                <li><a href="#tab5primary" data-toggle="tab">Primary 5</a></li>
                            </ul>
                        </li>-->
                    </ul>
                </div>
            </div>
        </div>
    </nav>

    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>
        <!-- Wrapper for Slides -->
        <div class="carousel-inner" style="position:absolute">
            <div class="item active">
                <!-- Set the first background image using inline CSS below. -->
                <div class="fill" style="background-image: url(img/Slider01.jpg); background-repeat: no-repeat;">
                </div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
            <div class="item">
                <!--<img src="img/Slider02.jpg" />-->
                <!-- Set the second background image using inline CSS below. -->
                <div class="fill" style="background-image: url(img/Slider02.jpg); background-repeat: no-repeat; margin-top: 20px;"></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
            <div class="item">
                <!-- Set the third background image using inline CSS below. -->
                <div class="fill" style="background-image: url(img/Slider03.png); background-repeat: no-repeat "></div>
                <div class="carousel-caption">
                    <h2></h2>
                </div>
            </div>
        </div>
        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>
    <!-- Page Content -->
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1>Bienvenido a Expedia</h1>
                <p>Texto referente a la bienvenida . . .</p>
            </div>

                 <% if (Server.UrlDecode(Request.QueryString["rid"]) != null) {
                                    %>
                                            <div class="modal fade" id="exampleModa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog" role="document" style="width: 350px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" style="text-align:center" id="exampleModalLabe">Los datos ingresados son incorrectos</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container" style="width: 300px;">
                                Cedula o contraseña incorrectos
                            </div> <!-- /container -->
                            <script type="text/javascript">
                                $(window).load(function () {
                                    $('[data-toggle="tooltip"]').tooltip();
                                    $('#exampleModa').modal('show');
                                });
                            </script>
                        </div>
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
                <% } %>


     
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                <div class="modal-dialog" role="document" style="width: 350px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Bienvenido a Expedia</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container" style="width: 300px;">
                                <%--<form action="mainAdministrador.aspx" onsubmit="">--%>
                                    <form   runat="server">
                                    <h2 class="form-signin-heading">Ingresa tus credenciales</h2>
                                    <asp:TextBox    runat="server" ID="username" size="20" CssClass="form-control" placeholder="Número de cédula (#########)" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar su número de cedula, omita guiones y todos los dígitos del documento de identidad"  required="" />
                                    <asp:TextBox    runat="server" TextMode="Password"  ID="password" size="20" CssClass="form-control" placeholder="Contraseña" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar su contraseña." required="" />

                                    <asp:Button  runat="server"  ID="Bt_Ingresar" CssClass="btn btn-lg btn-primary btn-block" OnClick="Bt_Ingresar_Click"   text="Ingresar"/>

                                </form>
                            </div> <!-- /container -->
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('[data-toggle="tooltip"]').tooltip();
                                });
                            </script>
                        </div>
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container -->
    <footer class="navbar navbar-inverse" style="background-color:darkred">
        <div class="container">
            <h6 style="text-align: center" class="text-muted">Prototipo I EXPEDIA - Ingeniería en sistemas de información II</h6>
        </div>
    </footer>
    <script>
        // You can also use "$(window).load(function() {"
        $(document).ready(function () {
            $('.bxslider').bxSlider({
                mode: 'fade',
                auto: true,
                controls: false
            });
        });
    </script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Script to Activate the Carousel -->
    <script>
        $(document).ready(function (){
            $('.carousel').carousel({
                interval: 5000 //changes the speed
            });
        });
    </script>
</body>
</html>
