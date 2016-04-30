<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionUsuarios.aspx.cs" Inherits="EXPEDIA.gestionUsuarios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



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
    <script src="js/sweetalert.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
</head>
<body>
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
                            <li><a href="#tab2primary" data-toggle="tab">Conózcanos</a></li>
                            <li><a href="#tab3primary" data-toggle="tab">Contacto</a></li>
                        </ul>
                    </div>
                </div>
                <!-----------------------------------------------Fin de las opciones----------------------------------------------->
            </div>
        </nav>
<%--        <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
            <div class="container">
                <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Gestión de Usuarios</h3>
                        <div>
                        <a style="float:right;margin-top:21px;" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                        </div>
                    </div>
                  
                    <div class="panel-body">
                        <asp:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0">
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de Usuarios</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Bt_Ingresar">
                                    <div class="tab-pane fade in active" id="Ingresar">
                                        <h1 style="text-align: center">Formulario de Registro</h1>
                                        <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">

                                            <fieldset>
                                                <!--Ingresar nombre-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Nombre</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="nombre_usuario" data-toggle="tooltip" data-placement="right" title="Este espacio debe proporcionar el nombre de la persona a registrar, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vNombre" runat="server" ControlToValidate="nombre_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar apellido 1-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Primer Apellido</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="apellido_usuario1" data-toggle="tooltip" data-placement="right" ToolTip="Este espacio debe proporcionar el primer apellido de la persona a registrar, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vApellido1" runat="server" ControlToValidate="apellido_usuario1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar apellido 2-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Segundo Apellido</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="apellido_usuario2" data-placement="right"   data-toggle="tooltip" title="Este espacio debe proporcionar el segundo apellido de la persona a registrar, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vApellido2" runat="server" ControlToValidate="apellido_usuario2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar Cedula-->
                                                <div class="pure-control-group">
                                                    <label for="cedula">Número de cédula</label>
                                                    <asp:TextBox ValidationGroup="one" runat="server" ID="cedula_usuario" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones, no excluya ningún dígito, este espacio es requerido." placeholder="#-####-####" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vCedula" runat="server" ControlToValidate="cedula_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <cc1:MaskedEditExtender ID="cedula_usuario_MaskedEditExtender" runat="server" BehaviorID="cedula_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_usuario"></cc1:MaskedEditExtender>
                                                    <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator2" runat="server" ControlToValidate="cedula_usuario" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                </div>
                                                <!--Ingresar Contraseña-->
                                                <div class="pure-control-group">
                                                    <label for="contraseña">Contraseña</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="50" runat="server" ID="contrasena_usuario" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, este espacio es requerido." TextMode="Password" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vContraseña" runat="server" ControlToValidate="contrasena_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>

                                                <!--Ingresar ReContraseña-->
                                                <div class="pure-control-group">
                                                    <label for="contraseña">Ingrese nuevamente la contraseña</label>
                                                    <asp:TextBox ValidationGroup="one" runat="server" MaxLength="50" ID="reContraseña" data-toggle="tooltip" data-placement="right" title="En este espacio se debe corroborar la contraseña, este espacio es requerido." TextMode="Password" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vRContraseña" runat="server" ControlToValidate="reContraseña" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" ValidationGroup="one" ForeColor="Red"  runat="server" ControlToValidate="contrasena_usuario" ControlToCompare="reContraseña" ErrorMessage="<b>Las contraseñas no coinciden</b>"></asp:CompareValidator>
                                                </div>

                                                <!--Ingresar Correo Electronico-->
                                                <div class="pure-control-group">
                                                    <label for="correo">Correo electrónico</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="70" runat="server" ID="correo_usuario" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a registrar, este espacio es requerido." TextMode="Email" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vCorreo" runat="server" ControlToValidate="correo_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator1" runat="server" ControlToValidate="correo_usuario" ErrorMessage="&lt;b&gt;  Formato no válido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                                                    
                                                </div>

                                                <!--Ingresar Telefono-->
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="telefono">Número telefónico</label>
                                                        <span class="add-on btn btn-default">506</span>
                                                        <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="telefono_usuario" placeholder="####-####" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número telefónico principal de la persona a registrar, este espacio es requerido." />
                                                        <cc1:MaskedEditExtender ID="telefono_usuario_MaskedEditExtender" runat="server" BehaviorID="telefono_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999-9999" TargetControlID="telefono_usuario"></cc1:MaskedEditExtender>
                                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="vTelefono" runat="server" ControlToValidate="telefono_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator3" runat="server" ControlToValidate="telefono_usuario" ErrorMessage="&lt;b&gt;Formato no válido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </fieldset>

                                                <!--Ingresar Ocupacion-->
                                                <div class="pure-control-group">
                                                    <label for="puesto">Ocupación</label>
                                                    <asp:DropDownList ValidationGroup="one" runat="server" ID="puesto" class="pure-input-1-2" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a registrar, este espacio es requerido.">
                                                        <asp:ListItem Selected="True" Value="none" disabled="disabled"> ¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva. </asp:ListItem>
                                                    </asp:DropDownList>
                                                    <a data-toggle="modal" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                                    <asp:RequiredFieldValidator InitialValue="none" ControlToValidate="puesto" ValidationGroup="one" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="<b>Debe elegir una opción</b>"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar Area de servicio-->
                                                <div class="pure-control-group">
                                                    <label for="area">Área de servicio</label>
                                                    <asp:DropDownList runat="server" ID="area" class="pure-input-1-2" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a registrar, este espacio es requerido.">
                                                        <asp:ListItem Selected="True" Value="none" disabled="disabled">¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                                    <asp:RequiredFieldValidator InitialValue="none" ControlToValidate="area" ValidationGroup="one" ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="<b>Debe elegir una opción</b>"></asp:RequiredFieldValidator>
                                                </div>

                                                <!--Ingresar tipo de Usuario-->
                                                <div class="pure-control-group">
                                                    <label for="tipo_usuario">Usuario</label>
                                                    <asp:DropDownList runat="server" ID="tipo_usuario" class="pure-input-1-2" data-toggle="tooltip" data-placement="right" title="En este espacio se debe representar el rol de la persona a registrar en el sistema, este espacio es requerido.">
                                                        <asp:ListItem Selected="True" Value="none" disabled="disabled">Seleccione una opción</asp:ListItem>
                                                        <asp:ListItem Value="1">Administrador</asp:ListItem>
                                                        <asp:ListItem Value="0">Consultas</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="none" ControlToValidate="tipo_usuario" ValidationGroup="one" ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="<b>Debe elegir una opción</b>"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="pure-controls-group" style="margin-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success" ValidationGroup="one" OnClick="Bt_Ingresar_Click" ID="Bt_Ingresar" Text="Registrar Usuario" />
                                                    <div id="mensaje" style="display: none">
                                                        <h3>Las acciones han sido realizadas con éxito.</h3>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </asp:Panel>
                                </ContentTemplate>
                             </asp:TabPanel>

                                            <!-----------------------------------------------Formulario Consultas----------------------------------------------->

                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de usuarios</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="tab-pane" id="Consultar">
                                            <h1 style="text-align: center" id="titulo">Formulario de consultas</h1>
                                            <div class="pure-form pure-form-aligned">
                                            <asp:Panel ID="Panel3" runat="server" DefaultButton="">
                                                <label for="cedulaC">Número de cédula</label>
                                                <asp:TextBox ID="cedula_consulta" ValidationGroup="two" runat="server" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, este espacio es requerido." placeholder="#-####-####"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="two" ID="RequiredFieldValidator2" runat="server" ControlToValidate="cedula_consulta" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ValidationGroup="two" ID="RegularExpressionValidator4" runat="server" ControlToValidate="cedula_consulta" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" BehaviorID="cedula_consulta_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_consulta"></cc1:MaskedEditExtender>
                                                <p>
                                                    <asp:Button ID="Btn_consultar" ValidationGroup="two" Text="Consultar" CssClass="btn btn-primary" OnClick="Btn_consultar_Click" runat="server" />
                                                </p
                                            </asp:Panel>
                                            </div>  
                                            <div id="divOcultoConsulta" runat="server" class="pure-form pure-form-aligned" style="display:none">
                                                <div class="pure-control-group" style="margin-top: 40px;">
                                                    <div runat="server" id="controles">
                                                    <p>

                       <!-----------------------------------------------Modificación de usuarios----------------------------------------------->

                                                        <asp:Button runat="server"  Text="Habilitar modificación" CssClass="btn btn-success" ClientIDMode="Static"  ID="Btn_habilitar" OnClientClick="habilitar()" OnClick="Btn_habilitar_Click" />
                                                        <input type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalInhabilitar" value="Inhabilitar usuario" />
                                                        <%--<asp:Button runat="server" ID="inhabilitar" CssClass="btn btn-danger" data-toggle="modal" data-target="#myModal" Text="Inhabilitar usuario"></asp:Button>--%>
                                                    </p>
                                                    </div>
                                                    <div id="notificacionDatosConsulta" style="display: none">
                                                        <h3>Formulario de modificación</h3>
                                                    </div>
                                                </div>
                                                <div>
                                                    <fieldset>
                                                        <asp:Panel ID="Panel4" runat="server" DefaultButton="Btn_actualizar">
                                                            <!--Consulta nombre-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Nombre</label>
                                                                <asp:TextBox runat="server" MaxLength="20" ValidationGroup="three" ID="nombre_actualizar" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el nombre de la persona a modificar, este espacio es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="nombre_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Apellido1-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Primer Apellido</label>
                                                                <asp:TextBox runat="server" MaxLength="20" ValidationGroup="three"  ID="apellido_actualizar1" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el primer apellido de la persona a modificar, este espacio es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="apellido_actualizar1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Apellido2-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Segundo Apellido</label>
                                                                <asp:TextBox runat="server" MaxLength="20" ValidationGroup="three"  ID="apellido_actualizar2" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el segundo apellido de la persona a modificar, este espacio es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="apellido_actualizar2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Contraseña-->
                                                            <div class="pure-control-group">
                                                                <label for="contraseña1">Contraseña</label>
                                                                <asp:TextBox runat="server" MaxLength="50" ValidationGroup="three"  ID="contrasena_actualizar" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, este espacio es requerido."  />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="contrasena_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Ingresar ReContraseña-->
                                                            <div class="pure-control-group">
                                                                    <label for="contraseña">Ingrese nuevamente la contraseña</label>
                                                                    <asp:TextBox ValidationGroup="three" MaxLength="50" runat="server" ID="rcontrasena_actualizar" data-toggle="tooltip" data-placement="right" title="Por Favor, escriba nuevamente la contraseña, este espacio es requerido." TextMode="Password" />
                                                                    <asp:RequiredFieldValidator ValidationGroup="three" ID="RequiredFieldValidator8" runat="server" ControlToValidate="rcontrasena_actualizar" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CompareValidator2" ValidationGroup="three" ForeColor="Red"  runat="server" ControlToValidate="contrasena_actualizar" ControlToCompare="rcontrasena_actualizar" ErrorMessage="<b>Las contraseñas no coinciden</b>"></asp:CompareValidator>                                                            
                                                            </div>
                                                            <!--Consulta Correo Electronico-->
                                                            <div class="pure-control-group">
                                                                <label for="correo1">Correo electrónico</label>
                                                                <asp:TextBox ID="correo_actualizar" MaxLength="70" ValidationGroup="three"  runat="server" data-toggle="tooltip" data-placement="right"  title="En este espacio se debe proporcionar la nueva dirección de correo electrónico de la persona a modificar, es requerido. " TextMode="Email" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="correo_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ValidationGroup="three" ID="RegularExpressionValidator16" runat="server" ControlToValidate="correo_actualizar" ErrorMessage="&lt;b&gt;  Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                                                            </div>
                                                            <!--Consulta Numero telefonico-->
                                                            <fieldset class="pure-control-group">
                                                                <label for="telefono1">Número telefónico</label>
                                                                <span class="add-on btn btn-default">506</span>
                                                                <asp:TextBox runat="server" MaxLength="20" ValidationGroup="three"  ID="telefono_actualizar" data-toggle="tooltip" data-placement="right"  title="En este espacio se debe proporcionar el nuevo número telefónico principal de la persona a modificar, este espacio es requerido."  placeholder="####-####" min="11111111" max="99999999" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="telefono_actualizar" ForeColor="Red"></asp:RequiredFieldValidator> 
                                                                <asp:RegularExpressionValidator ValidationGroup="three" ID="RegularExpressionValidator18" runat="server" ControlToValidate="telefono_actualizar" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" BehaviorID="telefono_actualizar_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999-9999" TargetControlID="telefono_actualizar"></cc1:MaskedEditExtender>
                                                            </fieldset>
                                                            <!--Consulta Ocupacion-->
                                                            <div class="pure-control-group">
                                                                <label for="puesto1">Ocupación</label>
                                                                <asp:DropDownList runat="server" ValidationGroup="three" ID="puesto_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" data-placement="right"  title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a modificar, este espacio es requerido.">
                                                                    <asp:ListItem Selected="False" disabled="disabled">¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a runat="server" id="llavePuestos" data-toggle="modal" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                                            </div>
                                                            <!--Consulta Area-->
                                                            <div class="pure-control-group">
                                                                <label for="area1">Área de servicio</label>
                                                                <asp:DropDownList ValidationGroup="three"  runat="server" ID="area_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" data-placement="right"  title="En este espacio se debe proporcionar el área o sede regional, donde labora la persona a modificar, este espacio es requerido.">
                                                                    <asp:ListItem Selected="False" disabled="disabled">¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <a runat="server" id="llaveAreas" data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                                            </div>
                                                            <!--Consulta Tipo de Usuario-->
                                                            <div class="pure-control-group">
                                                                <label for="tipo1">Usuario</label>
                                                                <asp:DropDownList ValidationGroup="three"  runat="server" ID="tipo_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" data-placement="right"  title="En este espacio se debe representar el rol de la persona a modificar en el sistema,  este espacio es requerido." disable>
                                                                    <asp:ListItem Value="0">Consultas</asp:ListItem>
                                                                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <asp:RequiredFieldValidator InitialValue="none" ControlToValidate="tipo_actualizar" ValidationGroup="three" ForeColor="Red" ID="vTipoUsuario" runat="server" ErrorMessage="<b>Debe elegir una opcion</b>"></asp:RequiredFieldValidator>
                                                            </div>
                 
                                                           <!--Consulta Accion Guardar Modificaciones-->
                                                            <p style="margin-top: 30px;">
                                                                <asp:Button runat="server" ValidationGroup="three"  CssClass="btn btn-success" ID="Btn_actualizar" OnClick="Bt_actualizar_Click" Style="display: block; float: left" Text="Realizar modificaciones" />
                                                            </p>
                                                            
                                                    </asp:Panel>
                                                </fieldset>
                                            </div>
                                        </div>  
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>
                </div>
                <div id="Modales">
                    <asp:Panel ID="Panel5" runat="server" DefaultButton="Btn_ocupacion">
                                    <div class="modal fade" id="modalPuesto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel1">Nueva ocupación</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="idocupacion">Identificador de la ocupación</label>
                                                        <asp:TextBox runat="server" MaxLength="20" ID="idocupacion" ValidationGroup="four" placeholder="OC-001" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un identificador que caracterice la ocupación que se esté registrando, este espacio es requerido."/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" ForeColor="Red" ControlToValidate="idocupacion" ValidationGroup="four" runat="server" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>   
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="ocupacion">Ocupación</label>
                                                        <asp:TextBox runat="server" ID="ocupacion"  MaxLength="500" ValidationGroup="four" placeholder="Programador" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el nombre de la ocupación que se desea registrar, este espacio es requerido."/>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" ForeColor="Red" ControlToValidate="ocupacion" ValidationGroup="four" runat="server" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>                                                                                                              
                                                    </div>
                                                </fieldset>
                                        </div> <!-- /container -->
                                    </div>
                                    <div class="modal-footer">
                                        <div class="span">
                                            <asp:Button ValidationGroup="four" runat="server" CssClass="btn btn-success" OnClick="Btn_ocupacion_Click" ID="Btn_ocupacion" Text="Registrar Ocupacion"/>
                                            <button  class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                   </div> 
                  </asp:Panel>
                    <asp:Panel ID="Panel6" runat="server" DefaultButton="Btn_inhabilitar">
                        <div class="modal fade" id="modalInv" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                        <asp:TextBox ValidationGroup="five" id="TextArea1" TextMode="multiline" MaxLength="500" Columns="75" Rows="10" runat="server"/>
                                        <asp:RequiredFieldValidator ValidationGroup="five" ID="RequiredFieldValidator5" ControlToValidate="TextArea1" runat="server" ForeColor="Red" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <asp:Button runat="server" Text="Inhabilitar"  CssClass="btn btn-danger" ID="Btn_inhabilitar" ValidationGroup="five" OnClick="Btn_inhabilitar_Click" />
                                   </div>
                                </div>
                            </div>
                    </div> 
                    </asp:Panel> 
                    <asp:Panel ID="Panel7" runat="server" DefaultButton="Btn_areas">
                         <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Nueva área de servicio</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="idarea">Identificador del área</label>
                                                        <asp:TextBox runat="server" MaxLength="20" ValidationGroup="Six"  ID="idareas"   placeholder="AR-001" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un identificado que caracterice el área o unidad que se esté registrando, este espacio es requerido." />
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator6" runat="server"  ForeColor="Red" ControlToValidate="idareas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area">Área</label>
                                                        <asp:TextBox runat="server" MaxLength="20" id="areas" ValidationGroup="Six" type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, este espacio es requerido." />
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" MaxLength="500" ID="RequiredFieldValidator7" runat="server"  ForeColor="Red" ControlToValidate="areas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ValidationGroup="Six" CssClass="btn btn-success" OnClick="Btn_areas_Click" ID="Btn_areas" Text="Registrar área" />
                                                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>
                    </asp:Panel>
                </div>
            </div>
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>

      <% if (Session["Inhabilitado"]!="") {
             string[] separadores = {"*"};
             string[] final = Session["Inhabilitado"].ToString().Split(separadores, StringSplitOptions.RemoveEmptyEntries);
             %>
            <div class="modal fade" id="exampleModa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h1 class="modal-title" style="text-align:center" id="exampleModalLabe">Usuario Inhabilitado</h1>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                               El usuario <b><%=final[0] %></b> que deseas consultar se encuentra inhabilitado en el sistema.
                                <br />
                                <a href="#" title="Motivos de inhabilitacion: " data-toggle="popover" data-trigger="focus" data-content="<%= final[1] %>"><b>Detalle <span style='margin: 5px'  class='glyphicon glyphicon-paperclip'></span></b></a>          
                                    <script>
                                    $(document).ready(function () {
                                        $('[data-toggle="popover"]').popover();
                                    });
                                    </script>
                                <br />
                                <h3>¿Deseas habilitar denuevo el usuario?</h3>
                                </div>
                            </div> <!-- /container -->
                            <script type="text/javascript">
                                $(window).load(function () {
                                    $('[data-toggle="tooltip"]').tooltip();
                                    $('#exampleModa').modal('show');
                                });
                            </script>
                       
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
                            <asp:Button runat="server" ID="btn_habilitarUsuario" Text="Si" CssClass="btn btn-danger" OnClick="btn_habilitarUsuario_Click"/>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
              
      <% } %>

     <script type="text/javascript">
         $(document).ready(function () {
             $('[data-toggle="tooltip"]').tooltip();
         });
     </script>
    </form>

</body>
</html>
