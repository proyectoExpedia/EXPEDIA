<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionPrestamos.aspx.cs" Inherits="EXPEDIA.gestionPrestamos" %>

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
    <script src="js/jQueryUI/jquery-ui.min.js"></script>
    <link href="js/jQueryUI/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="js/jQueryUI/jquery-ui.min.css" rel="stylesheet" />
    <script src="js/sweetalert.min.js"></script>
    <link href="css/sweetalert.css" rel="stylesheet" />
</head>
<body>
       <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
           <asp:TabContainer ID="TabContainer2" runat="server"></asp:TabContainer>
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
   <%--     <asp:UpdatePanel runat="server">
            <ContentTemplate>--%>
            <div class="container">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Gestión de usuarios</h3>
                        <div>
                        <a style="float:right;margin-top:21px;" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0">
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de préstamo</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Bt_Ingresar">
                                    <div class="tab-pane fade in active" id="Ingresar">
                                        <h1 style="text-align: center">Formulario creación</h1>
                                        <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">

                                            <fieldset>

                                                <!--Ingresar Ocupacion-->
                                                <div class="pure-control-group">
                                                    <label for="Descripción">Descripción</label>
                                                    <asp:DropDownList ValidationGroup="one" runat="server" ID="descripcion" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a registrar, es requerido.">
                                                        <asp:ListItem Selected="True" Value="none" disabled="disabled">Elige una descripción. </asp:ListItem>
                                                    </asp:DropDownList>
                                              <asp:RequiredFieldValidator InitialValue="none" ControlToValidate="descripcion" ValidationGroup="one" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="<b>Debe elegir una opcion</b>"></asp:RequiredFieldValidator>
                                               <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Consultar" />
                                                     </div>

                                                 
                                                 <asp:GridView ID="tabla" runat="server" CssClass="table table-striped table-hover" OnRowDeleting="tabla_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField DeleteText="Agregar Activo" ControlStyle-CssClass="btn btn-primary" ShowDeleteButton="True">
                                                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                                </asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                            
                                                <!--Ingresar Cedula-->
                                                <div class="pure-control-group">
                                                    <label for="cedula">Número de cédula</label>
                                                    <asp:TextBox ValidationGroup="one" runat="server" ID="cedula_usuario" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." placeholder="#-####-####" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vCedula" runat="server" ControlToValidate="cedula_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <cc1:MaskedEditExtender ID="cedula_usuario_MaskedEditExtender" runat="server" BehaviorID="cedula_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_usuario"></cc1:MaskedEditExtender>
                                                    <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator2" runat="server" ControlToValidate="cedula_usuario" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                </div>
                                                <!--Ingresar Fecha_entrega-->
                                                <div class="pure-control-group">
                                                    <label for="contraseña">Contraseña</label>
                                                    <asp:TextBox TextMode="Date"  ValidationGroup="one" runat="server" ID="fecha_entreg" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. " />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vfecha_entreg" runat="server" ControlToValidate="fecha_entreg" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>

                                                <!--Ingresar Fecha_regreso-->
                                                <div class="pure-control-group">
                                                    <label for="fecha_regreso">Ingrese nuevamente la contraseña</label>
                                                    <asp:TextBox TextMode="Date" ValidationGroup="one" runat="server" ID="fecha_regres" data-toggle="tooltip" data-placement="left" title="En este espacio se debe corroborar la contraseña, es requerido. "  />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vfecha_regres" runat="server" ControlToValidate="fecha_regres" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                  
                                                </div>

                                                <asp:GridView ID="tabla1" runat="server" OnRowDeleting="tabla1_RowDeleting" CssClass="table table-striped table-hover">
                                                            <Columns>
                                                                <asp:CommandField DeleteText="Eliminar Activo" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True"></asp:CommandField>

                                                            </Columns>
                                                        </asp:GridView>
                                    


                                                <div class="pure-controls-group" style="margin-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success"  ValidationGroup="one" OnClick="Bt_Ingresar_Click" ID="Bt_Ingresar" Text="Registrar Usuario" />
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
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de préstamo</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="tab-pane" id="Consultar">
                                            <h1 style="text-align: center" id="titulo">Formulario de consultas</h1>
                                            <div class="pure-form pure-form-aligned">
                                            <asp:Panel ID="Panel3" runat="server">
                                                <label for="cedulaC">Número de cédula</label>
                                                <asp:TextBox ID="cedula_consulta" ValidationGroup="two" runat="server" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." placeholder="#-####-####"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="two" ID="RequiredFieldValidator2" runat="server" ControlToValidate="cedula_consulta" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ValidationGroup="two" ID="RegularExpressionValidator4" runat="server" ControlToValidate="cedula_consulta" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" BehaviorID="cedula_consulta_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_consulta"></cc1:MaskedEditExtender>
                                                <p>
                                                    <%--<asp:Button ID="Btn_consultar" ValidationGroup="two" Text="Consultar" CssClass="btn btn-primary" OnClick="Btn_consultar_Click" runat="server" />--%>
                                                </p
                                                     <label for="fechasalida">Número de Prestamo:</label>
                                    <asp:TextBox runat="server" data-toggle="tooltip" ToolTip="Proporcione el número de prestamo,a consultar" ID="id_prestamo" />
                                    <asp:Button runat="server" ID="Consulta_prestamo"   OnClick="Consulta_prestamo_Click" class="btn btn-success" Text="Consultar"></asp:Button>


                                <asp:GridView runat="server"  OnRowCommand="tabla2_RowCommand" ID="tabla2" CssClass="table" CellSpacing="0" Width="100">
                                    
                                    <Columns>
                                        <asp:TemplateField>
                                    <ItemTemplate><asp:ImageButton  ID="detalle" runat="server"  CssClass="glyphicon glyphicon-list-alt" CommandName="Detalle"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  /> </ItemTemplate> </asp:TemplateField>
                                          <asp:TemplateField>
                                    <ItemTemplate><asp:ImageButton  ID="al_dia" runat="server"  CssClass="glyphicon glyphicon-thumbs-up" CommandName="Al_día"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  /> </ItemTemplate> </asp:TemplateField>
                                          <asp:TemplateField>
                                    <ItemTemplate><asp:ImageButton  ID="finalizo" runat="server"  CssClass="glyphicon glyphicon-thumbs-down"  CommandName="Finalizo"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  /> </ItemTemplate> </asp:TemplateField>
                                      
                                            
                                    




                                    </Columns>

                                </asp:GridView>
                                            </asp:Panel>
                                        </div>  
                                            <div id="divOcultoConsulta" runat="server" class="pure-form pure-form-aligned" style="display:none">
                                                <div class="pure-control-group" style="margin-top: 40px;">
                                                    <p>
                                                        <%--<asp:Button runat="server"  Text="Habilitar modificación" CssClass="btn btn-success" ClientIDMode="Static"  ID="Btn_habilitar" OnClientClick="habilitar()"--%> OnClick="Btn_habilitar_Click" />
                                                        <input type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalInhabilitar" value="Inhabilitar usuario" />
                                                        <%--<asp:Button runat="server" ID="inhabilitar" CssClass="btn btn-danger" data-toggle="modal" data-target="#myModal" Text="Inhabilitar usuario"></asp:Button>--%>
                                                    </p>
                                                    <div id="notificacionDatosConsulta" style="display: none">
                                                        <h3>Formulario de modificación</h3>
                                                    </div>
                                                </div>
                                                <div>
                                                    <fieldset>
                                                       <%-- DefaultButton="Btn_actualizar"--%>
                                                        <asp:Panel ID="Panel4" runat="server" >
                                                           <%-- <!--Consulta nombre-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Nombre</label>
                                                                <asp:TextBox runat="server" ValidationGroup="three" ID="nombre_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="nombre_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Apellido1-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Primer Apellido</label>
                                                                <asp:TextBox runat="server" ValidationGroup="three"  ID="apellido_actualizar1" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="apellido_actualizar1" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Apellido2-->
                                                            <div class="pure-control-group">
                                                                <label for="nombre1">Segundo Apellido</label>
                                                                <asp:TextBox runat="server" ValidationGroup="three"  ID="apellido_actualizar2" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido." />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="apellido_actualizar2" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Consulta Contraseña-->
                                                            <div class="pure-control-group">
                                                                <label for="contraseña1">Contraseña</label>
                                                                <asp:TextBox runat="server" ValidationGroup="three"  ID="contrasena_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. "  />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="contrasena_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <!--Ingresar ReContraseña-->
                                                            <div class="pure-control-group">
                                                                    <label for="contraseña">Ingrese nuevamente la contraseña</label>
                                                                    <asp:TextBox ValidationGroup="three" runat="server" ID="rcontrasena_actualizar" data-toggle="tooltip" data-placement="left" title="En este espacio se debe corroborar la contraseña, es requerido. " TextMode="Password" />
                                                                    <asp:RequiredFieldValidator ValidationGroup="three" ID="RequiredFieldValidator8" runat="server" ControlToValidate="rcontrasena_actualizar" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CompareValidator2" ValidationGroup="three" ForeColor="Red"  runat="server" ControlToValidate="contrasena_actualizar" ControlToCompare="rcontrasena_actualizar" ErrorMessage="<b>Las contraseñas no coinciden</b>"></asp:CompareValidator>                                                            
                                                            </div>
                                                            <!--Consulta Correo Electronico-->
                                                            <div class="pure-control-group">
                                                                <label for="correo1">Correo electrónico</label>
                                                                <asp:TextBox ID="correo_actualizar" ValidationGroup="three"  runat="server" data-toggle="tooltip" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a modificar, es requerido. " TextMode="Email" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="correo_actualizar" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ValidationGroup="three" ID="RegularExpressionValidator16" runat="server" ControlToValidate="correo_actualizar" ErrorMessage="&lt;b&gt;  Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                                                            </div>
                                                            <!--Consulta Numero telefonico-->
                                                            <fieldset class="pure-control-group">
                                                                <label for="telefono1">Número telefónico</label>
                                                                <span class="add-on btn btn-default">506</span>
                                                                <asp:TextBox runat="server" ValidationGroup="three"  ID="telefono_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar el número telefónico principal de la persona a modificar, es requerido."  placeholder="####-####" min="11111111" max="99999999" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="<b>*</b>" ValidationGroup="three" ControlToValidate="telefono_actualizar" ForeColor="Red"></asp:RequiredFieldValidator> 
                                                                <asp:RegularExpressionValidator ValidationGroup="three" ID="RegularExpressionValidator18" runat="server" ControlToValidate="telefono_actualizar" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" BehaviorID="telefono_actualizar_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999-9999" TargetControlID="telefono_actualizar"></cc1:MaskedEditExtender>
                                                            </fieldset>
                                                            <!--Consulta Ocupacion-->
                                                            <div class="pure-control-group">
                                                                <label for="puesto1">Ocupación</label>
                                                                <asp:DropDownList runat="server" ValidationGroup="three" ID="puesto_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a modificar, es requerido.">
                                                                    <asp:ListItem Selected="False" disabled="disabled">¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <a runat="server" id="llavePuestos" data-toggle="modal" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                                            </div>
                                                            <!--Consulta Area-->
                                                            <div class="pure-control-group">
                                                                <label for="area1">Área de servicio</label>
                                                                <asp:DropDownList ValidationGroup="three"  runat="server" ID="area_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a modificar, es requerido.">
                                                                    <asp:ListItem Selected="False" disabled="disabled">¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <a runat="server" id="llaveAreas" data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                                            </div>
                                                            <!--Consulta Tipo de Usuario-->
                                                            <div class="pure-control-group">
                                                                <label for="tipo1">Usuario</label>
                                                                <asp:DropDownList ValidationGroup="three"  runat="server" ID="tipo_actualizar" CssClass="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe representar el rol de la persona a modificar en el sistema." disable>
                                                                    <asp:ListItem Value="0">Consultas</asp:ListItem>
                                                                    <asp:ListItem Value="1">Administrador</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                 --%>
                                                           <!--Consulta Accion Guardar Modificaciones-->
                                                            <p style="margin-top: 30px;">
                                                                <%--<asp:Button runat="server" ValidationGroup="three"  CssClass="btn btn-success" ID="Btn_actualizar" OnClick="Bt_actualizar_Click" Style="display: block; float: left" Text="Realizar modificaciones" />--%>
                                                            </p>
                                                            
                                                    </asp:Panel>
                                                </fieldset>
                                            </div>
                                        </div>  
                                     
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>
                </div>
                <div id="Modales">
                   <%-- DefaultButton="Btn_ocupacion"--%>
                    <asp:Panel ID="Panel5" runat="server" >
                                    <div class="modal fade" id="modalPuesto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                    <div class="modal-header">
                                        
                                       
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                                <img src="img/colegioAbogadoscr.png" style="width:90px; height:90px;float:left" alt="" />
                                                <br />
                                                <label for="Fecha" style="font-size:20px; margin-right:148px; margin-left:75px;">COLEGIO DE ABOGADOS Y ABOGADAS DE COSTA RICA</label> Fecha:<asp:TextBox runat="server" ID="TextBox3" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White" />
                                                <label for="Numero" style="font-size:20px; margin-right:150px; margin-left:25px;">SOLICITUD DE TRASLADO,PRESTAMO,EXCLUSIÓN DE ACTIVO FIJO N°</label><asp:TextBox runat="server" ID="TextBox2" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White" />
                                                <br />
                                                <br />
                                                <br />
                                                <fieldset class="pure-control-group" style="border:none">
                                                    <div class="col-md-10 column">
                                                    <table class="table table-bordered" id="tab_logic_bordered">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <label for="check_traslado" style="font-size:18px; margin-right:152px;">1.SOLICITUD DE TRASLADO (cuando es en forma permanente a otro departamento)</label>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox runat="server" ID="check_traslado" readonly = 'true' />
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td>
                                                                   <label for="check_exclusion" style="font-size:18px; margin-right:250px;">2.SOLICITUD DE EXCLUSIÓN(cuando va a dejarse de usar por el colegio)</label> 
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox runat="server" ID="check_exclusion"  readonly = 'true'/>
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   <label for="check_prestamo" style="font-size:18px; margin-right:370px;">3.SOLICITUD DE PRESTAMO (cuando es en forma temporal)</label> 
                                                                </td>
                                                                <td>
                                                                   <asp:CheckBox runat="server" ID="check_prestamo" readonly = 'true' Checked="true"  />
                                                               </td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </div>
                                                </fieldset>
                                                <label for="idSolicitante">Identificación de solicitante:</label><asp:TextBox runat="server" ID="TextBox1" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"  /><br />
                                                <label for="fechaentrada">Fecha de conclusión:</label><asp:TextBox runat="server" ID="fecha_conclucion" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White" /><br />
                                                <div class="col-md-6 column">
                                                    <asp:GridView runat="server" CssClass="table table-bordered table-hover" id="tab_logic_hover" EnableSortingAndPagingCallbacks="True">
                                                        
                                                    </asp:GridView>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />

                                                <pre style="border:none; background:none">_________________________________________                     __________________________________________ 
 NOMBRE DEL DEPARTAMENTO QUE ENTREGA Y                NOMBRE DEL DEPARTAMENTO QUE RECIBE Y 
       FIRMA DEL RESPONSABLE                                                  FIRMA DEL RESPONSABLE</pre>
                                                <pre style="background:none; width:85%;">Observaciones: (indicar si se entrega con otros componentes,motivo de préstamo,traslado o exclisión y
condiciones fisicas - en caso de préstamo o traslado)



