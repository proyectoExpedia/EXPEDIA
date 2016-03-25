<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionDonaciones.aspx.cs" Inherits="EXPEDIA.GestionDonaciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
</head>

<body>
    <form id="form1" runat="server">
    <div>       

         <cc1:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0"> 

       <%--        ---------- Formulario 1 ---------        --%>
           <cc1:TabPanel runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                        <asp:TextBox runat="server" ValidationGroup="donacion"> </asp:TextBox>
                        <div class="tab-pane fade in active" id="donar">
                            <h1 style="text-align: center">Formulario de registro</h1>
                            <fieldset>
                                <%--        ---------- Número de placa ---------        --%>
                                <div class="pure-control-group">
                                    <label for="nplaca">Número de placa del activo</label>
                                     <asp:TextBox ValidationGroup="one" runat="server" ID="numero_placa" data-placement="left" ToolTip="Este espacio debe proporcionar el número de placa del activo que desea consultar, este espacio es requerido." placeholder="ENF-1523" />
                                     <asp:RequiredFieldValidator ValidationGroup="one" ID="vPlaca" runat="server" ControlToValidate="numero_placa" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </div>
                                <%--        ---------- Fecha de donación ---------        --%>
                                <div class="pure-control-group">
                                         <label for="fechaDonacion">Fecha de donación</label>
                                        <asp:TextBox runat="server" ID="fecha_donacion" ToolTip="Este espacio debe contener la fecha en que se realiza la donación del activo, este espacio es requerido.(Si la burbúja de sugerencias no le permite ver el calendario correctamente, presione la tecla ESC)" > </asp:TextBox>
                                        <cc1:CalendarExtender TargetControlID="fecha_donacion"  ID="caldonacion" runat="server"/>
                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="vdonacion" runat="server" ControlToValidate="fecha_donacion" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                 </div>
                                <%--        ---------- Número de serie ---------        --%>
                                <div class="pure-control-group">
                                    <label for="nserie">Número de serie del activo</label>
                                    <asp:TextBox ValidationGroup="one" ID="numero_serie" runat="server" data-placement="left" ToolTip="Este espacio debe proporcionar el número de serie del activo, este espacio es requerido." placeholder="MUJ23HJCK987" />
                                    <asp:RequiredFieldValidator ValidationGroup="one" ID="vSerie" runat="server" ControlToValidate="numero_serie" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </div>
                                <%--        ---------- Número de cédula ---------        --%>
                                <div class="pure-control-group">
                                     <label for="cedula">Número de cédula del donador:</label>
                                     <asp:TextBox ValidationGroup="one" runat="server" ID="cedula_usuario" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona que realiza la donación, omita guiones, incluya todos los dígitos del documento de identidad (también los ceros), este espacio es requerido." placeholder="#-####-####" />
                                     <asp:RequiredFieldValidator ValidationGroup="one" ID="vCedula" runat="server" ControlToValidate="cedula_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                     <cc1:MaskedEditExtender ID="cedula_usuario_MaskedEditExtender" runat="server" BehaviorID="cedula_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9-9999-9999" TargetControlID="cedula_usuario"></cc1:MaskedEditExtender>
                                     <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator2" runat="server" ControlToValidate="cedula_usuario" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^[1-9]-\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                               </div>
                                <%--        ---------- Descripción de la donación ---------        --%>
                                <fieldset class="pure-control-group">
                                        <label for="descripcion">Descripción</label>
                                        <asp:TextBox ValidationGroup="one" ID="descripcion" runat="server" data-toggle="tooltip" title="En este espacio se debe proporcionar una descripción que explique porque se realiza la donación (puede agregar algunos detalles que considere relevantes), este espacio es requerido" class="pure-input-1-2" placeholder="Especificaciones Técnicas" />
                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="vDescripcion" runat="server" ControlToValidate="descripcion" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </fieldset>
                                <%--        ---------- Nombre del receptor ---------        --%>
                                <div class="pure-control-group">
                                        <label for="nombre">Nombre del receptor</label>
                                        <asp:TextBox ValidationGroup="one" runat="server" ID="nombre_receptor" data-toggle="tooltip" data-placement="left" ToolTip="Este espacio debe proporcionar el nombre completo de la persona (o empresa) que recibe la donación. Este espacio es requerido." />
                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="vNombre" runat="server" ControlToValidate="nombre_receptor" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                </div>
                                <%--        ---------- Número de teléfono ---------        --%>
                                <fieldset class="pure-control-group">
                                        <div class="input-prepend">
                                                  <label for="telefono">Número telefónico del receptor</label>
                                                  <span class="add-on btn btn-default">506</span>
                                                  <asp:TextBox ValidationGroup="one" runat="server" ID="telefono_receptor" placeholder="####-####" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal de la persona (o empresa) que recibe la donación, este espacio es requerido." />
                                                  <cc1:MaskedEditExtender ID="telefono_usuario_MaskedEditExtender" runat="server" BehaviorID="telefono_usuario_MaskedEditExtender" Century="2000" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Mask="9999-9999" TargetControlID="telefono_usuario"></cc1:MaskedEditExtender>
                                                  <asp:RequiredFieldValidator ValidationGroup="one" ID="vTelefono" runat="server" ControlToValidate="telefono_usuario" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                  <asp:RegularExpressionValidator ValidationGroup="one" ID="RegularExpressionValidator3" runat="server" ControlToValidate="telefono_receptor" ErrorMessage="&lt;b&gt;Formato no valido&lt;/b&gt;" ForeColor="Red" ValidationExpression="^\d{4}-\d{4}$"></asp:RegularExpressionValidator>
                                        </div>
                                </fieldset>
                            </fieldset>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </cc1:TabPanel>

       <%--        ---------- Formulario 2 ---------        --%>
          <cc1:TabPanel runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Button1">
                        <asp:TextBox runat="server" ValidationGroup="donacion"> </asp:TextBox>
                        <div class="tab-pane fade in active" id="donar2">
                            <h1 style="text-align: center">Formulario de registro</h1>
                            <fieldset>
                                
                            </fieldset>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </cc1:TabPanel>

         </cc1:TabContainer>    
    </div>
    </form>
</body>
</html>
