

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionDonaciones.aspx.cs" Inherits="EXPEDIA.GestionDonaciones" Culture="Auto" UICulture="Auto" %>

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
           <asp:ScriptManager ID="ScriptManager2" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
          
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
                <div style="margin-top:50px;"><asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath></div>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Gestión de donaciones</h3>
                        <div>
                        <a style="float:right;margin-top:21px;" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0">
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de donación</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                                <HeaderTemplate>
                                    <span data-toggle="tab" style="margin: 5px"><b>Registro de donación</b><span class="glyphicon glyphicon-plus-sign" style="margin: 10px; left: 0px; width: 5px;"></span></span>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Bt_Ingresar">
                                    <div class="tab-pane fade in active" id="Ingresar">
                                        <h1 style="text-align: center">Formulario creación</h1>
                                        <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">

                                            <fieldset>
                                                <div runat="server" id="idiv">
                                                <!--Ingresar Numero de placa o serie -->
                                                <div class="pure-control-group">
                                         
                                        <label  for="numero" >Número de Placa / Serie </label>
                                          <asp:TextBox ValidationGroup="one" runat="server" ID="numero" data-toggle="tooltip" MaxLength="10" data-placement="left" ToolTip="Este espacio debe proporcionar el numero de placa o de seria para consultar activo." />
                                        
                                               </div>
                                         <!--Ingresar DESCRIPCION -->
                                         <div class="pure-control-group">
                                        <label for="descripcion">Descripción del activo</label>
                                        <asp:DropDownList ValidationGroup="one"  runat="server" data-toggle="tooltip" title="En este espacio puede seleccionar la descripción a buscar." id="descripcion_activo" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Todos</asp:ListItem>
                                        </asp:DropDownList>
                                                                                         </div>
                  
                             <!--Ingresar Despatamento-->
                                           <div class="pure-control-group">
                             <label for="area">Departamento o Sede regional destinado(a)</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title="En este espacio puede seleccionar el Departamento o Sede regional destinado(a) a buscar. " id="departamento_activo" CssClass="pure-input-1-2">
                                          <asp:ListItem Value="0">Todos</asp:ListItem>
                                             </asp:DropDownList>
                                                     
                                </div>
                             <!--Ingresar Proveedor-->
                                                <div class="pure-control-group">
                             <label for="provedor">Proveedor</label>
                                        <asp:DropDownList runat="server" data-toggle="tooltip" title=" En este espacio puede selecionar el nombre del proveedor del activo a buscar." id="proveedor" CssClass="pure-input-1-2">
                                        <asp:ListItem Value="0">Todos</asp:ListItem>
                                             </asp:DropDownList>
                                                    

                                               <asp:Button runat="server" ID="Consultar1" CssClass="btn btn-primary" OnClick="Consultar1_Click" Text="Consultar" />
                                               
                                                    </div>
                                                 
                                                 <asp:GridView ID="tabla" runat="server" CssClass="table table-striped table-hover" OnRowDeleting="tabla_SelectedIndexChanged">
                                            <Columns>
                                                <asp:CommandField DeleteText="Agregar Activo" ShowDeleteButton="True">
                                                    <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                                                </asp:CommandField>
                                            </Columns>
                                        </asp:GridView>
                                                </div>
                                            <div runat="server" id="theDiv" visible="False" >


                                                   <!--Ingresar Fecha_entrega-->                                                                                                 
                                                <fieldset class="pure-control-group">
                                                <label for="Fecha_entrega">Fecha de entrega:</label>
                                                <asp:TextBox runat="server" ID="Fecha_entrega" ToolTip="Este espacio debe contener la fecha de entrega de la donacion , este espacio es requerido."></asp:TextBox>
                                                <asp:CalendarExtender Format="yyyy/MM/dd"  ID="Fechaentrega" runat="server"  PopupButtonID="Fecha_entrega"  TargetControlID="Fecha_entrega" BehaviorID="_content_Fechaentrega" />
                                                <asp:RequiredFieldValidator ValidationGroup="one" ID="vFinalizacon" runat="server"   ControlToValidate="Fecha_entrega" ForeColor="Red" SetFocusOnError="True" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1"  ControlToValidate="Fecha_entrega" ValidationGroup="one" runat="server" ErrorMessage="No se puede escoger una fecha menor a la del día de hoy" ForeColor="Red" SetFocusOnError="True"></asp:RangeValidator>
                                                <asp:Button runat="server" CssClass="btn btn-primary"  OnClick="Agregar_Click" ID="Agregar"  Text="Agregar más  Activos " />
                                                </fieldset>
                                                
                                                <!--Ingresar Cedula-->
                                                <div class="pure-control-group" >
                                                    <label for="cedula_usuario">Número de cédula</label>
                                                    <asp:TextBox ValidationGroup="one" runat="server" ID="cedula_usuario"  AutoPostBack="True" OnTextChanged="cedula_usuario_TextChanged" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a entregar el prestamo, omita guiones y todos los dígitos del documento de identidad, es requerido."  placeholder="#-####-####" />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vCedula" runat="server" ControlToValidate="cedula_usuario" ForeColor="Red" SetFocusOnError="True" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                    <asp:MaskedEditExtender ID="cedula_usuario_MaskedEditExtender" runat="server" BehaviorID="cedula_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_usuario" />
                                                    <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator2" runat="server" ControlToValidate="cedula_usuario" ErrorMessage="&lt;b&gt;*&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                     <label for="cedula_usuario" runat="server"  id="Info" style="font-family: Arial, Helvetica, sans-serif; font-size: 17px; font-style: normal;  margin-right: 10px"></label>
                                                     </div>

                                                 <!--Ingresar nombre-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Nombre</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="nombre_usuario" data-toggle="tooltip" data-placement="right" title="Este espacio debe proporcionar el nombre de la persona a la cual se le entrega el activo, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vNombre" runat="server" ControlToValidate="nombre_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar apellido 1-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Primer Apellido</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="apellido_usuario1" data-toggle="tooltip" data-placement="right" ToolTip="Este espacio debe proporcionar el primer apellido de la persona a la cual se le entrega el activo, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vApellido1" runat="server" ControlToValidate="apellido_usuario1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>
                                                <!--Ingresar apellido 2-->
                                                <div class="pure-control-group">
                                                    <label for="nombre">Segundo Apellido</label>
                                                    <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="apellido_usuario2" data-placement="right"   data-toggle="tooltip" title="Este espacio debe proporcionar el segundo apellido de la persona a la cual se le entrega el activo, este espacio es requerido." />
                                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vApellido2" runat="server" ControlToValidate="apellido_usuario2" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                </div>

                                                 <!--Ingresar Telefono-->
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="telefono">Número telefónico</label>
                                                        <span class="add-on btn btn-default">506</span>
                                                        <asp:TextBox ValidationGroup="one" MaxLength="20" runat="server" ID="telefono_usuario" placeholder="####-####" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número telefónico principal de la persona a a la cual se le entrega el activo, este espacio es requerido." />
                                                        <cc1:MaskedEditExtender ID="telefono_usuario_MaskedEditExtender" runat="server" BehaviorID="telefono_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999-9999" TargetControlID="telefono_usuario"></cc1:MaskedEditExtender>
                                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="vTelefono" runat="server" ControlToValidate="telefono_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator3" runat="server" ControlToValidate="telefono_usuario" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </fieldset>
                                                 <!--Ingresar descripcion-->
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="descripcion_donacion">Especificaciones de la donación</label>
                                                        <asp:TextBox ValidationGroup="one"  runat="server" ID="descripcion_donacion" TextMode="MultiLine"  data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar una especificacion detallada de la donacion, este espacio es requerido." />
                                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="RequiredFieldValidator2" runat="server" ControlToValidate="descripcion_donacion" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>
                                                </fieldset>


                                              
                                               

                                                <asp:GridView ID="tabla1" runat="server" OnRowDeleting="tabla1_RowDeleting" CssClass="table table-striped table-hover">
                                                            <Columns>
                                                                <asp:CommandField DeleteText="Eliminar Activo" ShowDeleteButton="True">
                                                                <ControlStyle CssClass="btn btn-danger" />
                                                                </asp:CommandField>

                                                            </Columns>
                                                        </asp:GridView>
                                                 <div class="pure-controls-group" style="margin-top: 10px;">
                                                    <asp:Button runat="server" CssClass="btn btn-success"   ValidationGroup="one" OnClick="Bt_Ingresar_Click" ID="Bt_Ingresar" Text="Realizar préstamo" />
                                                </div>
                                                 

                                                    
                                                </div>
                                             
                                            </fieldset>
                                        </div>
                                    </div>
                                </asp:Panel>
                                </ContentTemplate>
                             </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de donación</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="tab-pane" id="Consultar">
                                            <h1 style="text-align: center" id="titulo">Formulario de consultas</h1>
                                            
                                            <asp:Panel ID="Panel3" runat="server">
                                                <div class="pure-form pure-form-aligned">
                                               
                                                <label for="id_prestamo">Número de Donación:</label>
                                                <asp:TextBox runat="server" ValidationGroup="two"   data-toggle="tooltip" data-placement="left"     ToolTip="Proporcione el número de prestamo,a consultar" ID="id_prestamo" />
                                                <asp:RequiredFieldValidator ValidationGroup="two" ID="RequiredFieldValidator1" runat="server" ControlToValidate="id_prestamo" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                  <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" BehaviorID="id_prestamo_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="true" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="999999999" TargetControlID="id_prestamo"></cc1:MaskedEditExtender>
                                                <asp:Button runat="server" ValidationGroup="two" ID="Consulta_prestamo" OnClick="Consulta_prestamo_Click"    class="btn btn-success" Text="Consultar"></asp:Button>
                                                 </div>  
                                  <br />
                                  <br />
                                  <br />

                                             
                                                <asp:GridView runat="server" OnRowCommand="tabla2_RowCommand" ID="tabla2" CssClass="table table-striped table-hover" >

                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Detalle">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="detalle" runat="server"  CssClass="glyphicon glyphicon-list-alt" CommandName="Detalle"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField  HeaderText="Descripción">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="Finalizar" runat="server" CssClass="glyphicon glyphicon-comment" CommandName="Descripcion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contactar">
                                                            <ItemTemplate><asp:LinkButton   ID="Prolongar" runat="server"  CssClass="glyphicon glyphicon-phone-alt"  CommandName="Contactar"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  /> </ItemTemplate> </asp:TemplateField>
                                      
    
                                    </Columns>

                                </asp:GridView>

                            
                                            </asp:Panel>
                                       
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>
                </div>

                <%-- *********MODAL DE DETALLLE****************************** --%>

                 <asp:Panel ID="PanelModal"  runat="server" >
