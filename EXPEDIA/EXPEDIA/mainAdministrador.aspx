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
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="index.aspx">Salir</a></li>
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
    <div class="container">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
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
                                <a class="" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div style="color:#161f68" class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
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
                                    <a href="gestionUsuarios.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-user"></span>
                                        <h3>Gestión de usuarios</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4">
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
                                        <a href="gestionActivos.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-barcode"></span>
                                        <h3>Gestión de activos</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4" style="display:none;" >
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
                                    <a href="" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-shopping-cart"></span>
                                        <h3>Gestión de proveedores</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-3 col-md-4">
                            <div class="thumbnail"   style=" border: 7px double #003566;">
                                <a class="" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo">
                                    <span style="font-size: 40px" class="glyphicon glyphicon-question-sign"></span>
                                </a>
                                <div style="color:#161f68" class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
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
                                    <a href="gestionPrestamos.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-th-list"></span>
                                        <h3>Gestión de prestamos</h3>
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
                                    <a href="gestionAreas.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-globe"></span>
                                        <h3>Gestión de áreas</h3>
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
                                    <a href="gestionPuestos.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-briefcase"></span>
                                        <h3>Gestión de puestos</h3>
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
                                    <a href="gestionProveedores.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-shopping-cart"></span>
                                        <h3>Gestión de proveedores</h3>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <!-- /.container -->
    <footer class="navbar" style="background-color:white">
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
</body>
</html>
