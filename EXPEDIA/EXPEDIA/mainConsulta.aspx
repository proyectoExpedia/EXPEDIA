<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainConsulta.aspx.cs" Inherits="EXPEDIA.mainConsulta" %>

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
         <nav class="navbar" role="navigation" style="margin-top: 20px;">
            <div class="container">
                <ul class="bxslider">
                    <li>
                        <img src="img/colegioAbogadoscr.png" style="width: 100px; height: 100px; float: left" alt="" /></li>
                    <li>
                        <img src="img/ExpediaLogo.png" alt="" style="width: 100px; height: 100px; float: left" /></li>
                </ul>
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
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" style="float: right" href="#">
                        <h3>Colegio de Abogados y Abogadas de Costa Rica</h3>
                    </a>
                </div>

                <!----------------------------------------------- Opciones menu ------------------------------------------------------>
                <div class="col-md-6" style="margin-top: 15px;">
                    <div class="panel-heading">
                        <ul class="nav">
                         <li>
                            <div class="container" style="float:left; margin-left: 500px; margin-top:-55px;">
                                
                                <a class="btn btn-default btn-lg btn-link"  href="index.aspx" style="font-size:36px;">
                                <span class="glyphicon glyphicon-log-out"><br /><p style="font-size:12px; font-family:sans-serif;"> <br />Cerrar<br />sesión</p></span> 
                                </a>

                            </div>

                        </li>
                        </ul>
                    </div>
                </div>
                <!-----------------------------------------------Fin de las opciones----------------------------------------------->
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
                    <h1 style="text-align: center"><b>Bienvenido </b></h1>
                    <h2 style="text-align: center"> Elige tu opcion</h2>
                    </div>
                    <div class="row" >


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
                                    <a href="gestionConsultasComun.aspx" class="btn">
                                        <span style="font-size: 60px" class="glyphicon glyphicon-info-sign"></span>
                                        <h3>Gestión de consultas</h3>
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