<div class="modalPrestamo" runat="server" visible="false" tabindex="-1" style="background-color:rgba(51, 51, 51, 0.71)"  id="detalle" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <asp:Button runat="server" CssClass="close"  BorderStyle="None" OnClick="close_Click" aria-label="Close" aria-hidden="true" Text="&times;" ></asp:Button>
        <h4 class="modal-title">Detalle de la donación</h4>

      </div>
      <div class="modal-body">
      
           <div class="container" id="Imprimir" runat="server">
              <img src="img/ExpediaLogo.png" style="width:90px; height:90px; padding-right:7px;  float:left" alt="" />
                                                <br />
                                               <label for="TextBox4">Donación: </label> <asp:TextBox ID="TextBox4" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                                                <label for="TextBox5">Identificación de la persona :</label><asp:TextBox ID="TextBox5" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                                                <label for="TextBox6">Fecha de entrega:</label><asp:TextBox ID="TextBox6" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                   
                                            <div class="col-md-6 column">
                                              
                                                    
                                                    <asp:GridView runat="server" ID="Gridview1" CssClass="table table-bordered table-hover"></asp:GridView>
                                                
                                                </div>
                                             

                                            </div>

      </div>
      <div class="modal-footer">
        <asp:Button  runat="server" ID="detalle1" CssClass="btn btn-primary"  OnClientClick="imprimeDetalle();" Text="Impimir Detalle" ></asp:Button>
        <asp:Button runat="server" ID="close" CssClass="btn btn-default" Text="Cerrar" OnClick="close_Click"></asp:Button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>
   </asp:Panel>
                     <%--******** FIN DE MODAL DETALLE ************************ --%>

                     <%--************ MODAL DE DESCRIPCION************  --%>  
                 <asp:Panel ID="Panel4"  runat="server" >
