<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainAdministrador.aspx.cs" Inherits="EXPEDIA.mainAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="img/ExpediaLogo.png"/>
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <script src="js/jquery.bxslider.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/hover.js"></script>
    <link href="css/hover.css" rel="stylesheet" />
    <style type="text/css">
        a {
          color:#003566;
        }
    </style>
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
                    <ul class="nav ">

                        <style type="text/css">
                        .badge-notify{
                            background:red;
                            position:relative;
                            top: -20px;
                            left: -35px;
                        }
                        </style>
                        <li>
                            <div class="container" style="float:left; margin-left: 300px; margin-top:-55px;">
                                <a class="btn btn-default btn-lg btn-link" data-toggle="modal" data-target="#exampleModaA" style="font-size:36px;">
                                <span class="glyphicon glyphicon-barcode"></span>
                                </a>
                                <span class="badge badge-notify" runat="server" id="contador"></span>
                                <a class="btn btn-default btn-lg btn-link" data-toggle="modal" data-target="#exampleModaP" style="font-size:36px;">
                                <span class="glyphicon glyphicon-th-list"></span>
                                </a>
                                <span class="badge badge-notify" runat="server" id="contador2"></span>
                                <a class="btn btn-default btn-lg btn-link"  href="index.aspx" style="font-size:36px; margin-top:28px;">
                                <span class="glyphicon glyphicon-log-out"><br /><p style="font-size:12px; font-family:sans-serif;"> <br />Cerrar<br />sesión</p></span> 
                                </a>
                            </div>

                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </nav>
    <div class="container">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
        <br />
        <br />
        <div class="alert alert-success" role="alert">
            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
            <span class="sr-only"><strong></strong></span> Bienvenido: 
            <%=Session["Usuario"].ToString() %>, recuerda cerrar tu sesión al terminar tus acciones.
            <button type="button" class="close" data-dismiss="alert"><span>&times;</span></button>
        </div>
        <div class="row">
                <div class="container" style="margin-left:-8px;">
                    <div>
                    <h1 style="text-align: center"><b>Bienvenido Administrador</b></h1>
                    <h2 style="text-align: center"> Elige tu opcion</h2>
                    </div>
                    <div class="row" >
                        <div class="col-sm-3 col-md-4" >
                            <div class="thumbnail"  style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#instrucUsuarios">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div class="modal fade" id="instrucUsuarios" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document" style="width:1000px;">
                                        <div class="modal-content" role="document" >
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <center>
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title"> Creación de usuarios </h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Creacion%20de%20usuarios.mp4" controls="controls"></video>
                                                    </div>
                                                    </div>
                                                    <br />
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title">Modificación de usuarios</h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Modificacion%20de%20usuarios.mp4" controls="controls"></video>
                                                    </div>
                                                    </div>
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title">Habilitación - Inhabilitar usuarios</h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/inhabilitacion%20-%20habilitacion%20de%20usuarios.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />

                                                    </center>
                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="caption" style="text-align:center">
                                    <a href="gestionUsuarios.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-user"></span>
                                        <h3>Gestión de usuarios</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4">
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#instrucActivos" >
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div class="modal fade" id="instrucActivos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document" style="width:1000px;">
                                        <div class="modal-content" role="document" >
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <center>
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title"> Creación de activos </h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Creacion%20de%20activos.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title">Modificación de activos</h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/modificacion.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />

                                                    </center>
                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="caption" style="text-align:center">
                                        <a href="gestionActivos.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-barcode"></span>
                                        <h3>Gestión de activos</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4">
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#instrucPrestamos" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div class="modal fade" id="instrucPrestamos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document" style="width:1000px;">
                                        <div class="modal-content" role="document" >
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <center>
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title"> Creación de préstamos </h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Creacion%20de%20prestamos.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title">Control de préstamos</h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Control%20de%20prestamos.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />

                                                    </center>
                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>                                <div class="caption" style="text-align:center">
                                    <a href="gestionPrestamos.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-th-list"></span>
                                        <h3>Gestión de prestamos</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4" >
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#instrucDonaciones" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                 <div class="modal fade" id="instrucDonaciones" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document" style="width:1000px;">
                                        <div class="modal-content" role="document" >
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <center>
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title"> Creación de donaciones </h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Creacion%20de%20donacion.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />
                                                    <div class="panel panel-primary">
                                                    <div class="panel-heading">
                                                        <h1 class="panel-title">Control de donaciones</h1>
                                                    </div>
                                                    <div class="panel-body">
                                                        <video src="instructivos/Control%20Donaciones.mp4" controls="controls" />
                                                    </div>
                                                    </div>
                                                    <br />

                                                    </center>
                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>  
                                <div class="caption" style="text-align:center">
                                    <a href="GestionDonaciones.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-gift"></span>
                                        <h3>Gestión de donaciones</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4" >
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="container" style="width: 400px;">
                                                    <p>Instrucciones</p>
                                                </div> <!-- /container -->

                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="caption" style="text-align:center">
                                    <a href="gestionConsultas.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-info-sign"></span>
                                        <h3>Gestión de consultas</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4" >
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Gestor de ayuda</h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="container" style="width: 400px;">
                                                    <p>Instrucciones</p>
                                                </div> <!-- /container -->

                                            </div>
                                            <div class="modal-footer">
                                                <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="caption" style="text-align:center">
                                    <a href="gestionAjustes.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-wrench"></span>
                                        <h3>Gestión de ajustes</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div class="modal fade" id="exampleModaA" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h1 class="modal-title" style="text-align:center" id="exampleModalLabe">Notificaciones</h1>
                        </div>
                        <div class="modal-body">
                                <div class="container">
                                        <div runat="server" id="poolNotificaciones" style="margin-left:-20px;" class="col-md-6">
                                           
                                            <div class="alert alert-warning" role="alert">
                                                     Recuerda, toda notificación tendrá una vigencia de 6 días, 3 días antes de realizarse el evento y 3 días después del mismo. 
                                                    <button type="button" class="close" data-dismiss="alert"><span>&times;</span></button>
                                            </div>
                                        </div>
                                 </div>
                            </div> <!-- /container -->
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>

    <div class="modal fade" id="exampleModaP" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h1 class="modal-title" style="text-align:center" id="exampleModalLabe">Notificaciones</h1>
                        </div>
                        <div class="modal-body">
                                <div class="container">
                                        <div runat="server" id="poolnotificacionesP" style="margin-left:-20px;" class="col-md-6">
                                            <div class="alert alert-warning" role="alert">
                                                     Recuerda, toda notificación tendrá una vigencia de 6 días, 3 días antes de realizarse el evento y 3 días después del mismo. 
                                                    <button type="button" class="close" data-dismiss="alert"><span>&times;</span></button>
                                            </div>
                                        </div>
                                 </div>
                            </div> <!-- /container -->
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
    <!-- /.container -->
    <footer class="navbar" style="background-color:white">
        <div class="container">
            <h5 style="text-align: center" class="text-muted">EXPEDIA - Colegio de Abogados y Abogadas de Costa Rica - UNA</h5>
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
</body>
</html>
