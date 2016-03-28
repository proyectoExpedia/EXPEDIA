
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionActivos.aspx.cs" Inherits="EXPEDIA.gestionActivos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


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
    <link href="css/purecss.css" rel="stylesheet"/>
    <script src="js/jQueryUI/jquery-ui.min.js"></script>
    <link href="js/jQueryUI/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="js/jQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
</head>
<body>
    <!--               Menu                -->
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="index.aspx">Salir</a></li>
                            <li><a href="#tab2primary" data-toggle="tab">Conozcanos</a></li>
                            <li><a href="#tab3primary" data-toggle="tab">Contacto</a></li>
                        </ul>
                    </div>
                </div>
                <!-----------------------------------------------Fin de las opciones----------------------------------------------->
            </div>
        </nav>

            
        <div class="container">
        <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
        <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Gestión de activos</h3>
                    <div>
                    <a style="float: right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>Atrás</a>
                    </div>
                </div>               

        <div class="panel-body">    
        <cc1:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0"> 
            
             <%-- Formulario 1 --%>            
           
            <cc1:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de Activos</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align: center">Control de Activos</h1>
                            <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">
                            <fieldset>
                                <div class="pure-controls-group">
                                    <label for="tipo_activo">Tipo de activo</label>
                                    <div style="margin-left: 55px" class="btn-group" data-toggle="buttons">
                                        <label class="btn btn-primary" onclick="mostrarleasing(1);">
                                            <asp:RadioButton runat="server" ID="RadioButton2" Text="Software" autocomplete="off" GroupName="TiposActivo"/>
                                        </label>
                                        <label class="btn btn-primary " onclick="mostrarleasing(2);">
                                            <asp:RadioButton runat="server" ID="RadioButton3" Text="Hardware" autocomplete="off" GroupName="TiposActivo"/>
                                        </label>
                                        <label class="btn btn-primary " onclick="mostrarleasing(3);">
                                            <asp:RadioButton runat="server" ID="RadioButton4" Text="Leasing" autocomplete="off" GroupName="TiposActivo"/>
                                        </label>
                                    </div>
                                        <asp:CustomValidator id="ValidarRadio234" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Seleccione Uno" ClientValidationFunction="ValidarRadio234_ClientValidate" OnServerValidate="ValidarRadio234_ServerValidate"></asp:CustomValidator>
                                </div>

                                <script>
                                    function ValidarRadio234_ClientValidate(source, args)
                                        {   
                                            if(document.getElementById("<%= RadioButton2.ClientID %>").checked || document.getElementById("<%= RadioButton3.ClientID %>").checked || document.getElementById("<%= RadioButton4.ClientID %>").checked)
                                            {
                                                args.IsValid = true;
                                            }
                                            else
                                            {
                                                args.IsValid = false;
                                                
                                            }
    
                                        }
                                </script>

                                <script>
                                    //function mostrarleasing() {
                                    //    document.getElementById('leasing').style.display = 'block';
                                    //}
                                    function mostrarleasing(algo) {
                                        switch (algo) {
                                            case 1:
                                                document.getElementById('leasing').style.display = 'none';
                                                document.getElementById('leaComp').style.display = 'block';
                                                document.getElementById('leaComp2').style.display = 'block';
                                                document.getElementById('leaComp3').style.display = 'block';
                                                document.getElementById('fecha_adquisicion').value = "1/1/1900";
                                                document.getElementById('finalizacion_contrato').value = "1/1/1900";

                                                break;
                                            case 2:
                                                document.getElementById('leasing').style.display = 'none';
                                                document.getElementById('leaComp').style.display = 'block';
                                                document.getElementById('leaComp2').style.display = 'block';
                                                document.getElementById('leaComp3').style.display = 'block';
                                                document.getElementById('fecha_adquisicion').value = "1/1/1900";
                                                document.getElementById('finalizacion_contrato').value = "1/1/1900";
                                                break;
                                            case 3:
                                                document.getElementById('leasing').style.display = 'block';
                                                document.getElementById('leaComp').style.display = 'none';
                                                document.getElementById('leaComp2').style.display = 'none';
                                                document.getElementById('leaComp3').style.display = 'none';
                                                document.getElementById('fecha_compra').value = "1/1/1900";
                                                document.getElementById('inicio_garantia').value = "1/1/1900";
                                                document.getElementById('final_garantia').value = "1/1/1900";
                                                break;
                                                
                                        }
                                    }
                                    </script>