<div class="modalPrestamo" runat="server" visible="false" tabindex="-1" style="background-color:rgba(51, 51, 51, 0.71)"  id="finalizar" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <asp:Button runat="server" CssClass="close"  BorderStyle="None" OnClick="Button2_Click" aria-label="Close" aria-hidden="true" Text="&times;" ></asp:Button>
        <h4 class="modal-title">Descripción</h4>

      </div>
      <div class="modal-body">
      
           <div class="container" id="Div2" runat="server">
               <img src="img/ExpediaLogo.png" style="width:90px; height:90px; padding-right:7px;  float:left" alt="" />
               <br />
              <asp:TextBox ID="TextBox8" TextMode="MultiLine" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox>
               <br />
               
                


            </div>

      </div>
      <div class="modal-footer">
        
        <asp:Button runat="server" ID="Button2" CssClass="btn btn-primary" Text="Cerrar" OnClick="Button2_Click"></asp:Button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>
   </asp:Panel>

                   <%--************ FIN MODAL DE DESCRIPCION************  --%>  

                <%-- ************ MODAL DE CONTACTO ***********--%>


                                 <asp:Panel ID="Panel6"  runat="server" >
<div class="modalPrestamo" runat="server" visible="false" tabindex="-1" style="background-color:rgba(51, 51, 51, 0.71)"  id="prolongar" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <asp:Button runat="server" CssClass="close"  BorderStyle="None" OnClick="Button3_Click" aria-label="Close" aria-hidden="true" Text="&times;" ></asp:Button>
        <h4 class="modal-title">Contactar</h4>

      </div>
      <div class="modal-body">
      
           <div class="container" id="Div3" runat="server">

               <img src="img/ExpediaLogo.png" style="width:90px; height:90px; padding-right:7px;  float:left" alt="" />
               <br />
               <div class="pure-control-group">
            <label for="Nombre">Nombre Completo:</label><asp:TextBox runat="server" ID="Nombre" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox>
               <label for="Telefono">Telefóno:</label><asp:TextBox runat="server" ID="Telefono" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox>
            </div>
               </div>

      </div>
      <div class="modal-footer">
        <asp:Button runat="server" ID="Button3" CssClass="btn btn-primary" Text="Cerrar" OnClick="Button3_Click"></asp:Button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>
   </asp:Panel>


                <%-- ************ FIN DE MODAL CONTACTO*********  --%>



                <%--****** MODAL PRESTAMO PENDIENTE--%>

                
                         <asp:Panel ID="Panel7"  runat="server" >
