<%@ Page Language="C#"  AutoEventWireup="true" EnableEventValidation="true" CodeBehind="GestionConsultas.aspx.cs" Inherits="EXPEDIA.GestionConsultas" %>

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
    <link href="css/purecss.css" rel="stylesheet" />
    <script src="js/jQueryUI/jquery-ui.min.js"></script>
    <link href="js/jQueryUI/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="js/jQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/Tablas.css" rel="stylesheet" />

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
                    <%-- PANTALLA DONDE SE MUESTRA LAS OPCIONES DE CONSULTA DE ACTIVOS  --%>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Activos</h1>
                            
                                     <label  for="numero" >Número de Placa / Serie </label>
                                       <asp:textbox runat="server" ID="numero"/>
                             <div class="pure-control-group">
                             <label for="descripcion">Descripción del activo</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="En este espacio puede seleccionar la descripción a buscar." id="descripcion_activo" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Elija una descripción</asp:ListItem>
                                        </asp:DropDownList>
                             
                             
                             <label for="area">Departamento o Sede regional destinado(a)</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="En este espacio puede seleccionar el Departamento o Sede regional destinado(a) a buscar. " id="departamento_activo" CssClass="pure-input-1-2">
                                          <asp:ListItem Value="0">Elija un Departamento o Sede</asp:ListItem>
                                             </asp:DropDownList>
                                
                             
                             <label for="provedor">Proveedor</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title=" En este espacio puede selecionar el nombre del proveedor del activo a buscar." id="proveedor" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Elija un proveedor</asp:ListItem>
                                             </asp:DropDownList>
                                 </div>

                     <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" OnClick="Consultar_Click"  Text="Consultar"/>
                               <br />
                               <br />
                                <asp:GridView  runat="server" ID="lista" CssClass="table" > </asp:GridView>

                                    <br />
                                    <br />
                                   
                            <asp:Button ID="exportar" runat="server"    CssClass="btn btn-success" Text="Exportar a Excel"  OnClick="exportar_Click" />
                            

                                  

                        
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

  
        </form>
   
        	<script >
		$(function() {
		  theTable = $("#lista");
		  $("#q").keyup(function() {
			$.uiTableFilter(theTable, this.value);
		  });
		});
		</script>

  
</body>
</html>
