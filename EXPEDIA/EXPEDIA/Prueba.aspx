<%@ Page Language="C#" AutoEventWireup="true"   EnableEventValidation="true" CodeBehind="Prueba.aspx.cs" Inherits="EXPEDIA.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="img/ExpediaLogo.png"/>
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <script src="js/jquery.bxslider.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/purecss.css" rel="stylesheet" />
    <script src="js/jQueryUI/jquery-ui.min.js"></script>
    <link href="js/jQueryUI/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="js/jQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <!--SCRIPT PARA TABLA CON FILTROS-->
    <link href="css/Tablas.css" rel="stylesheet" />
    <script src="http://tablefilter.free.fr/TableFilter/tablefilter_all_min.js"></script>
    <script src="http://tablefilter.free.fr/TableFilter/filtergrid.css"></script>
    <link href="css/bootstrap-table.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
<link href="css/spectrum.css" rel="stylesheet" />
<script src="js/spectrum.js"></script>
<script src="js/dw_event.js" type="text/javascript"></script>
<script src="js/dw_cookies.js" type="text/javascript"></script>
<script src="js/dw_sizerdx.js" type="text/javascript"></script>
<script type="text/javascript">
    dw_Event.add(window, 'load', dw_fontSizerDX.init);
</script>
    <!--HASTA AQUI LAS TABLAS-->
    <script src="js/dw_sizerdx.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div id="sizer"><a class="increase" href="#" title="Increase text size"><img src="images/plus.gif" alt="" border="0" /></a><a class="decrease" href="#" title="Decrease text size"><img src="images/minus.gif" alt="" border="0" /></a><a class="reset" href="#" title="Restore default font-sizes"><img src="images/reset.gif" alt="" border="0" /></a></div>
   <div id="color"><input type='text' class="colores" /> </div> 
    <script>
        $(".colores").spectrum({
            color: "#ffffff",
            showPalette: true,
            palette: [
                ['black', 'white', 'blanchedalmond'],
                ['rgb(255, 128, 0);', 'hsv 100 70 50', 'lightyellow']
            ],
            change: function (color) {
                //alert(color.toHexString());
                $('body').css("background-color", color.toHexString());
            }
        });
            </script>
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
                        <li><a href="#tab2primary" data-toggle="tab">Conozcanos</a></li>
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
        <div class="panel panel-primary"  style="background-color:transparent;">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de activos</h3>
            </div>
            <div class="panel-body">
                <div class="tabs-example">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#Ingresar" data-toggle="tab">Consulta de activos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                        <li><a href="#Consultar" data-toggle="tab">Consulta de bitacora  <span class="glyphicon glyphicon-question-sign"></span><span class="glyphicon glyphicon-minus-sign"></span><span class="glyphicon glyphicon-ok-sign"></span></a></li>
                        <a style="float:right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Activos</h1>
                            <form class="pure-form pure-form-aligned">
                                    <div id="dvData">
                                       <asp:textbox runat="server" ID="numero"/>
                     <asp:Button runat="server" ID="Button1" OnClick="Consultar_Click" />
                                <asp:GridView  runat="server" ID="lista" CssClass="table" >
                                                     </asp:GridView>

                                      

                                    </div>
                                    <br />
                                    <br />
                                    <input class="btn btn-success" type="button" id="btnExport" value=" Exportar a Excel " />


                                    <script>
                                    $("#btnExport").click(function (e) {

                                        window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#dvData').html()));

                                        e.preventDefault();

                                    });

                                    </script>

                                
                            </form>
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                            <h1 style="text-align:center" id="titulo">Bitacora</h1>
                            <div class="pure-form pure-form-aligned">
                                <div id="dvData1">




                                </div>

              

                            </div>
                            <br />
                            <br />
                            <input class="btn btn-success" type="button" id="btnExport11" value=" Exportar a Excel " />
                            <script>
                                    $("#btnExport11").click(function (e) {

                                        window.open('data:application/vnd.ms-excel,' + encodeURIComponent($('#dvData1').html()));

                                        e.preventDefault();

                                    });

                            </script>

                            
                            </div>
                       
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="navbar" style="background-color:white">
        <div class="container">
            <h5 style="text-align: center" class="text-muted">Prototipo I EXPEDIA - Ingeniería en sistemas de información II</h5>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#enviar").click(function () {
                $('#mensaje').show(2000, 'swing', function () {
                    //callback function after animation finished
                    $("enviar").attr('value', 'Las acciones han sido realizadas correctamente');
                });
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
    <script>
    function Guardar(y)
    { switch(y){
    case 1: { localStorage["Descripcion"] = document.getElementById("ocupacion").value; break; }
    case 2: { localStorage["Area"] = document.getElementById("area57").value; break; }
    case 3: { localStorage["Proveedor"] = document.getElementById("nproveedor").value; break; }
    }
    }


    function Mostrar_Infoo(x)
    {
        switch (x) {
            case 1: { var option = document.createElement("option");
                option.text = localStorage["Descripcion"].toString();
                document.getElementById("descripcion").add(option);
            Mostrar_Infoo(4);
            break;
            }
            case 2: {var option1 = document.createElement("option");
            option1.text = localStorage["Area"];
            document.getElementById("area").add(option1);
            Mostrar_Infoo(5);
            break;
            }
            case 3: {
            var option = document.createElement("option");
            option.text = localStorage["Proveedor"].toString();
            document.getElementById("provedor").add(option);
            Mostrar_Infoo(6);
            break;
            }

            case 4: {
            var option1 = document.createElement("option");
            option1.text = localStorage["Descripcion"];
            document.getElementById("descripcion1").add(option1); break;
            }
            case 5: { var option1 = document.createElement("option");
                option1.text = localStorage["Area"];
                document.getElementById("area1").add(option1); break;
            }
            case 6: { var option = document.createElement("option");
                option.text = localStorage["Proveedor"].toString();
                document.getElementById("prove1").add(option); break;
            }
            }

    }</script>
        
 

    
    </form>
</body>
</html>
