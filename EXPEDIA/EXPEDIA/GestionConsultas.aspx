

<%@ Page Language="C#"  AutoEventWireup="true" EnableEventValidation="true" CodeBehind="GestionConsultas.aspx.cs" Inherits="EXPEDIA.GestionConsultas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="img/ExpediaLogo.png" />
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <script src="js/jquery.bxslider.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/purecss.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/Exportacion/base64.js"></script>
    <script src="js/Exportacion/html2canvas.js"></script>
    <script src="js/Exportacion/jquery.base64.js"></script>
    <script src="js/Exportacion/jspdf.js"></script>
    <script src="js/Exportacion/sprintf.js"></script>
    <script src="js/Exportacion/tableExport.js"></script>
        <link href="css/bootstrap-table.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>
</head>

<body>

    <form id="for" runat="server" >
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
           

    <center>
    <div style="text-align:left;width:90%">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
            <br />
            <br />
        
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de consultas</h3>
            </div>
            <div class="panel-body">
                <div class="tabs-example">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#Ingresar" data-toggle="tab">Consulta de activos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                        <li><a href="#Consultar" data-toggle="tab">Consulta de bitácora  <span class="glyphicon glyphicon-question-sign"></span><span class="glyphicon glyphicon-minus-sign"></span><span class="glyphicon glyphicon-ok-sign"></span></a></li>
                        <a style="float:right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                    </ul>
                    <%-- PANTALLA DONDE SE MUESTRA LAS OPCIONES DE CONSULTA DE ACTIVOS  --%>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Activos</h1>
                                    <label for="tipo_activo">Tipo de Activo</label>
                                 <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">
                                        <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="excell">Excel</a></li>
                                                <li><a id="wordl">Word</a></li>
                                                <li><a id="textol">Texto</a></li>
                                                <li><a id="sqll">SQL</a></li>
                                                <li><a id="pdfl">PDF</a></li>
                                                <li><a id="xmll">XML</a></li>
                                                <li><a id="jsonl">JSON</a></li>
                                            </ul>
                                        </div>
                                    <div class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-primary" >
                                            <asp:RadioButton  runat="server" GroupName="tipo" ID="RadioButton2" Text="Software" autocomplete="off" />
                                        </label>
                                        <label class="btn btn-primary ">
                                            <asp:RadioButton runat="server"   GroupName="tipo" ID="RadioButton3" Text="Hardware" autocomplete="off" />
                                        </label>
                                        <label class="btn btn-primary " >
                                            <asp:RadioButton runat="server"   GroupName="tipo" ID="RadioButton4" Text="Leasing" autocomplete="off" />
                                        </label>

                                    </div>
                                
                            <br />
                            <br />
                            

                             <div class="pure-control-group">

                                                                     <label  for="numero" >Número de Placa / Serie </label>
                                       <asp:textbox runat="server" ID="numero"/>
                     <br />
                                      <br />
                             <label for="descripcion">Descripción del activo</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="Seleccione una descripción como filtro para búsqueda." id="descripcion_activo" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Elija una descripción</asp:ListItem>
                                        </asp:DropDownList>
                             <br />
                             
                             <label for="departamento_activo">Departamento o Sede regional destinado(a)</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="Seleccione un departamento o área como filtro para su búsqueda." id="departamento_activo" CssClass="pure-input-1-2">
                                          <asp:ListItem Value="0">Elija un Departamento o Sede</asp:ListItem>
                                             </asp:DropDownList>
                                
                             <br />
                             <label for="proveedor">Proveedor</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="Seleccione un proveedor como filtro para búsqueda." id="proveedor" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Elija un proveedor</asp:ListItem>
                                             </asp:DropDownList>
                                 </div>

                     <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" OnClick="Consultar_Click"  Text="Consultar"/>
                               <br />
                               <br />
                                </div>                        <br />
                                                        <br />
     
                                <asp:GridView  runat="server" ID="lista" CssClass="table table-hover table-bordered results" > </asp:GridView>
                                    <br />
                                    <br />                                   
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                             <h1 style="text-align:center" id="titulo">Bitácoras</h1>
   
                             <div style="text-align:center">
                             <ul id="myTab1" class="nav nav-justified">
                                 <li class="active"><a href="#Activos" data-toggle="tab">Bitácora activos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                                 <li><a href="#Usuarios" data-toggle="tab">Bitácora usuarios <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                                 <li><a href="#Prestamos" data-toggle="tab">Bitácora préstamos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                                 <li><a href="#Donaciones" data-toggle="tab">Bitácora donaciones<span class="glyphicon glyphicon-plus-sign"></span></a></li>
                             </ul>
                             </div>
                            <div id="myTabConten" class="tab-content">

                                 <div class="tab-pane fade" id="Usuarios">
                                        <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="excelu">Excel</a></li>
                                                <li><a id="wordu">Word</a></li>
                                                <li><a id="textou">Texto</a></li>
                                                <li><a id="sqlu">SQL</a></li>
                                                <li><a id="pdfu">PDF</a></li>
                                                <li><a id="xmlu">XML</a></li>
                                                <li><a id="jsonu">JSON</a></li>
                                            </ul>
                                        </div>
                                     <br />
                                     <div runat="server" id="usuarios">

                                     </div>  
                                 </div>

                                 <div class="tab-pane fade in active" id="Activos">
                                        <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="excelac">Excel</a></li>
                                                <li><a id="wordac">Word</a></li>
                                                <li><a id="textoac">Texto</a></li>
                                                <li><a id="sqlac">SQL</a></li>
                                                <li><a id="pdfac">PDF</a></li>
                                                <li><a id="xmlac">XML</a></li>
                                                <li><a id="jsonac">JSON</a></li>
                                            </ul>
                                        </div>
                                     <br />
                                     <div runat="server" id="activosCorp">
                                         

                                     </div>
                                     <br />
                                     <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="excelal">Excel</a></li>
                                                <li><a id="wordal">Word</a></li>
                                                <li><a id="textoal">Texto</a></li>
                                                <li><a id="sqlal">SQL</a></li>
                                                <li><a id="pdfal">PDF</a></li>
                                                <li><a id="xmlal">XML</a></li>
                                                <li><a id="jsonal">JSON</a></li>
                                            </ul>
                                        </div>
                                     <div runat="server" id="activosLeasing">
                                         <h1 style="text-align:center">Leasing</h1>

                                     </div>   

                                 </div>

                                 
                                 <div class="tab-pane fade" id="Prestamos">
                                         <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="excelp">Excel</a></li>
                                                <li><a id="wordp">Word</a></li>
                                                <li><a id="textop">Texto</a></li>
                                                <li><a id="sqlp">SQL</a></li>
                                                <li><a id="pdfp">PDF</a></li>
                                                <li><a id="xmlp">XML</a></li>
                                                <li><a id="jsonp">JSON</a></li>
                                            </ul>
                                        </div>
                                     <br />
                                     <div runat="server" id="prestamos">

                                     </div>  
                                 </div>

                                 
                                 <div class="tab-pane fade" id="Donaciones">
                                        <div class="btn-group" style="float:right;">
                                            <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                Exportar <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu">
                                                <li><a id="exceld">Excel</a></li>
                                                <li><a id="wordd">Word</a></li>
                                                <li><a id="textod">Texto</a></li>
                                                <li><a id="sqld">SQL</a></li>
                                                <li><a id="pdfd">PDF</a></li>
                                                <li><a id="xmld">XML</a></li>
                                                <li><a id="jsond">JSON</a></li>
                                            </ul>
                                        </div>
                                     <br />
                                     <div runat="server" id="donaciones">

                                     </div>  
                                 </div>


                             </div>
                            <br />
                            <br />
                            
                       </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </center>
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

  
     </form>
  
     <script >
		$(function() {
		  theTable = $("#lista");
		  $("#q").keyup(function() {
			$.uiTableFilter(theTable, this.value);
		  });
		});
	 </script>
     <script>
         $(document).ready(function (e) {
             $("#excelu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'excel',
                     escape: false
                 });
             });
             $("#pdfu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'pdf',
                     escape: true,
                     pdfLeftMargin:10,
                     pdfFontSize:8
                 });
             });
             $("#wordu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'doc',
                     escape: false
                 });
             });
             $("#sqlu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'sql',
                     escape: false
                 });
             });
             $("#xmlu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'xml',
                     escape: false
                 });
             });
             $("#jsonu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'json',
                     escape: false
                 });
             });
             $("#textou").click(function (e) {
                 $("#usua").tableExport({
                     type: 'txt',
                     escape: false
                 });
             });
             $("#pngu").click(function (e) {
                 $("#usua").tableExport({
                     type: 'png',
                     escape: false
                 });
             });
         });
    </script>
     <script>
             $(document).ready(function (e) {
                 $("#exceld").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'excel',
                         escape: false
                     });
                 });
                 $("#pdfd").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'pdf',
                         escape: true,
                         pdfLeftMargin: 10,
                         pdfFontSize: 8
                     });
                 });
                 $("#wordd").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'doc',
                         escape: false
                     });
                 });
                 $("#sqld").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'sql',
                         escape: false
                     });
                 });
                 $("#xmld").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'xml',
                         escape: false
                     });
                 });
                 $("#jsond").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'json',
                         escape: false
                     });
                 });
                 $("#textod").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'txt',
                         escape: false
                     });
                 });
                 $("#pngd").click(function (e) {
                     $("#Dona").tableExport({
                         type: 'png',
                         escape: false
                     });
                 });
             });
    </script>
     <script>
             $(document).ready(function (e) {
                 $("#excelp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'excel',
                         escape: false
                     });
                 });
                 $("#pdfp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'pdf',
                         escape: true,
                         pdfLeftMargin: 10,
                         pdfFontSize: 8
                     });
                 });
                 $("#wordp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'doc',
                         escape: false
                     });
                 });
                 $("#sqlp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'sql',
                         escape: false
                     });
                 });
                 $("#xmlp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'xml',
                         escape: false
                     });
                 });
                 $("#jsonp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'json',
                         escape: false
                     });
                 });
                 $("#textop").click(function (e) {
                     $("#pres").tableExport({
                         type: 'txt',
                         escape: false
                     });
                 });
                 $("#pngp").click(function (e) {
                     $("#pres").tableExport({
                         type: 'png',
                         escape: false
                     });
                 });
             });
    </script>
     <script>
             $(document).ready(function (e) {
                 $("#excelac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'excel',
                         escape: false
                     });

                 });
                 $("#pdfac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'pdf',
                         escape: false
                     });
                 });
                 $("#wordac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'doc',
                         escape: false
                     });
                 });
                 $("#sqlac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'sql',
                         escape: false
                     });
                 });
                 $("#xmlac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'xml',
                         escape: false
                     });
                 });
                 $("#jsonac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'json',
                         escape: false
                     });
                 });
                 $("#textoac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'txt',
                         escape: false
                     });
                 });
                 $("#pngac").click(function (e) {
                     $("#actiCorp").tableExport({
                         type: 'png',
                         escape: false
                     });
                 });
             });
    </script>
     <script>
        $(document).ready(function (e) {
            $("#excelal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'excel',
                    escape: false
                });

            });
            $("#pdfal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'pdf',
                    escape: false
                });
            });
            $("#wordal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'doc',
                    escape: false
                });
            });
            $("#sqlal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'sql',
                    escape: false
                });
            });
            $("#xmlal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'xml',
                    escape: false
                });
            });
            $("#jsonal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'json',
                    escape: false
                });
            });
            $("#textoal").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'txt',
                    escape: false
                });
            });
            $("#pnga").click(function (e) {
                $("#actiLeasing").tableExport({
                    type: 'png',
                    escape: false
                });
            });
        });
    </script>
     <script>
        $(document).ready(function (e) {
            $("#excel").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'excel',
                    escape: false
                });

            });
            $("#pdf").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'pdf',
                    escape: false
                });
            });
            $("#word").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'doc',
                    escape: false
                });
            });
            $("#sql").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'sql',
                    escape: false
                });
            });
            $("#xml").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'xml',
                    escape: false
                });
            });
            $("#json").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'json',
                    escape: false
                });
            });
            $("#texto").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'txt',
                    escape: false
                });
            });
            $("#png").click(function (e) {
                $("#usuarios").tableExport({
                    type: 'png',
                    escape: false
                });
            });
        });
    </script>
     <script>
         $(document).ready(function () {
             $('#actiCorp').DataTable({
                 "language": {
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
                     "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                     "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                     "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                     "sInfoPostFix": "",
                     "sSearch": "Buscar:",
                     "sUrl": "",
                     "sInfoThousands": ",",
                     "sLoadingRecords": "Cargando...",
                     "oPaginate": {
                         "sFirst": "Primero",
                         "sLast": "Último",
                         "sNext": "Siguiente",
                         "sPrevious": "Anterior"
                     },
                     "oAria": {
                         "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                         "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                     }
                 }
             });
             $('#actiLeasing').DataTable({
                 "language": {
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
                     "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                     "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                     "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                     "sInfoPostFix": "",
                     "sSearch": "Buscar:",
                     "sUrl": "",
                     "sInfoThousands": ",",
                     "sLoadingRecords": "Cargando...",
                     "oPaginate": {
                         "sFirst": "Primero",
                         "sLast": "Último",
                         "sNext": "Siguiente",
                         "sPrevious": "Anterior"
                     },
                     "oAria": {
                         "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                         "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                     }
                 }
             });
             $('#usua').DataTable({
                 "language": {
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
                     "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                     "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                     "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                     "sInfoPostFix": "",
                     "sSearch": "Buscar:",
                     "sUrl": "",
                     "sInfoThousands": ",",
                     "sLoadingRecords": "Cargando...",
                     "oPaginate": {
                         "sFirst": "Primero",
                         "sLast": "Último",
                         "sNext": "Siguiente",
                         "sPrevious": "Anterior"
                     },
                     "oAria": {
                         "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                         "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                     }
                 }
             });
             $('#pres').DataTable({
                 "language": {
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
                     "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                     "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                     "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                     "sInfoPostFix": "",
                     "sSearch": "Buscar:",
                     "sUrl": "",
                     "sInfoThousands": ",",
                     "sLoadingRecords": "Cargando...",
                     "oPaginate": {
                         "sFirst": "Primero",
                         "sLast": "Último",
                         "sNext": "Siguiente",
                         "sPrevious": "Anterior"
                     },
                     "oAria": {
                         "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                         "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                     }
                 }
             });
             $('#Dona').DataTable({
                 responsive: true,
                 "language": {
                     "sProcessing": "Procesando...",
                     "sLengthMenu": "Mostrar _MENU_ registros",
                     "sZeroRecords": "No se encontraron resultados",
                     "sEmptyTable": "Ningún dato disponible en esta tabla",
                     "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                     "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                     "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                     "sInfoPostFix": "",
                     "sSearch": "Buscar:",
                     "sUrl": "",
                     "sInfoThousands": ",",
                     "sLoadingRecords": "Cargando...",
                     "oPaginate": {
                         "sFirst": "Primero",
                         "sLast": "Último",
                         "sNext": "Siguiente",
                         "sPrevious": "Anterior"
                     },
                     "oAria": {
                         "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                         "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                     }
                 }
             });
         });
         
    </script>  
     <script>
             $(document).ready(function (e) {
                 $("#excell").click(function (e) {
                     $("#lista").tableExport({
                         type: 'excel',
                         escape: false
                     });

                 });
                 $("#pdfl").click(function (e) {
                     $("#lista").tableExport({
                         type: 'pdf',
                         escape: false
                     });
                 });
                 $("#wordl").click(function (e) {
                     $("#lista").tableExport({
                         type: 'doc',
                         escape: false
                     });
                 });
                 $("#sqll").click(function (e) {
                     $("#lista").tableExport({
                         type: 'sql',
                         escape: false
                     });
                 });
                 $("#xmll").click(function (e) {
                     $("#lista").tableExport({
                         type: 'xml',
                         escape: false
                     });
                 });
                 $("#jsonl").click(function (e) {
                     $("#lista").tableExport({
                         type: 'json',
                         escape: false
                     });
                 });
                 $("#textol").click(function (e) {
                     $("#lista").tableExport({
                         type: 'txt',
                         escape: false
                     });
                 });
                 $("#pngl").click(function (e) {
                     $("#lista").tableExport({
                         type: 'png',
                         escape: false
                     });
                 });
             });
    </script>
</body>
</html>