<div class="modalPrestamo" runat="server" visible="false" tabindex="-1" style="background-color:rgba(51, 51, 51, 0.71)"  id="pendiente" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <asp:Button runat="server" CssClass="close"  BorderStyle="None" OnClick="Button4_Click" aria-label="Close" aria-hidden="true" Text="&times;" ></asp:Button>
        <h4 class="modal-title">Prestamo pendiente</h4>

      </div>
      <div class="modal-body">
      
           <div class="container" id="Div4" runat="server">

                <label for="TextBox11">Prestamo: </label> <asp:TextBox ID="TextBox11" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                <label for="TextBox12">Identificación de solicitante:</label><asp:TextBox ID="TextBox12" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                 <label for="TextBox13">Fecha de entrega:</label><asp:TextBox ID="TextBox13" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br/>
                 <label for="TextBox14" style="padding-left:90px;">Fecha de regreso: </label><asp:TextBox ID="TextBox14" runat="server" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"></asp:TextBox><br />
                  <div class="col-md-6 column">
                                              
                                                    
                <asp:GridView runat="server" ID="Gridview2" CssClass="table table-bordered table-hover"></asp:GridView>
                                                
                          </div>
                                             
>
            </div>

      </div>
      <div class="modal-footer">
        
        <asp:Button runat="server" ID="Button4" CssClass="btn btn-danger" Text="Cerrar" OnClick="Button4_Click"></asp:Button>
        
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div>
   </asp:Panel>









                <%-- ****** FIN DE MODAL DE USUARIO INHABILIDATO --%>
                    




                <div id="Modales">
                   <%-- DefaultButton="Btn_ocupacion"--%>
                    <asp:Panel ID="Panel19" runat="server" >
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
                                                                    <asp:CheckBox runat="server" ID="check_traslado" readonly = 'true' Checked="true"  />
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
                                                                   <asp:CheckBox runat="server" ID="check_prestamo" readonly = 'true'  />
                                                               </td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </div>
                                                </fieldset>
                                                <label for="idSolicitante">Identificación de solicitante:</label><asp:TextBox runat="server" ID="TextBox1" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White"  /><br />
                                                <label for="fechaentrada">Fecha de entrega:</label><asp:TextBox runat="server" ID="fecha_conclucion" BorderStyle="None" BorderWidth="0px" Enabled="False" EnableTheming="True" BackColor="White" /><br />
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

                    
                    
                   
                  
                  
                        </div>
                </div>
          
  <%--          </ContentTemplate>
        </asp:UpdatePanel>--%>


           <!----------JAVA SCRIPTS--------->
           <script  type="text/jscript">
function imprimePanel1() {
    var printContent = document.getElementById("<%=Panel19.ClientID%>");
    var windowUrl = 'about:blank';

    var windowName = 'Comprobante de solicitud de tralasdo';
    var printWindow = window.open(windowUrl, windowName, 'width=745.628,height=692.105,top=0,left=0');

    printWindow.document.write(printContent.innerHTML);
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();
}

               function imprimeDetalle() {
    var printContent = document.getElementById("<%=Imprimir.ClientID%>");
    var windowUrl = 'about:blank';

    var windowName = 'detalle del prestamo';
    var printWindow = window.open(windowUrl, windowName, 'width=745.628,height=692.105,top=0,left=0');

    printWindow.document.write(printContent.innerHTML);
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();
}

</script>


         <script type="text/javascript" >

            




             




    </script>


    </form>
</body>
</html>
