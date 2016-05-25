

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
    <script src="js/jQueryUI/jquery-ui.min.js"></script>
    <link href="js/jQueryUI/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="js/jQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/Exportacion/base64.js"></script>
    <script src="js/Exportacion/html2canvas.js"></script>
    <script src="js/Exportacion/jquery.base64.js"></script>
    <script src="js/Exportacion/jspdf.js"></script>
    <script src="js/Exportacion/sprintf.js"></script>
    <script src="js/Exportacion/tableExport.js"></script>
</head>

<body>

    <form id="for" runat="server" >
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
        <div style="margin-top:50px;"><asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath></div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="panel-title">Gestión de Activos</h3>
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
                            
                                     <label  for="numero" >Número de Placa / Serie </label>
                                       <asp:textbox runat="server" ID="numero"/>
                             <div class="pure-control-group">
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
                                <div runat="server" ID="export" class="btn-group" style="float:right;display:none; margin-bottom:10px;">
                                    <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Exportar <span class="caret"></span>
                </button>
                                    <ul class="dropdown-menu">
                    <li><a id="excel">Excel</a></li>
                    <li><a id="word">Word</a></li>
                    <li><a id="texto">Texto</a></li>
                    <li><a id="sql">SQL</a></li>
                    <li><a id="pdf">PDF</a></li>
                    <li><a id="xml">XML</a></li>
                    <li><a id="json">JSON</a></li>
                </ul>
                                </div>
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
                                <br />
                                 <div class="tab-pane fade in active" id="Usuarios">
                                    <asp:Table ID="Table2" runat="server" CssClass="table table-hover table-bordered results">
                                                         <asp:TableHeaderRow runat="server">
                                                                <asp:TableHeaderCell ColumnSpan="1">Identificador</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Nombre</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Correo electrónico</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Contacto</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Acciones</asp:TableHeaderCell>
                                                         </asp:TableHeaderRow>
                                                         <asp:TableRow CssClass="warning no-result">
                                                        <asp:TableCell ColumnSpan="4" CssClass="fa fa-warning">No existen resultados</asp:TableCell>
                                                    </asp:TableRow>
                                                    </asp:Table>   
                                 </div>

                                 <div class="tab-pane fade" id="Activos">
                                     <br />
                                    <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-bordered results">
                                                         <asp:TableHeaderRow runat="server">
                                                                <asp:TableHeaderCell ColumnSpan="1">Identificador</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Nombre</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Correo electrónico</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Contacto</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Acciones</asp:TableHeaderCell>
                                                         </asp:TableHeaderRow>
                                                         <asp:TableRow CssClass="warning no-result">
                                                        <asp:TableCell ColumnSpan="4" CssClass="fa fa-warning">No existen resultados</asp:TableCell>
                                                    </asp:TableRow>
                                                    </asp:Table>    
                                 </div>

                                 
                                 <div class="tab-pane fade" id="Prestamos">
                                     <br />
                                    <asp:Table ID="Table3" runat="server" CssClass="table table-hover table-bordered results">
                                                         <asp:TableHeaderRow runat="server">
                                                                <asp:TableHeaderCell ColumnSpan="1">Identificador</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Nombre</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Correo electrónico</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Contacto</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Acciones</asp:TableHeaderCell>
                                                         </asp:TableHeaderRow>
                                                         <asp:TableRow CssClass="warning no-result">
                                                        <asp:TableCell ColumnSpan="4" CssClass="fa fa-warning">No existen resultados</asp:TableCell>
                                                    </asp:TableRow>
                                                    </asp:Table>  
                                 </div>

                                 
                                 <div class="tab-pane fade" id="Donaciones">
                                     <br />
                                    <asp:Table ID="Table4" runat="server" CssClass="table table-hover table-bordered results">
                                                         <asp:TableHeaderRow runat="server">
                                                                <asp:TableHeaderCell ColumnSpan="1">Identificador</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Nombre</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Correo electrónico</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Contacto</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Acciones</asp:TableHeaderCell>
                                                         </asp:TableHeaderRow>
                                                         <asp:TableRow CssClass="warning no-result">
                                                        <asp:TableCell ColumnSpan="4" CssClass="fa fa-warning">No existen resultados</asp:TableCell>
                                                    </asp:TableRow>
                                                    </asp:Table>  
                                 </div>


                             </div>
                            <br />
                            <br />
                            <input class="btn btn-success" type="button" id="btnExport11" value=" Exportar a Excel " /> 
                       </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>

    <footer class="navbar" style="background-color:white">
        <div class="container">
<%--            <h5 style="text-align: center" class="text-muted">Prototipo I EXPEDIA - Ingeniería en sistemas de información II</h5>--%>
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
             $("#excel").click(function (e) {
                 $("#lista").tableExport({
                     type: 'excel',
                     escape: false
                 });
             });
             $("#pdf").click(function (e) {
                 $("#lista").tableExport({
                     type: 'pdf',
                     escape: true,
                     pdfLeftMargin:10,
                     pdfFontSize:8
                 });
             });
             $("#word").click(function (e) {
                 $("#lista").tableExport({
                     type: 'doc',
                     escape: false
                 });
             });
             $("#sql").click(function (e) {
                 $("#lista").tableExport({
                     type: 'sql',
                     escape: false
                 });
             });
             $("#xml").click(function (e) {
                 $("#lista").tableExport({
                     type: 'xml',
                     escape: false
                 });
             });
             $("#json").click(function (e) {
                 $("#lista").tableExport({
                     type: 'json',
                     escape: false
                 });
             });
             $("#texto").click(function (e) {
                 $("#lista").tableExport({
                     type: 'txt',
                     escape: false
                 });
             });
             $("#png").click(function (e) {
                 $("#lista").tableExport({
                     type: 'png',
                     escape: false
                 });
             });
         });
    </script>
  
</body>
</html>