<%--       -----------> --%><%--      Los cambios que genera el botón leasing       --%> 
<%--      |             --%>
<%--      |             --%>         <%--      Numero de placa del activo       --%>
<%--      |             --%>  <div class="pure-control-group">
<%--      |             --%>        <label for="nplaca">Número de placa del activo</label>
<%--      |             --%>        <asp:TextBox ValidationGroup="one" runat="server" ID="numero_placa" data-placement="left" ToolTip="Este espacio debe proporcionar el número de placa del activo que desea consultar, este espacio es requerido." placeholder="ENF-1523" />
<%--      |             --%>      <%--      Numero de placa del activo       --%>
<%--      |             --%>  <br />
<%--      |             --%>  <label for="nserie">Número de serie del activo</label>
<%--      |             --%>        <asp:TextBox ValidationGroup="one" ID="numero_serie" runat="server" data-placement="left" ToolTip="Este espacio debe proporcionar el número de serie del activo, este espacio es requerido." placeholder="MUJ23HJCK987" />
<%--      |             --%>        <asp:CompareValidator ValidationGroup="one" ID="vPlacaYserie" runat="server" ControlToCompare="numero_serie" ControlToValidate="numero_placa" Operator="NotEqual" Type="String" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Los números de placa y serie no pueden ser iguales. Por favor ingrese números de placa y serie distintos."></asp:CompareValidator>
<%--      |             --%>        <asp:RequiredFieldValidator ValidationGroup="one" ID="RequiredFieldValidator1" runat="server" ControlToValidate="numero_placa" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>  </div>
<%--      |             --%>  
<%--      |             --%>
<%--      |             --%>  <div class="pure-control-group" id="leasing" style="display: none">
<%--      |             --%>        <div class="pure-control-group">
<%--      |             --%>  <%--      Fecha de adquisición       --%>
<%--      |             --%>        <label for="fechaEntrega">Fecha de adquisición</label>
<%--      |             --%>            <asp:TextBox runat="server" ID="fecha_adquisicion" ClientIDMode="Static" ToolTip="Este espacio debe contener la fecha en que el Colegio de Abogados y Abogadas de Costa Rica adquirió el activo, este espacio es requerido." > </asp:TextBox>
<%--      |             --%>            <cc1:CalendarExtender TargetControlID="fecha_adquisicion"  ID="calAdquisicion" runat="server"/>
<%--      |             --%>            <asp:RequiredFieldValidator ValidationGroup="one" ID="vFechaAdquisicion" runat="server" ControlToValidate="fecha_adquisicion" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>
<%--      |             --%>   </div>
<%--      |             --%>   <div class="pure-control-group">
<%--      |             --%>                                    
<%--      |             --%>     <%--     Fecha de Finalización      --%>
<%--      |             --%>     <label for="duracion_contrato">Finalización del Contrato</label>
<%--      |             --%>     <asp:TextBox runat="server" ID="finalizacion_contrato" ClientIDMode="Static" ToolTip="Este espacio debe contener la fecha en que finaliza el contrato para el activo, este espacio es requerido."> </asp:TextBox>
<%--      |             --%>     <cc1:CalendarExtender TargetControlID="finalizacion_contrato"  ID="finContrato" runat="server" />
<%--      |             --%>     <asp:RequiredFieldValidator ValidationGroup="one" ID="vFinalizacion" runat="server" ControlToValidate="finalizacion_contrato" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%> </div>
<%--       -----------> --%><%--      terminan las opciones del leasing       --%>

                                </div>
                                  
                               
                                <%--      Costo del activo       --%>
                                <div class="pure-control-group">
                                    <label for="precio">Costo en colones, del activo</label>
                                    <asp:TextBox ValidationGroup="one" ID="precio" ClientIDMode="Static" runat="server" TextMode="Number" data-placement="left" ToolTip="Este espacio debe proporcionar el valor total del activo, este espacio es requerido." placeholder="120360.17" />
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vPrecio" runat="server" ControlToValidate="precio" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </div>
                                <%--      fecha de compra       --%>
                                <div class="pure-control-group" id="leaComp" style="display: block">
                                    <label for="fechaCompra">Fecha de compra</label>
                                    <asp:TextBox runat="server" ID="fecha_compra" ClientIDMode="Static" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha de compra del activo, este espacio es requerido."> </asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="fecha_compra" ID="calCompra" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vFechaCompra" runat="server" ControlToValidate="fecha_compra" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                </div>
                                <%--      Inicio de la garantía       --%>
                                <fieldset class="pure-control-group" id="leaComp2" style="display: block">
                                    <label for="inicio">Fecha de Inicio de la garantía</label>
                                    <asp:TextBox runat="server" ID="inicio_garantia" ClientIDMode="Static" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que inicia la garantía, especificada por el proveedor, este espacio es requerido."></asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="inicio_garantia"  ID="calInicio" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vFechaInicio" runat="server" ControlToValidate="inicio_garantia" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                </fieldset>
                                <%--      Finalización de la garantía       --%>
                                <fieldset class="pure-control-group" id="leaComp3" style="display: block">
                                    <label for="finalizacion">Fecha de finalización de la garantía</label>
                                    <asp:TextBox runat="server" ID="final_garantia" ClientIDMode="Static" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que finaliza la garantía, especificada por el proveedor, este espacio es requerido."></asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="final_garantia"  ID="calFinal" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vFinal" runat="server" ControlToValidate="final_garantia" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                     </fieldset>

                                <%--      Descripción del activo       --%>
                                <fieldset class="pure-control-group">
                                    <label for="descripcion">Descripción del activo</label>
                                    <asp:DropDownList ValidationGroup="one" ID="descripcion" runat="server" data-toggle="tooltip" title="Para completar este espacio facilmente, preguntese a si mismo: ¿Que estoy ingresando? Ejemplo: Estoy ingresando una Laptop. En este espacio usted deberá colocar la palabra Laptop, este espacio es requerido. " class="pure-input-1-2">
                                        <asp:ListItem disabled="disabled" Selected="True">Elija una descripción</asp:ListItem>
                                        <asp:ListItem disabled="disabled" >¿La descripción no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalDescripcionAc"><span class="glyphicon glyphicon-wrench"></span></a>
                                     <asp:RequiredFieldValidator ValidationGroup="one" ID="vDescripción" runat="server" ControlToValidate="descripcion" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>

                                <%--      Sede regional o departamento       --%>
                                <fieldset class="pure-control-group">
                                    <label for="area">Departamento o Sede regional destinado(a)</label>
                                    <asp:DropDownList ValidationGroup="one" ID="area" runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar el área la cual está destinada el activo, es requerido. " class="pure-input-1-2">
                                        <asp:ListItem disabled="disabled" Selected="True">Elija un Área o Departamento</asp:ListItem>
                                        <asp:ListItem disabled="disabled" >¿La opción que busca no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vArea" runat="server" ControlToValidate="area" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>
                                <%--      Proveedor      --%>
                                <fieldset class="pure-control-group">
                                    <label for="provedor">Proveedor</label>
                                    <asp:DropDownList ValidationGroup="one" ID="proveedor" runat="server" data-toggle="tooltip" title="Proveedor: En este espacio debe proporcionar el nombre del proveedor del activo, este espacio es requerido." class="pure-input-1-2">
                                        <asp:ListItem  disabled="disabled" Selected="True">Elija un proveedor</asp:ListItem>
                                        <asp:ListItem disabled="disabled" >¿El proveedor no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalProveedor"><span class="glyphicon glyphicon-wrench"></span></a>
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vProveedor" runat="server" ControlToValidate="proveedor" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>

                                <%--      Especificaciones       --%>
                                    <fieldset class="pure-control-group">
                                        <label for="Tipo">Especificaciones técnicas</label>
                                        <asp:TextBox ValidationGroup="one" ID="especificacion_tecnica" runat="server" data-toggle="tooltip" title="En este espacio se debe proporcionar las cualidades del activo. Ejemplo: 1TB disco duro, 16GB RAM, 2GB AMD Radeon Fury (se pueden incluir otras caracteristicas que se deseen), este espacio es requerido" class="pure-input-1-2" placeholder="Especificaciones Técnicas" />
                                   <asp:RequiredFieldValidator ValidationGroup="one" ID="vEspecificacion" runat="server" ControlToValidate="especificacion_tecnica" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                         </fieldset>
                               
                                <div class="pure-controls">
                                    <asp:Button runat="server" CssClass="btn btn-success" ValidationGroup="one" OnClick="Bt_Ingresar_Click" ID="Button1" Text="Registrar Activo" />
                                </div>
                            </fieldset>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </cc1:TabPanel>

             <%-- Formulario 2 --%>

            <cc1:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de Activos</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_consultarAc">
                        <div class="tab-pane" id="Consultar">
                            <h1 style="text-align: center" id="titulo">Formulario de consultas</h1>
                            <div class="pure-form pure-form-aligned">
                                <asp:Panel ID="Panel3" runat="server" DefaultButton="">
                                <div class="pure-control-group">

                                    <label for="cedula">Número de placa del activo</label>
                                    <asp:TextBox runat="server" ID="cedula_buscar" data-toggle="tooltip" data-placement="left" title="Proporciona el número de placa o serie del activo que desees consultar." placeholder="#########" />

                                </div>

                                <div class="pure-control-group">
                                    <asp:Button runat="server" ID="btn_consultarAc" CssClass="btn btn-primary" OnClientClick="mostrar()" Text="Consultar"/>
                                </div>
                                </asp:Panel>
                                <script type="text/javascript">
                                    function mostrar() {
                                        document.getElementById('oculto').style.display = 'block';
                                    }

                                </script>
                            </div>


                            <div id="oculto" class="pure-form pure-form-aligned" style="display:none">
                                <!--Esto realmente es un form-->
                                <fieldset>
                                    <div class="pure-control-group" style="margin-top: 40px;">
                                        <p>

                                            <button class="btn btn-success" id="hab" onclick="habilitar();">Habilitar modificación</button>
                                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">Inhabilitar activo</button>
                                        </p>
                                        <div id="t" style="display: none">
                                            <h3>Formulario de modificación</h3>
                                        </div>
                                        <script>
                                            $(document).ready(function () {
                                                $("#hab").click(function () {
                                                    $('#t').show(2000, 'swing', function () {
                                                        //callback function after animation finished
                                                        $("hab").attr('value', 'Formulario de modificacion');
                                                    });
                                                });
                                            });
                                        </script>
                                    </div>

                                    <fieldset>
                                        <div class="pure-controls-group">
                                            <label for="Genero">Tipo de activo</label>          
                                                <label class="btn btn-primary disabled" id="rb1">
                                                    <asp:RadioButton runat="server" ID="options" autocomplete="off" />
                                                    Software
                                               
                                                </label>
                                                <label class="btn btn-primary" id="rb2">
                                                    <asp:RadioButton runat="server" ID="RadioButton1" autocomplete="off" />
                                                    Hardware
                                               
                                                </label>
                                            </div>
                                        
                                       