</pre>

                                                <pre style="border:none; background:none"> Visto bueno:  ___________________________________                    ___________________________________
                                 Jefe de Departamento                                                         Dirección Ejecutiva</pre>


                                            </div>
                                    </div>
                                           


                                        </div>
                                </div>
                            </div>
                  </asp:Panel>

                    <asp:Panel ID="Panel6" runat="server" >
<%--                        <div class="modal fade" id="modalInhabilitar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                        <asp:TextBox ValidationGroup="five" id="TextArea1" TextMode="multiline" Columns="75" Rows="10" runat="server"/>
                                        <asp:RequiredFieldValidator ValidationGroup="five" ID="RequiredFieldValidator5" ControlToValidate="TextArea1" runat="server" ForeColor="Red" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <asp:Button runat="server" Text="Inhabilitar"  CssClass="btn btn-danger" ID="Btn_inhabilitar" ValidationGroup="five" OnClick="Btn_inhabilitar_Click" />
                                    </div>
                                </div>
                            </div>
                    </div>--%> 
                    </asp:Panel> 
                    <asp:Panel ID="Panel7" runat="server" >
<%--                         <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                                        <asp:TextBox runat="server" ValidationGroup="Six"  ID="idareas"   placeholder="AR-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificado que caracterice el área o unidad que se esté registrando, es requerido. " />
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator6" runat="server"  ForeColor="Red" ControlToValidate="idareas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area">Área</label>
                                                        <asp:TextBox runat="server" id="areas" ValidationGroup="Six" type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, es requerido. " />
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator7" runat="server"  ForeColor="Red" ControlToValidate="areas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
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
                         </div>--%>
                    </asp:Panel>
                </div>
            </div>
  <%--          </ContentTemplate>
        </asp:UpdatePanel>--%>


           <!----------JAVA SCRIPTS--------->
           <script  type="text/jscript">
function imprimePanel() {
var printContent = document.getElementById("<%=Panel5.ClientID%>");
       var windowUrl = 'about:blank';
      
       var windowName = 'Comprobante de solicitud de préstamo' ;
       var printWindow = window.open(windowUrl, windowName, 'width=745.628,height=692.105,top=0,left=0');
 
       printWindow.document.write(printContent.innerHTML);
       printWindow.document.close();
       printWindow.focus();
       printWindow.print();
       printWindow.close();
}
 
</script>


    </form>
</body>
</html>