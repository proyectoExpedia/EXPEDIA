﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionConsultas.aspx.cs" Inherits="EXPEDIA.GestionConsultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="img/ExpediaLogo.png">
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
    <!--HASTA AQUI LAS TABLAS-->
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
        <div class="panel panel-primary">
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
                                        <table  id="table"  class="TABLAS">
                                            <tr>
                                                <td>World Regions</td>
                                                <td>Population ( 2007 Est.)</td>
                                                <td>Population % of World</td>
                                                <td>% Population ( Penetration )</td>
                                                <td>Usage % of World</td>
                                            </tr>
                                            <tr>
                                                <td>Africa</td>
                                                <td>933 448 292</td>
                                                <td>14.2</td>
                                                <td>3.5</td>
                                                <td>3.0 %</td>
                                            </tr>
                                            <tr>
                                                <td>Asia</td>
                                                <td>3 712 527 624</td>
                                                <td>56.5</td>
                                                <td>10.5</td>
                                                <td>35.6 %</td>
                                            </tr>
                                            <tr>
                                                <td>Europe</td>
                                                <td>809 624 686</td>
                                                <td>12.3</td>
                                                <td>38.6</td>
                                                <td>28.6 %</td>
                                            </tr>
                                            <tr>
                                                <td>Middle East</td>
                                                <td>193 452 727</td>
                                                <td>2.9</td>
                                                <td>10.0</td>
                                                <td>1.8 %</td>
                                            </tr>
                                            <tr>
                                                <td>North America</td>
                                                <td>334 538 018</td>
                                                <td>5.1</td>
                                                <td>69.4</td>
                                                <td>21.2 %</td>
                                            </tr>
                                            <tr>
                                                <td>Latin America / Caribbean</td>
                                                <td>556 606 627</td>
                                                <td>8.5</td>
                                                <td>16.0</td>
                                                <td>8.1 %</td>
                                            </tr>
                                            <tr>
                                                <td>Oceania / Australia</td>
                                                <td>34 468 443</td>
                                                <td>0.5</td>
                                                <td>53.5</td>
                                                <td>1.7 %</td>
                                            </tr>
                                        </table>


                                        <script>
                                        var table11_Props = {
                                            filters_row_index: 1,
                                            remember_grid_values: true
                                        };
                                        var tf11 = setFilterGrid("table11", table11_Props);
                                        </script>

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
                                    <table id="table1" class="TABLAS">
                                        <tr>
                                            <td>World Regions</td>
                                            <td>Population ( 2007 Est.)</td>
                                            <td>Population % of World</td>
                                            <td>% Population ( Penetration )</td>
                                            <td>Usage % of World</td>
                                        </tr>
                                        <tr>
                                            <td>Africa</td>
                                            <td>933 448 292</td>
                                            <td>14.2</td>
                                            <td>3.5</td>
                                            <td>3.0 %</td>
                                        </tr>
                                        <tr>
                                            <td>Asia</td>
                                            <td>3 712 527 624</td>
                                            <td>56.5</td>
                                            <td>10.5</td>
                                            <td>35.6 %</td>
                                        </tr>
                                        <tr>
                                            <td>Europe</td>
                                            <td>809 624 686</td>
                                            <td>12.3</td>
                                            <td>38.6</td>
                                            <td>28.6 %</td>
                                        </tr>
                                        <tr>
                                            <td>Middle East</td>
                                            <td>193 452 727</td>
                                            <td>2.9</td>
                                            <td>10.0</td>
                                            <td>1.8 %</td>
                                        </tr>
                                        <tr>
                                            <td>North America</td>
                                            <td>334 538 018</td>
                                            <td>5.1</td>
                                            <td>69.4</td>
                                            <td>21.2 %</td>
                                        </tr>
                                        <tr>
                                            <td>Latin America / Caribbean</td>
                                            <td>556 606 627</td>
                                            <td>8.5</td>
                                            <td>16.0</td>
                                            <td>8.1 %</td>
                                        </tr>
                                        <tr>
                                            <td>Oceania / Australia</td>
                                            <td>34 468 443</td>
                                            <td>0.5</td>
                                            <td>53.5</td>
                                            <td>1.7 %</td>
                                        </tr>
                                    </table>
                                </div>

                                <script>
                                        var table11_Props = {
                                            filters_row_index: 1,
                                            remember_grid_values: true
                                        };
                                        var tf11 = setFilterGrid("table1", table11_Props);
                                </script>

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
</body>
</html>