<%--       -----------> --%><%--      Los cambios que genera el botón leasing       --%> 
<%--      |             --%>     <%--      Numero de placa del activo       --%>                              
<%--      |             --%>         <div class="pure-control-group">
<%--      |             --%>             <label for="nplaca">Número de placa del activo</label>
<%--      |             --%>                 <asp:TextBox ValidationGroup="two" ReadOnly="true" runat="server" ID="numero_placa2" data-placement="left" ToolTip="Este espacio debe proporcionar el número de placa del activo que desea consultar, este espacio es requerido." placeholder="ENF-1523" />
<%--      |             --%>                      <asp:RequiredFieldValidator ValidationGroup="two" ID="vPlaca2" runat="server" ControlToValidate="numero_placa2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>         </div>
<%--      |             --%>         <div class="pure-control-group">
<%--      |             --%>             <label for="nserie">Número de serie del activo</label>
<%--      |             --%>                  <asp:TextBox ValidationGroup="two" ReadOnly="true" ID="numero_serie2" runat="server" data-placement="left" ToolTip="Este espacio debe proporcionar el número de serie del activo, este espacio es requerido." placeholder="MUJ23HJCK987" />
<%--      |             --%>                       <asp:RequiredFieldValidator ValidationGroup="two" ID="vSerie2" runat="server" ControlToValidate="numero_serie2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>         </div>
<%--      |             --%> 
<%--      |             --%>              <%--      Fecha de entrega      --%>
<%--      |             --%>         <div class="pure-control-group" style="display: none">
<%--      |             --%>              <div class="pure-control-group">
<%--      |             --%>                  <label for="fechaEntrega">Fecha de adquisición</label>
<%--      |             --%>                       <asp:TextBox runat="server" ID="fecha_entrega3" tooltip="En este espacio debe proporcionar la fecha en que el activo fue adquirido por el Colegio de Abogados y Abogadas de Costa Rica, este espacio es requerido"></asp:TextBox>
<%--      |             --%>                       <cc1:CalendarExtender TargetControlID="fecha_entrega3" ID="entrega2" runat="server" />
<%--      |             --%>                       <asp:RequiredFieldValidator ValidationGroup="two" ID="vEntrega" runat="server" ControlToValidate="fecha_entrega3" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>         </div>
<%--      |             --%>               <%--      Duración del Contrato       --%>
<%--      |             --%>         <div class="pure-control-group">
<%--      |             --%>              <label for="duracion_contrato">Duración del Contrato</label>
<%--      |             --%>                  <asp:TextBox runat="server" ID="finalizacion_contrato3" data-toggle="tooltip" title="Este espacio debe contener la fecha en que finaliza el contrato para el activo, este espacio es requerido."></asp:TextBox>
<%--      |             --%>                       <cc1:CalendarExtender TargetControlID="finalizacion_contrato3" ID="calFinalizacion" runat="server"/>
<%--      |             --%>                       <asp:RequiredFieldValidator ValidationGroup="two" ID="vDuracion" runat="server" ControlToValidate="finalizacion_contrato3" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
<%--      |             --%>         </div>
<%--       -----------> --%><%--      terminan las opciones del leasing       --%>

                                   
                                </div>
                                        
                               

                                        <%--      Precio       --%>
                                <div class="pure-control-group">
                                    <label for="precio">Costo en colones, del activo</label>
                                    <asp:TextBox ValidationGroup="two" ReadOnly="true" ID="precio2" runat="server" TextMode="Number" data-placement="left" ToolTip="Este espacio debe proporcionar el valor total del activo, este espacio es requerido." placeholder="120360.17" />
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vPrecio2" runat="server" ControlToValidate="precio2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </div>
                                        <%--      fecha de compra       --%>
                                <div class="pure-control-group">
                                    <label for="fechaCompra">Fecha de compra</label>
                                    <asp:TextBox runat="server" ID="fecha_compra3" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha de compra del activo, este espacio es requerido."></asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="fecha_compra3" ID="calCompra3" runat="server"/>
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vCompra" runat="server" ControlToValidate="fecha_compra3" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                </div>
                                        <%--     Inicio de la garantía      --%>
                                <fieldset class="pure-control-group">
                                    <label for="inicio">Fecha de Inicio de la garantía</label>
                                    <asp:TextBox runat="server" ID="inicio_garantia3" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que inicia la garantía, especificada por el proveedor, este espacio es requerido."></asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="inicio_garantia3" ID="calInicio3" runat="server"/>
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vInicio" runat="server" ControlToValidate="inicio_garantia3" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                </fieldset>
                                        <%--      Finalización de la garantía      --%>
                                <fieldset class="pure-control-group">
                                    <label for="finalizacion">Fecha de finalización de la garantía</label>
                                    <asp:TextBox runat="server" ID="final_garantia3" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que finaliza la garantía, especificada por el proveedor, este espacio es requerido."></asp:TextBox>
                                    <cc1:CalendarExtender TargetControlID="final_garantia3" ID="calFinal3" runat="server"/>
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vFinal2" runat="server" ControlToValidate="final_garantia3" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                
                                     </fieldset>
                                        <%--      Descripción del activo       --%>
                                <fieldset class="pure-control-group">
                                    <label for="descripcion">Descripción del activo</label>
                                    <asp:DropDownList ValidationGroup="two" ReadOnly="true"  ID="descripcion2" runat="server" tooltip="Para completar este espacio facilmente, preguntese a si mismo: ¿Que estoy ingresando? Ejemplo: Estoy ingresando una Laptop. En este espacio usted deberá colocar la palabra Laptop, este espacio es requerido. " class="pure-input-1-2">
                                        <asp:ListItem>Elija una descripción</asp:ListItem>
                                        <asp:ListItem>¿La descripción no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalDescripcionAc"><span class="glyphicon glyphicon-wrench"></span></a>
                                     <asp:RequiredFieldValidator ValidationGroup="two" ID="vDescripcion2" runat="server" ControlToValidate="descripcion2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>

                                        <%--     Area/Sede regional      --%>
                                <fieldset class="pure-control-group">
                                    <label for="area">Departamento o Sede regional destinado(a)</label>
                                    <asp:DropDownList ValidationGroup="two" ReadOnly="true" ID="area2" runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar el área la cual está destinada el activo, es requerido. " class="pure-input-1-2">
                                        <asp:ListItem>Elija un Área o Departamento</asp:ListItem>

                                        <asp:ListItem>¿La opción que busca no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vArea2" runat="server" ControlToValidate="area2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>
                                        <%--      Proveedor       --%>
                                <fieldset class="pure-control-group">
                                    <label for="provedor">Proveedor</label>
                                    <asp:DropDownList ValidationGroup="two" ReadOnly="true" ID="proveedor2" runat="server" data-toggle="tooltip" title="Proveedor: En este espacio debe proporcionar el nombre del proveedor del activo, este espacio es requerido." class="pure-input-1-2">
                                        <asp:ListItem>Elija un proveedor</asp:ListItem>
                                        <asp:ListItem>¿El proveedor no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                    </asp:DropDownList>
                                    <a data-toggle="modal" data-target="#modalProveedor"><span class="glyphicon glyphicon-wrench"></span></a>
                                    <asp:RequiredFieldValidator ValidationGroup="two" ID="vProveedor2" runat="server" ControlToValidate="proveedor2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>

                                <%--      Especificaciones Técnicas       --%>
                                    <fieldset class="pure-control-group">
                                        <label for="Tipo">Especificaciones técnicas</label>
                                        <asp:TextBox ValidationGroup="two" ReadOnly="true" ID="especificacion_tecnica2" runat="server" data-toggle="tooltip" title="En este espacio se debe proporcionar las cualidades del activo, este espacio es requerido" class="pure-input-1-2" placeholder="Especificaciones Técnicas" />
                                   <asp:RequiredFieldValidator ValidationGroup="two" ID="vEspecificacion2" runat="server" ControlToValidate="especificacion_tecnica2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                         </fieldset>
                                        </div>
                                        <div class="pure-controls">
                                            <button class="btn btn-success" id="enviar1" style="display: none">Realizar modificaciones</button>
                                            <div id="mensaje1" style="display: none; float: right">
                                                <h3>Las acciones han sido realizado con éxito.</h3>
                                            </div>
                                        </div>
                               
                            </div>
                            <script type="text/javascript">
                                function habilitar() {
                                    document.getElementById('nserie1').removeAttribute("readonly", false);
                                    document.getElementById('area1').removeAttribute("readonly", false);
                                    document.getElementById('fechaGarantia1').removeAttribute("readonly", false);
                                    document.getElementById('descripcion1').removeAttribute("readonly", false);
                                    document.getElementById('especificaciones1').removeAttribute("readonly", false);
                                    document.getElementById('prove1').removeAttribute("readonly", false);
                                    document.getElementById('enviar1').style.display = 'block';
                                    document.getElementById('rb1').className = "btn btn-primary";
                                    document.getElementById('rb2').className = "btn btn-primary active";
                                    document.getElementById('a').className = '';
                                    document.getElementById('p').className = '';
                                    document.getElementById('d').className = '';

                                }
                            </script>

                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $("#enviar1").click(function () {
                                        $('#mensaje1').show(2000, 'swing', function () {
                                            //callback function after animation finished
                                            $("enviar1").attr('value', 'Las acciones han sido realizadas correctamente');
                                        });
                                    });
                                });
                                $(document).ready(function () {
                                    $("#enviar2").click(function () {
                                        $('#mensaje1').show(2000, 'swing', function () {
                                            //callback function after animation finished
                                            $("enviar2").attr('value', 'Las acciones han sido realizadas correctamente');
                                        });
                                    });
                                });

                            </script>
        </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </cc1:TabPanel>

        </cc1:TabContainer>
        </div>
        </div>         
                        
        <div id="myTabContent" class="tab-content">                                 
                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                <span class="sr-only">Close</span>
                                            </button>
                                            <h4 class="modal-title">Motivos de inhabilitación</h4>
                                        </div>
                                        <div class="modal-body">
                                            <asp:TextBox runat="server" TextMode="MultiLine" />
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button runat="server" CssClass="btn btn-secondary" data-dismiss="modal" Text="Cerrar" />
                                            <asp:Button runat="server" CssClass="btn btn-danger" ID="enviar2" Text="Inhabilitar" />
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>

                      <%--               ----------------Modal Agregar Nueva Area--------------                                --%>   

                            <asp:Panel runat="server" DefaultButton="Registrar_Area" ID="panel5"> 
                                <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" style="text-align: center" id="NuevAarea">Nueva área de servicio</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="container">
                                                <div class="pure-form pure-form-aligned">
                                                    <fieldset class="pure-control-group">
                                                        <div class="input-prepend">
                                                            <label for="id_area">Identificador del área</label>
                                                            <asp:TextBox ValidationGroup="a" runat="server" ID="id_areas" placeholder="AR-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice el área o unidad que se esté registrando, es requerido. " />
                                                            <br />
                                                            <label for="area57">Área</label>
                                                            <asp:TextBox ValidationGroup="a" runat="server" ID="descripcion_area" type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, es requerido. " />
                                                        </div>
                                                    </fieldset>
                                                </div>
                                                <!-- /container -->
                                            </div>
                                            <div class="modal-footer">
                                                <div class="span">
                                                    <asp:Button runat="server" ValidationGroup="a" ID="Registrar_Area" CssClass="btn btn-success" OnClick="btn_Registrar_Area_Click" Text="Registrar área" />
                                                    <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                </div>
                                                <div class="span pull-left" style="margin-top: 20px;">
                                                    <div class="alert alert-success fade">
                                                        <button type="button" class="close" data-dismiss="alert">×</button>
                                                        <strong>¡Acciones completadas!</strong> Ahora puedes seleccionar esta categoria.
                                                   
                                                    </div>
                                                </div>
                                                <script>
                                                    $("#bt1").on("click", function () {
                                                        $(".alert").removeClass("in").show();
                                                        $(".alert").delay(500).addClass("in").fadeOut(2000);
                                                    });
                                                </script>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.modal -->
                            </div>
                            </asp:Panel>

                       <%--                            Modal Agregar Nueva Descripción                                --%>   
                        <asp:Panel runat="server" DefaultButton="Registar_Descripcion_Ac" ID="panel6"> 
                            <div class="modal fade" id="modalDescripcionAc" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" style="text-align: center" id="NuevaDescripcion">Nueva descripción Activo</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="container">
                                                <div class="pure-form pure-form-aligned">
                                                    <fieldset class="pure-control-group">
                                                        <div class="input-prepend">
                                                            <label for="id_descripcion_nueva">ID de descripción:</label>
                                                            <asp:TextBox runat="server" ValidationGroup="b" ID="id_descripcion_nueva" placeholder="D-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la descripción del activo que se desea registrar, es requerido. " />
                                                             <asp:RequiredFieldValidator ValidationGroup="b" ID="vDescId" runat="server" ControlToValidate="id_descripcion_nueva" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <br />
                                                            <div class="input-prepend">
                                                            <label for="ocupacion">Descripción</label>
                                                            <asp:TextBox runat="server" ValidationGroup="b" ID="descripcion_nueva" placeholder="Laptop" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la descripción del activo que se desea registrar, es requerido. " />
                                                            <asp:RequiredFieldValidator ValidationGroup="b" ID="vDesc" runat="server" ControlToValidate="descripcion_nueva" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                            </div>
                                                    </fieldset>
                                                </div>
                                                <!-- /container -->
                                            </div>
                                            <div class="modal-footer">
                                                <div class="span">
                                                    <asp:Button runat="server" ValidationGroup="b" ID="Registar_Descripcion_Ac" OnClick="btn_Registrar_Descripcion_Ac_Click" CssClass="btn btn-success" Text="Registrar descripción" />
                                                    <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                </div>
                                                <div class="span pull-left" style="margin-top: 20px;">
                                                    <div class="alert alert-success fade">
                                                        <button type="button" class="close" data-dismiss="alert">×</button>
                                                        <strong>¡Acciones completadas!</strong> Ahora puedes seleccionar esta categoria.
                                                    </div>
                                                </div>
                                                <script>
                                                    $("#btn_Registar").on("click", function () {
                                                        $(".alert").removeClass("in").show();
                                                        $(".alert").delay(500).addClass("in").fadeOut(2000);
                                                    });
                                                </script>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.modal -->
                            </div>
                                   
