<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EXPEDIA.index" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<!DOCTYPE html>


<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/half-slider.css" rel="stylesheet"/>
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

                <% if (Session["Usuario"]=="Desconocido") {
                       Session["Usuario"] = "Inicio";%>
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

                <% if (Session["Usuario"]=="Desactivado") {
                       Session["Usuario"] = "Inicio";%>
                    <div class="modal fade" id="exampleModa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document" style="width: 350px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" style="text-align:center" id="exampleModalLabe">Los datos ingresados son incorrectos</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container" style="width: 300px;">
                                El usuario esta desactivado en el sistema.
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

                <% if (Session["Usuario"] == "Anonimo")
                   {
                       Session["Usuario"] = "Inicio";
                       %>
                    <div class="modal fade" id="exampleModa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document" style="width: 350px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" style="text-align:center" id="exampleModalLabe">Debes autentificarte</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container" style="width: 300px;">
                                Necesitas un usuario para ingresar al sistema.
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

               <% if (Session["Usuario"] == "")
                  {
                      Session["Usuario"] = "Inicio";%>
                    <div class="modal fade" id="exampleMo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document" style="width: 350px;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" style="text-align:center" id="exampleMod">Debes autentificarte</h4>
                        </div>
                        <div class="modal-body">
                            <div class="container" style="width: 300px;">
                                Lo sentimos, se acabo el tiempo en el sistema para realizar acciones.
                            </div> <!-- /container -->
                            <script type="text/javascript">
                                $(window).load(function () {
                                    $('[data-toggle="tooltip"]').tooltip();
                                    $('#exampleMo').modal('show');
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


            <% if (Session["Usuario"] != "Inicio") { Session["Inhabilitado"] = ""; Session["Usuario"] = "Inicio"; }%>

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
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <h2 class="form-signin-heading" style="text-align:center">Ingresa tus credenciales</h2>
                                                <div class="pure-control-group">
                                                    <label for="cedula">Número de cédula</label>
                                                    <asp:TextBox ValidationGroup="one" runat="server" ID="username" CssClass="form-control" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vCedula" runat="server" ControlToValidate="username" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <cc1:MaskedEditExtender ID="username_MaskedEditExtender" runat="server" BehaviorID="username_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="username"></cc1:MaskedEditExtender>
                                                    <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator2" runat="server" ControlToValidate="username" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                    <br />
                                                    <label for="contraseña">Contraseña</label>
                                                     <asp:TextBox    runat="server" TextMode="Password"  ID="password" size="20" CssClass="form-control" placeholder="Contraseña" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar su contraseña." required="" />
                                                </div>
                                         <br />
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
