﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionActivos.aspx.cs" Inherits="EXPEDIA.gestionActivos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EXPEDIA</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="icon" href="img/ExpediaLogo.png">
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
 <!--Menu-->
      <form runat="server" class="pure-form pure-form-aligned">
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
                        <li class="active"><a href="#Ingresar" data-toggle="tab">Registro de activos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                        <li><a href="#Consultar" data-toggle="tab">Control de activos <span class="glyphicon glyphicon-question-sign"></span><span class="glyphicon glyphicon-minus-sign"></span><span class="glyphicon glyphicon-ok-sign"></span></a></li>
                        <a style="float:right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Formulario de registro</h1>
                            <form  >
                                <fieldset> 
                                    <div class="pure-controls-group">
                                        <label for="Genero">Tipo de activo</label>
                                        <div style="margin-left:55px" class="btn-group" data-toggle="buttons">
                                            <label class="btn btn-primary" onclick="mostrarleasing(1);">
                                                <asp:RadioButton runat="server"   name="options" id="option1" autocomplete="off"/> Software
                                            </label>
                                            <label class="btn btn-primary " onclick="mostrarleasing(2);">
                                                <asp:RadioButton runat="server" name="options" id="option2" autocomplete="off"/> Hardware
                                            </label>
                                            <label class="btn btn-primary " onclick="mostrarleasing(3);">
                                               <asp:RadioButton runat="server" name="options" id="option3" autocomplete="off"/> Leasing
                                            </label> 
                                            
                                        </div>
                                    </div>

                                    <script> 
                                        //function mostrarleasing() {
                                        //    document.getElementById('leasing').style.display = 'block';
                                        //}
                                        function mostrarleasing(algo) {
                                            switch (algo) {
                                                case 1:
                                                    document.getElementById('leasing').style.display = 'none';
                                                    break;
                                                case 2:
                                                    document.getElementById('leasing').style.display = 'none';
                                                    break;
                                                case 3:
                                                    document.getElementById('leasing').style.display = 'block';
                                                    break;
                                            }
                                        }
                                    </script>

                                    <div class="pure-control-group">
                                        <label for="nplaca">Número de placa del activo</label>
                                        <asp:TextBox   runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar el nuevo número de placa del activo a registrar, es requerido" ID="nplaca" type="text" placeholder="ENF-1523" required="true"/>
                                    </div>

                                    <div class="pure-control-group" id="leasing" style="display:none">
                                        <div class="pure-control-group">
                                            <label for="fechaEntrega">Fecha de entrega a la empresa</label>
                                            <asp:TextBox runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que la empresa recibe el activo por parte del proveedor, es requerido." ID="fechaEntrega"  placeholder="Fecha de entrega"/>
                                            
                                        </div>
                                        <fieldset class="pure-control-group">
                                            <label for="descripcion">Duración del contrato</label>
                                            <select data-toggle="tooltip" title="En este espacio debe proporcionar la descripción del propósito general del activo, es requerido. " ID="descripcion" class="pure-input-1-2">
                                                <option>Elija una duración</option>
                                                <option>1 año</option>
                                                <option>2 años</option>
                                                <option>3 años</option>
                                                <option>Servidor</option>
                                                <option disabled>¿La duración no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a data-toggle="modal" data-target="#modalDescripcion"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </fieldset>
                                        <fieldset class="pure-control-group">
                                            <label for="Tipo">Especificaciones técnicas</label>
                                            <asp:TextBox  runat="server" TextMode  ="multiline"  ID="especificaciones"  data-toggle="tooltip" title="En este espacio se debe proporcionar las cualidades del activo." CssClass="pure-input-1-2" placeholder="Especificaciones Técnicas"/>
                                        </fieldset>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="nserie">Número de serie del activo</label>
                                        <asp:TextBox  runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar el nuevo número de serie del activo, es requerido" ID="nserie"  placeholder="XAD234ASFSD23" required/>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="fechaCompra">Fecha de compra</label>
                                        <asp:TextBox  runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha de compra del activo, es requerido." ID="fechaCompra"  placeholder="Fecha de compra"/>
                                    <script>$("#fechaCompra").datepicker();</script>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="fechaGarantia">Fecha de la garantía</label>
                                        <asp:TextBox runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha en que inicia la garantía del activo, es requerido." ID="fechaGarantia" type="text" placeholder="Fecha de garantía"/>
                                        <script>$("#fechaGarantia").datepicker();</script>
                                    </div>

                                    <fieldset class="pure-control-group">
                                        <label for="descripcion">Duración de la garantía</label>
                                        <select data-toggle="tooltip" title="En este espacio debe proporcionar la descripción del propósito general del activo, es requerido. " id="duracion" class="pure-input-1-2">
                                            <option>1 año</option>
                                            <option>2 años</option>
                                            <option>3 años</option>
                                            <option disabled>¿La duración que busca no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalDescripcion"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </fieldset>  
                                   
                                    <div class="pure-control-group">
                                        <label for="nplaca">Costo en colones, del activo</label>
                                        <asp:TextBox runat="server" TextMode="Number" data-toggle="tooltip" title="En este espacio debe ingresar el precio en colones, del activo. Utilice la cifra exacta. Evite redondear números. Es requerido" ID="costo"  placeholder="120360.17" required/>
                                    </div>                                

                                    <fieldset class="pure-control-group">
                                        <label for="descripcion">Descripción del activo</label>
                                        <select data-toggle="tooltip" title="En este espacio debe proporcionar la descripción del propósito general del activo, es requerido. " id="descripcion2" class="pure-input-1-2">
                                            <option>Elija una descripción</option>
                                            <option>Laptop</option>
                                            <option>Dispositivo de audio</option>
                                            <option>Dispositivo de audio-visuales</option>
                                            <option>Servidor</option>
                                            <option>Dispositivo de red</option>
                                            <option>Monitor</option>
                                            <option>Dispositivo de entrada-Salida</option>
                                            <option>Dispositivo de almacenamiento</option>
                                            <option disabled>¿La descripción no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalDescripcion"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </fieldset>


                                    <div class="pure-control-group">
                                        <label for="area">Departamento o Sede regional destinado(a)</label>
                                        <select data-toggle="tooltip" title="En este espacio debe proporcionar el área la cual está destinada el activo, es requerido. " id="area" class="pure-input-1-2">
                                            <option>Elija un Área o Departamento</option>
                                            <option>Recursos Humanos</option>
                                            <option>Departamento Legal</option>
                                            <option>Sede Grecia</option>
                                            <option>Sede Alajuela</option>
                                            <option disabled>¿La opción que busca no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="provedor">Proveedor</label>
                                        <select data-toggle="tooltip" title="Proveedor: En este espacio debe proporcionar el nombre del proveedor del activo, es requerido." id="provedor" class="pure-input-1-2">
                                            <option>Elija un proveedor</option>
                                            <option>HP</option>
                                            <option>Dell</option>
                                            <option>EMC</option>
                                            <option>Apple</option>
                                            <option>Toshiba</option>
                                            <option>Acer</option>
                                            <option>Asus</option>
                                            <option>Distribuidor Independiente</option>
                                            <option disabled>¿El proveedor no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalProveedor"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>
                                    <div class="pure-control-group">
                                        <fieldset class="pure-control-group">
                                            <label for="Tipo">Especificaciones técnicas</label>
                                            <textarea data-toggle="tooltip" title="En este espacio se debe proporcionar las cualidades del activo." class="pure-input-1-2" placeholder="Especificaciones Técnicas"></textarea>
                                        </fieldset>
                                    </div>
                                    <div class="pure-controls">
                                        <asp:Button runat="server"  CssClass="btn btn-success"  ID="enviar" Text="Registrar Activo"/>
                                        <div id="mensaje" style="display:none"><h3>Las acciones han sido realizado con éxito.</h3></div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                            <h1 style="text-align:center" id="titulo">Formulario de consultas</h1>
                            <div class="pure-form pure-form-aligned">
                                <div class="pure-control-group">
                                  
                                    <label for="cedula">Número de placa del activo</label>
                                    <asp:TextBox  runat="server" ID="cedula_buscar" data-toggle="tooltip" data-placement="left" title="Proporciona el número de placa del activo que desees consultar."  placeholder="#########" required/>
                              
                                         </div>

                                <p>
                                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Consultar"/>
                                </p>
                                <script type="text/javascript">
                                    function mostrar() {
                                        document.getElementById('oculto').style.display = 'block';
                                    }

                                </script>
                            </div>


                            <div id="oculto" class="pure-form pure-form-aligned" style="display:none">
                                <!--Esto realmente es un form-->
                                <fieldset>
                                    <div class="pure-control-group" style="margin-top:40px;">
                                        <p>

                                            <button class="btn btn-success" id="hab" onclick="habilitar();">Habilitar modificación</button>
                                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">Inhabilitar activo</button>
                                        </p>
                                        <div id="t" style="display:none"><h3>Formulario de modificación</h3></div>
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
                                            <div style="margin-left:55px;" class="btn-group" data-toggle="buttons">
                                                <label class="btn btn-primary disabled" id="rb1">
                                                    <asp:RadioButton runat="server"  ID="options" autocomplete="off"/> Software
                                                </label>
                                                <label class="btn btn-primary" id="rb2">
                                                   <asp:RadioButton runat="server"  ID="RadioButton1" autocomplete="off"/> Hardware
                                                </label>
                                            </div>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="nserie">Número de serie del activo</label>
                                            <asp:TextBox runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar el nuevo número de serie del activo, es requerido" ID="nserie1" readonly placeholder="XAD234ASFSD23" required/>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="fechaGarantia">Fecha de la garantía</label>
                                            <asp:TextBox  runat="server" data-toggle="tooltip" title="En este espacio debe proporcionar la fecha de caducidad de la garantía del activo, es requerido." disabled  id="fechaGarantia1"  placeholder="Fecha de garantía"/>
                                            <script>$("#fechaGarantia1").datepicker();</script>
                                        </div>

                                        <fieldset class="pure-control-group">
                                            <label for="descripcion1">Descripción del activo</label>
                                            <select data-toggle="tooltip" title="En este espacio debe proporcionar la descripción del propósito general del activo, es requerido. " disabled id="descripcion1" class="pure-input-1-2">
                                                <option>Laptop</option>
                                                <option>Dispositivo de audio</option>
                                                <option>Dispositivo de audio-visuales</option>
                                                <option>Servidor</option>
                                                <option>Dispositivo de red</option>
                                                <option>Monitor</option>
                                                <option>Dispositivo de entrada-Salida</option>
                                                <option>Dispositivo de almacenamiento</option>
                                                <option disabled>¿La descripción no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a data-toggle="modal" class="label disabled" id="d" data-target="#modalDescripcion"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </fieldset>

                                        <div class="pure-control-group">
                                            <label for="prove1">Área destinada</label>
                                            <select data-toggle="tooltip" title="En este espacio debe proporcionar el área la cual está destinada el activo, es requerido. " disabled id="area1" class="pure-input-1-2">
                                                <option>Recursos Humanos</option>
                                                <option>Departamento Legal</option>
                                                <option>Biblioteca</option>
                                                <option disabled>¿El area no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a data-toggle="modal" class="label disabled" id="a" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="area">Proveedor</label>
                                            <select data-toggle="tooltip" disabled title="Proveedor: En este espacio debe proporcionar el nombre del proveedor del activo, es requerido." id="prove1" class="pure-input-1-2">
                                                <option>HP</option>
                                                <option>Dell</option>
                                                <option>EMC</option>
                                                <option>Apple</option>
                                                <option>Toshiba</option>
                                                <option>Acer</option>
                                                <option>Asus</option>
                                                <option>Distribuidor Independiente</option>
                                                <option disabled>¿El proveedor no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a data-toggle="modal" class="label disabled"  data-target="#modalProveedor" id="p"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>
                                        <div class="pure-control-group">
                                            <fieldset class="pure-control-group">
                                                <label for="Tipo">Especificaciones técnicas</label>
                                                <textarea id="especificaciones" readonly data-toggle="tooltip" title="En este espacio se debe proporcionar las cualidades del activo." class="pure-input-1-2" placeholder="Especificaciones Técnicas">Procesador Intel core i7, 1Tb HDD, 14 pulgadas, censor de huella dactilar...</textarea>
                                            </fieldset>
                                        </div>
                                        <div class="pure-controls">
                                            <button class="btn btn-success" id="enviar1" style="display:none">Realizar modificaciones</button>
                                            <div id="mensaje1" style="display:none;float:right"><h3>Las acciones han sido realizado con éxito.</h3></div>
                                        </div>
                                    </fieldset>
                                </fieldset>
                            </div>
                            <script type="text/javascript">
                                function habilitar() {
                                    document.getElementById('nserie1').readOnly = false;
                                    document.getElementById('area1').disabled = false;
                                    document.getElementById('fechaGarantia1').disabled = false;
                                    document.getElementById('descripcion1').disabled = false;
                                    document.getElementById('especificaciones').readOnly = false;
                                    document.getElementById('prove1').disabled = false;
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
                                        <asp:Button runat="server" CssClass="btn btn-secondary" data-dismiss="modal" Text="Cerrar"/>
                                        <asp:Button runat="server" CssClass="btn btn-danger" ID="enviar2" Text="Inhabilitar"/>
                                    </div>
                                </div><!-- /.modal-content -->
                            </div><!-- /.modal-dialog -->
                        </div><!-- /.modal -->
                        <div class="modal fade" id="modalDescripcion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="NuevaDescripcion">Nueva descripción</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="ocupacion">Descripción</label>
                                                        <asp:TextBox runat="server" ID="ocupacion" required  placeholder="Dispositivo de audio" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la descripción del activo que se desea registrar, es requerido. "/>
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ID="btn_guardar" CssClass="btn btn-success" Text="Registrar descripción"/>
                                               <button  class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                            <div class="span pull-left" style="margin-top:20px;">
                                                <div class="alert alert-success fade">
                                                    <button type="button" class="close" data-dismiss="alert">×</button>
                                                    <strong>¡Acciones completadas!</strong> Ahora puedes seleccionar esta categoria.
                                                </div>
                                            </div>
                                            <script>
                                                $("#btn").on("click", function () {
                                                    $(".alert").removeClass("in").show();
                                                    $(".alert").delay(500).addClass("in").fadeOut(2000);
                                                });
                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- /.modal -->
                         </div>
                        <div class="modal fade" id="modalProveedor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="Nuevoproveedor">Nuevo proveedor</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset>
                                                    <div class="pure-control-group">
                                                        <label for="idP">Identificador</label>
                                                        <asp:TextBox runat="server" ID="idp"  required placeholder="PR-000" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice el proveedor que se esté registrando, es requerido. "/>
                                                    </div>

                                                    <div class="pure-control-group">
                                                        <label for="nproveedor">Nombre del proveedor</label>
                                                         <asp:TextBox runat="server" ID="nproveedor"  required placeholder="Dell" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre del proveedor que se esté registrando, es requerido."/>
                                                    </div>

                                                    <div class="pure-control-group">
                                                        <label for="correo">Correo electrónico</label>
                                                        <asp:TextBox runat="server" TextMode="Email" ID="correo" type="email" required data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la dirección de correo electrónico del proveedor a registrar, es requerido."/>
                                                    </div>

                                                    <fieldset class="pure-control-group">
                                                        <label for="telefono">Número telefónico de la empresa</label>
                                                        <span class="add-on btn btn-default">506</span>
                                                        <asp:TextBox  runat="server" ID="telefono1" required type="number" placeholder="########" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal del proveedor a registrar, es requerido." min="11111111" max="99999999"/>
                                                    </fieldset>

                                                    <fieldset class="pure-control-group">
                                                        <label for="telefono">Número telefónico de contacto </label>
                                                        <span class="add-on btn btn-default">506</span>
                                                        <asp:TextBox runat="server" ID="telefono" type="number" placeholder="########" required data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal del contacto del proveedor, es requerido."  min="11111111" max="99999999"/>
                                                    </fieldset>
                                                </fieldset>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ID="Resgistrar_Proveedor" CssClass="btn btn-success" Text="Registrar proveedor"/>
                                                <button  class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                            <div class="span pull-left" style="margin-top:20px;">
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
                            </div><!-- /.modal -->
                            </div>
                        <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" style="text-align:center" id="NuevAarea">Nueva área de servicio</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="container">
                                                <div class="pure-form pure-form-aligned">
                                                    <fieldset class="pure-control-group">
                                                        <div class="input-prepend">
                                                            <label for="idarea">Identificador del área</label>
                                                            <asp:TextBox runat="server" ID="idareas" required  placeholder="AR-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice el área o unidad que se esté registrando, es requerido. "/>
                                                        </div>
                                                        <div class="input-prepend">
                                                            <label for="area57">Área</label>
                                                             <asp:TextBox runat="server" ID="area57" required type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, es requerido. "/>
                                                        </div>
                                                    </fieldset>
                                                </div> <!-- /container -->
                                            </div>
                                            <div class="modal-footer">
                                                <div class="span">
                                                    <asp:Button runat="server" ID="Registrar_Area" CssClass="btn btn-success" Text="Registrar área"/>
                                                    <button  class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                                </div>
                                                <div class="span pull-left" style="margin-top:20px;">
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
                                </div><!-- /.modal -->
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
    <script>
    function Guardar(y)
    { switch(y){
    case 1: { localStorage["Descripcion"] = document.getElementById("ocupacion").value; break; }
    case 2: { localStorage["Area"] = document.getElementById("area57").value; break; }
    case 3: { localStorage["Proveedor"] = document.getElementById("nproveedor").value; break; }
    }
    }


    function Mostrar_Infoo(x)
    {
        switch (x) {
            case 1: { var option = document.createElement("option");
                option.text = localStorage["Descripcion"].toString();
                document.getElementById("descripcion").add(option);
            Mostrar_Infoo(4);
            break;
            }
            case 2: {var option1 = document.createElement("option");
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
            case 5: { var option1 = document.createElement("option");
                option1.text = localStorage["Area"];
                document.getElementById("area1").add(option1); break;
            }
            case 6: { var option = document.createElement("option");
                option.text = localStorage["Proveedor"].toString();
                document.getElementById("prove1").add(option); break;
            }
            }

    }</script>
          </form>
</body>
</html>