<%--                            <script>
                                function masOpciones() {
                                    var x = document.getElementById("descripcion_activo");
                                    var option = document.createElement("option");
                                    option.text = document.getElementById("Des").value;
                                    x.add(option);
                                }
                            </script>--%>
                        </asp:Panel>
                       <%--                            Modal Agregar Nuevo Proveedor                                --%>              
                        <asp:Panel runat="server" DefaultButton="Resgistrar_Proveedor" ID="panel7"> 
                            <div class="modal fade" id="modalProveedor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" style="text-align: center" id="Nuevoproveedor">Nuevo proveedor</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="container">
                                                <div class="pure-form pure-form-aligned">
                                                    <fieldset>
                                                        <div class="pure-control-group">
                                                            <label for="idP">Identificador</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="idp" placeholder="PR-000" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice el proveedor que se esté registrando, es requerido. " />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vIdp" runat="server" ControlToValidate="idp" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="nproveedor">Nombre del proveedor</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="nproveedor" placeholder="Dell" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre del proveedor que se esté registrando, es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vnproveedor" runat="server" ControlToValidate="nproveedor" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="correo">Correo electrónico</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" TextMode="Email" ID="correo" type="email" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la dirección de correo electrónico del proveedor a registrar, es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vcorreo" runat="server" ControlToValidate="correo" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de la empresa</label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="telefono1" type="number" placeholder="########" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal del proveedor a registrar, es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vtelefono1" runat="server" ControlToValidate="telefono1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de contacto </label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="telefono" type="number" placeholder="########" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal del contacto del proveedor, es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vtelefono" runat="server" ControlToValidate="telefono" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <div class="span">
                                                    <asp:Button runat="server" ValidationGroup="c" ID="Resgistrar_Proveedor" CssClass="btn btn-success" OnClick="btn_Registrar_Proveedor_Click" Text="Registrar proveedor" />
                                                    <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                </div>
                                                <div class="span pull-left" style="margin-top: 20px;">
                                                    <div class="alert alert-success fade">
                                                        <button type="button" class="close" data-dismiss="alert">×</button>
                                                        <strong>¡Acciones completadas!</strong> Ahora puedes seleccionar esta categoria.
                                               
                                                    </div>
                                                </div>
                                                <script>
                                                    $("#pv1").on("click", function () {
                                                        $(".alert").removeClass("in").show();
                                                        $(".alert").delay(500).addClass("in").fadeOut(2000);
                                                    });
                                            </script>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </asp:Panel>




                        </div>
        </div>

        
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
            function Guardar(y) {
                switch (y) {
                    case 1: { localStorage["Descripcion"] = document.getElementById("id_descripcion_nueva").value; break; }
                    case 2: { localStorage["Area"] = document.getElementById("id_area").value; break; }
                    case 3: { localStorage["Proveedor"] = document.getElementById("idP").value; break; }
                }
            }


            function Mostrar_Infoo(x) {
                switch (x) {
                    case 1: {
                        var option = document.createElement("option");
                        option.text = localStorage["Descripcion"].toString();
                        document.getElementById("descripcion").add(option);
                        Mostrar_Infoo(4);
                        break;
                    }
                    case 2: {
                        var option1 = document.createElement("option");
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
                    case 5: {
                        var option1 = document.createElement("option");
                        option1.text = localStorage["Area"];
                        document.getElementById("area1").add(option1); break;
                    }
                    case 6: {
                        var option = document.createElement("option");
                        option.text = localStorage["Proveedor"].toString();
                        document.getElementById("prove1").add(option); break;
                    }
                }

            }</script>
    </form>
</body>
</html>