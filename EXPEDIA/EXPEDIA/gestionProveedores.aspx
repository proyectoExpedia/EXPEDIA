<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionProveedores.aspx.cs" Inherits="EXPEDIA.gestionProveedores" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
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
    <style type)="text/css">
        body{
  padding:20px 20px;
}
        .results tr[visible='false'],
        .no-result{
  display:none;
}
        .results tr[visible='true']{
  display:table-row;
}
        .counter{
  padding:8px; 
  color:#ccc;
}
        td {
            width: 200px;
            height: 50px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".search").keyup(function () {
                var searchTerm = $(".search").val();
                var listItem = $('.results tbody').children('tr');
                var searchSplit = searchTerm.replace(/ /g, "'):containsi('")

                $.extend($.expr[':'], {
                    'containsi': function (elem, i, match, array) {
                        return (elem.textContent || elem.innerText || '').toLowerCase().indexOf((match[3] || "").toLowerCase()) >= 0;
                    }
                });

                $(".results tbody tr").not(":containsi('" + searchSplit + "')").each(function (e) {
                    $(this).attr('visible', 'false');
                });

                $(".results tbody tr:containsi('" + searchSplit + "')").each(function (e) {
                    $(this).attr('visible', 'true');
                });

                var jobCount = $('.results tbody tr[visible="true"]').length;
                $('.counter').text(jobCount + ' item');

                if (jobCount == '0') { $('.no-result').show(); }
                else { $('.no-result').hide(); }
            });
        });

    </script>
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
                    <a class="navbar-brand" style="float: left" href="#">
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
                        <h3 class="panel-title">Gestión de Proveedores</h3>
                        <div>
                        <a style="float:right;margin-top:21px;" href="gestionAjustes.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                        </div>
                    </div>
                  
                    <div class="panel-body">
                        <asp:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0">
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de Proveedores</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Resgistrar_Proveedor">
                                        <div class="tab-pane fade in active" id="Ingresar">
                                            <h1 style="text-align: center">Formulario de Registro</h1>
                                            <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-right: 20px;">
                                                <fieldset>
                                                        <div class="pure-control-group">
                                                            <label for="idP">Identificador</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="idp" placeholder="PR-000" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un identificador para el proveedor que se está ingresando, este espacio es requerido. " />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vIdp" runat="server" ControlToValidate="idp" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="nproveedor">Nombre del proveedor</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="nproveedor" placeholder="Dell" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el nombre del proveedor que está registrando, este espacio es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vnproveedor" runat="server" ControlToValidate="nproveedor" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="correo">Correo electrónico</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" TextMode="Email" ID="correo" type="email" data-toggle="tooltip" data-placement="right" title="Ingrese el correo electrónico del proveedor que está ingresando, este espacio es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vcorreo" runat="server" ControlToValidate="correo" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de la empresa</label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="telefono1" type="number" placeholder="########" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número telefónico principal del proveedor que está ingresando, este espacio es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vtelefono1" runat="server" ControlToValidate="telefono1" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de contacto </label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="telefono" type="number" placeholder="########" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un número secundario (por ejemplo celular) del proveedor que se está registrando, este espacio es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="c" ID="vtelefono" runat="server" ControlToValidate="telefono" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </fieldset>
                                                <div class="span">
                                                   <asp:Button runat="server" ValidationGroup="c" ID="Resgistrar_Proveedor" CssClass="btn btn-success" OnClick="btn_Registrar_Proveedor_Click" Text="Registrar proveedor" />
                                                 </div>
                                                <br />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                             </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de ocupaciones</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="tab-pane" id="Consultar">
                                            <h1 style="text-align: center" id="titulo">Formulario de Consultas</h1>
                                            <div class="pure-form pure-form-aligned">
                                            <asp:Panel ID="Panel3" runat="server" DefaultButton="">
                                                    <div class="form-group pull-right">  <input type="text" class="search form-control" placeholder="Digita el valor a buscar" /></div>
                                                    <span class="counter pull-right"></span>
                                                <div class="form-group pull-right"><label>Buscar:  </label></div>
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
                                            </asp:Panel>
                                            </div>   
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </div>
                </div>
                <div id="Modales">
                    <asp:Panel ID="Panel7" runat="server" DefaultButton="Button1">
                         <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Modificación de Proveedor</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset>
                                                        <div class="pure-control-group">
                                                            <label for="idP">Identificador</label>
                                                            <asp:TextBox runat="server" ReadOnly="true" ValidationGroup="Six" ID="idpM" placeholder="PR-000" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un identificador para el proveedor que se está registrando, este espacio es requerido. " />
                                                            <asp:TextBox runat="server" ClientIDMode="Static" ID="idpMO" ></asp:TextBox>
                                                            <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator1" runat="server" ControlToValidate="idpM" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="nproveedor">Nombre del proveedor</label>
                                                            <asp:TextBox runat="server" ValidationGroup="c" ID="nproveedorM" placeholder="Dell" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el nombre del proveedor que se está registrando, este espacio es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator2" runat="server" ControlToValidate="nproveedorM" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="correo">Correo electrónico</label>
                                                            <asp:TextBox runat="server" ValidationGroup="Six" TextMode="Email" ID="correoM" type="email" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar la dirección de correo electrónico del proveedor a registrar, este espacio es requerido." />
                                                            <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator3" runat="server" ControlToValidate="correoM" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de la empresa</label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="Six" ID="telefono1M" type="number" placeholder="########" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar el número telefónico principal del proveedor que se está registrando, este espacio es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator4" runat="server" ControlToValidate="telefono1M" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>

                                                        <div class="pure-control-group">
                                                            <label for="telefono">Número telefónico de contacto </label>
                                                            <span class="add-on btn btn-default">506</span>
                                                            <asp:TextBox runat="server" ValidationGroup="Six" ID="telefonoM" type="number" placeholder="########" data-toggle="tooltip" data-placement="right" title="En este espacio se debe proporcionar un número secundario (por ejemplo, celular) del proveedor que se está registrando, este espacio es requerido." min="11111111" max="99999999" />
                                                            <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator6" runat="server" ControlToValidate="telefonoM" ForeColor="Red" SetFocusOnError="true" ErrorMessage="&lt;b&gt;*&lt;/b&gt;"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </fieldset>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ValidationGroup="Six" CssClass="btn btn-primary" OnClick="Btn_modificar_proveedores_Click" ID="Button1" Text="Modificar proveedor" />
                                                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                         </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel6" runat="server" DefaultButton="Btn_inhabilitar">
                        <div class="modal fade" id="modalInhabilitar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                            <span class="sr-only">Close</span>
                                        </button>
                                        <h4 class="modal-title">Motivos de Inhabilitación</h4>
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
                </div>
            </div>
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>

            <div class="modal fade" id="exampleModa" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
                        <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h1 class="modal-title" style="text-align:center" id="exampleModalLabe">Usuario Inhabilitado</h1>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                               La ocupación <b id="idA"></b> que acaba de consultar, se encuentra inhabilitado en el sistema.
                                <br />
                                <a href="#" title="Motivos de inhabilitación: " id="motivos" data-toggle="popover" data-trigger="focus" data-content=""><b>Detalle <span style='margin: 5px'  class='glyphicon glyphicon-paperclip'></span></b></a>          
                                    <script>
                                        $(document).ready(function () {
                                            $('[data-toggle="popover"]').popover();
                                        });
                                    </script>
                                <br />
                                <h3>¿Desea habilitar denuevo la ocupacion?</h3>
                                </div>
                            </div> <!-- /container -->
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:right" />
                            <asp:Button runat="server" ID="btn_habilitarUsuario" Text="Si" CssClass="btn btn-danger" OnClick="btn_habilitarUsuario_Click"/>
                            <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                        </div>
                    </div>
                </div>
            </div>
              

     <script>
         $(document).ready(function () {
             $('[data-toggle="popover"]').popover();
         });
     </script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('[data-toggle="tooltip"]').tooltip();
         });
     </script>
     <script type="text/javascript">
         function modificar(id) {
             var row = document.getElementById(id);
             idp = row.cells[0].innerHTML;
             nombre = row.cells[1].innerHTML;
             correo = row.cells[2].innerHTML;
             numeros = row.cells[3].innerHTML;
             var numeroArray = numeros.split("\n");
             document.getElementById('idpM').value = idp;
             document.getElementById('idpMO').value = idp;
             document.getElementById('nproveedorM').value = nombre;
             document.getElementById('correoM').value = correo;
             document.getElementById('telefono1M').value = numeroArray[0];
             document.getElementById('telefonoM').value = numeroArray[1];
             document.getElementById("idpMO").style.visibility = "hidden";
         }

         function inhabilitar(id) {
             var row = document.getElementById(id);
             idp = row.cells[0].innerHTML;
             nombre = row.cells[1].innerHTML;
             correo = row.cells[2].innerHTML;
             numeros = row.cells[3].innerHTML;
             var numeroArray = numeros.split("\n");
             document.getElementById('idpM').value = idp;
             document.getElementById('idpMO').value = idp;
             document.getElementById('nproveedorM').value = nombre;
             document.getElementById('correoM').value = correo;
             document.getElementById('telefono1M').value = numeroArray[0];
             document.getElementById('telefonoM').value = numeroArray[1];
         }

         function habilitar(id) {
             var row = document.getElementById(id);
             idp = row.cells[0].innerHTML;
             nombre = row.cells[1].innerHTML;
             correo = row.cells[2].innerHTML;
             numeros = row.cells[3].innerHTML;
             mot = row.cells[5].innerHTML;
             document.getElementById("idA").innerText = idp;
             document.getElementById("idpMO").value = idp;
             var numeroArray = numeros.split("\n");
             document.getElementById('idpM').value = idp;
             document.getElementById('idpMO').value = idp;
             document.getElementById('nproveedorM').value = nombre;
             document.getElementById('correoM').value = correo;
             document.getElementById('telefono1M').value = numeroArray[0];
             document.getElementById('telefonoM').value = numeroArray[1];
             //document.getElementById("mDescripcion").value = des;
             var chatIcon = $("#motivos");
             chatIcon.attr("data-content", mot).data('popover').setContent();

         }
     </script>
     </form>
</body>
</html>
