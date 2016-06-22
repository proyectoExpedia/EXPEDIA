<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionAreas.aspx.cs" Inherits="EXPEDIA.gestionAreas" %>

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
    <style type="text/css">
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
           
            
        <div class="container">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server"></asp:SiteMapPath>
            <br />
            <br />
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Gestión de Areas</h3>
                        <div>
                        <a style="float:right;margin-top:21px;" href="gestionAjustes.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                        </div>
                    </div>
                  
                    <div class="panel-body">
                        <asp:TabContainer ID="TabContainer1" CssClass="nav nav-tabs" runat="server" ActiveTabIndex="0">
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px' data-toggle='tab'><b>Registro de Departamento</b><span style='margin: 10px' class='glyphicon glyphicon-plus-sign'></span></span>" ID="TabPanel1">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" DefaultButton="Btn_areas">
                                        <div class="tab-pane fade in active" id="Ingresar">
                                            <h1 style="text-align: center">Formulario de Registro</h1>
                                            <div class="pure-form pure-form-aligned" style="margin-top: 5px; margin-left: 20px;">
                                                 <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="idarea">Identificador del Departamento</label>
                                                        <asp:TextBox runat="server" MaxLength="20" ValidationGroup="one"  ID="idareas"   placeholder="AR-001" data-toggle="tooltip" data-placement="right" title="Ingrese la identificación para el nuevo Departamento, a la que se destinarán los activos, este espacio es requerido. " />
                                                        <asp:RequiredFieldValidator ValidationGroup="one" ID="RequiredFieldValidator6" runat="server"  ForeColor="Red" ControlToValidate="idareas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area">Departamento</label>
                                                        <asp:TextBox runat="server" MaxLength="20" id="areas" ValidationGroup="one" type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="right" title="Ingrese el nombre para el nuevo Departamento, a la que se destinarán los activos, este espacio es requerido. " />
                                                        <asp:RequiredFieldValidator ValidationGroup="one" MaxLength="500" ID="RequiredFieldValidator7" runat="server"  ForeColor="Red" ControlToValidate="areas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                </fieldset>
                                                 <div class="span">
                                                    <asp:Button runat="server" ValidationGroup="one" CssClass="btn btn-success" OnClick="Btn_areas_Click" ID="Btn_areas" Text="Registrar Departamento" />
                                                 </div>
                                                <br />
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                             </asp:TabPanel>
                            <asp:TabPanel runat="server" HeaderText="<span style='margin: 5px'  data-toggle='tab'><b>Control de Departamentos</b> <span style='margin: 10px'  class='glyphicon glyphicon-question-sign'></span><span class='glyphicon glyphicon-minus-sign'></span><span class='glyphicon glyphicon-ok-sign'></span></span>" ID="TabPanel2">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div class="tab-pane" id="Consultar">
                                            <h1 style="text-align: center" id="titulo">Formulario de Consultas</h1>
                                            <div class="pure-form pure-form-aligned">
                                            <asp:Panel ID="Panel3" runat="server" DefaultButton="">
                                                    <div class="form-group pull-right">  <input type="text" class="search form-control" placeholder="Digite el valor a buscar" /></div>
                                                    <span class="counter pull-left"></span>
                                                <div class="form-group pull-right"><label>Buscar:  </label></div>
                                                    <asp:Table ID="Table2" runat="server" CssClass="table table-hover table-bordered results">
                                                         <asp:TableHeaderRow runat="server">
                                                                <asp:TableHeaderCell ColumnSpan="1">Identificador</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="1">Departamento</asp:TableHeaderCell>
                                                                <asp:TableHeaderCell ColumnSpan="2">Acciones</asp:TableHeaderCell>
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
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Nueva Departamento de servicio</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="idarea">Identificador del Departamento</label>
                                                        <asp:TextBox ClientIDMode="Static" runat="server" MaxLength="20" ValidationGroup="Six" ReadOnly="true" ID="midArea" placeholder="AR-001" data-toggle="tooltip" data-placement="right" title="Ingrese la identificación para el nuevo Departamento, a la que se destinarán los activos, este espacio es requerido. " />
                                                        <asp:TextBox runat="server" ClientIDMode="Static" ID="midAreas" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" ID="RequiredFieldValidator1" runat="server"  ForeColor="Red" ControlToValidate="midAreas" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area">Departamento</label>
                                                        <asp:TextBox runat="server" ClientIDMode="Static" MaxLength="20" id="mDescripcion" ValidationGroup="Six" type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="right" title="Ingrese el nombre para el nuevo Departamento, a la que se destinarán los activos, este espacio es requerido. " />
                                                        <asp:RequiredFieldValidator ValidationGroup="Six" MaxLength="500" ID="RequiredFieldValidator2" runat="server"  ForeColor="Red" ControlToValidate="mDescripcion" ErrorMessage="<b>*</b>"></asp:RequiredFieldValidator>
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ValidationGroup="Six" CssClass="btn btn-primary" OnClick="Btn_modificar_areas_Click" ID="Button1" Text="Modificar Departamento" />
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
                            <h1 class="modal-title" style="text-align:center" id="exampleModalLabe">Departamento Inhabilitado</h1>
                        </div>
                        <div class="modal-body">
                            <div class="container">
                               El Departamento <b id="idA"></b> que está consultando, se encuentra inhabilitado en el sistema.
                                <br />
                                <a href="#" title="Motivos de inhabilitacion: " id="motivos" data-toggle="popover" data-trigger="focus" data-content=""><b>Detalle <span style='margin: 5px'  class='glyphicon glyphicon-paperclip'></span></b></a>          
                                    <script>
                                        $(document).ready(function () {
                                            $('[data-toggle="popover"]').popover();
                                        });
                                    </script>
                                <br />
                                <h3>¿Desea habilitar denuevo el Departamento?</h3>
                                </div>
                            </div> <!-- /container -->
                        <div class="modal-footer">
                            <img src="img/ExpediaLogo.png" alt="" style="width:50px; height:50px;float:left" />
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
             ida = row.cells[0].innerHTML;
             descripcion = row.cells[1].innerHTML;
             document.getElementById('midArea').value = ida;
             document.getElementById('midAreas').value = ida;
             document.getElementById('mDescripcion').value = descripcion;
             document.getElementById("midAreas").style.visibility = "hidden";
         }

         function inhabilitar(id) {
             var row = document.getElementById(id);
             ida = row.cells[0].innerHTML;
             descripcion = row.cells[1].innerHTML;
             document.getElementById('midArea').value = ida;
             document.getElementById('midAreas').value = ida;
             document.getElementById('mDescripcion').value = descripcion;
         }

         function habilitar(id) {
             var row = document.getElementById(id);
             ida = row.cells[0].innerHTML;
             des = row.cells[1].innerHTML;
             mot = row.cells[3].innerHTML;
             document.getElementById("idA").innerText = ida;
             document.getElementById("midAreas").value = ida;
             document.getElementById("mDescripcion").value = des;
             var chatIcon = $("#motivos");
             chatIcon.attr("data-content",mot).data('popover').setContent();

         }
     </script>
     </form>
        <footer class="navbar" style="background-color:white">
        <div class="container">
            <h5 style="text-align: center" class="text-muted">EXPEDIA - Colegio de Abogados y Abogadas de Costa Rica - UNA</h5>
        </div>
    </footer>
</body>
</html>
