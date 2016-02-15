<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionPrestamos.aspx.cs" Inherits="EXPEDIA.gestionPrestamos" %>

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
    <link href="css/boostrap-snipp.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.9/css/dataTables.jqueryui.min.css">
    <script src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.9/js/dataTables.jqueryui.min.js"></script>
    <link href="css/bootstrap-table.css" rel="stylesheet" />
    <script src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>
</head>
<body>
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
                <h3 class="panel-title">Gestión de préstamos</h3>
            </div>
            <div class="panel-body">
                <div class="tabs-example">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#Ingresar" data-toggle="tab">Creacion de préstamos <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                        <li><a href="#Consultar" data-toggle="tab">Control de préstamos <span class="glyphicon glyphicon-question-sign"></span><span class="glyphicon glyphicon-minus-sign"></span><span class="glyphicon glyphicon-ok-sign"></span></a></li>
                        <a style="float:right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Formulario de creación</h1>
                            <div class="pure-form pure-form-aligned">
                                <fieldset>

                                    <div class="pure-control-group">
                                        <label for="idP">Identificador de préstamo</label>
                                        <input id="idP" type="text" data-toggle="tooltip" title="En este espacio debe proporcionar un identificador que caracterice el préstamo a registrar, es requerido" placeholder="PRES-001">
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="idP">Identificación del solicitante</label>
                                        <input id="idP" type="text" placeholder="#########" data-toggle="tooltip" data-placement="left" title="Proporciona el número de cédula del solicitante a cargo del préstamo. Recuerda no ingresar guiones y tomar en cuenta los ceros del documento de identidad, es requerido.">
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="fechaGarantia">Fecha de entrega</label>
                                        <input data-toggle="tooltip" title="Proporcione la fecha a la cual se extiende el préstamo, es requerido." id="fechaentrega" type="text" placeholder="Haz click para seleccionar tu fecha">
                                        <script>$("#fechaentrega").datepicker();</script>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="fechaGarantia">Fecha de salida</label>
                                        <input data-toggle="tooltip" title="Proporcione la fecha en la cual se emite el préstamo, es requerido" id="fechasalida" type="text" placeholder="Haz click para seleccionar tu fecha">
                                        <script>$("#fechasalida").datepicker();</script>
                                    </div>

                                    <div class="pure-control-group">
                                        <div class="container"style="margin-top:30px;">
                                     
                                                <div class="col-md-6 column" >
                                                    <div>
                                                    <table class="table table-striped table-hover" id="tab_logic">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">
                                                                    Consecutivo
                                                                </th>
                                                                <th class="text-center">
                                                                    Número de placa del activo
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr id='addr0'>
                                                                <td>
                                                                    1
                                                                </td>
                                                                <td>
                                                                    <input type="text" name='activo0' data-toggle="tooltip" title="En este espacio debe proporcionar el numero de placa del activo que desee prestar."  placeholder="ENF-1523" class="form-control" />
                                                                </td>
                                                            </tr>
                                                            <tr id='addr1'></tr>
                                                        </tbody>
                                                    </table>
                                                    <a id="add_row" class="btn btn-primary">Agregar activo</a>
                                                    <a id='delete_row' class="btn btn-danger">Eliminar fila</a>
                                                    <a id="comprobar" class="btn btn-success">Comprobar activos</a>
                                                    <div class="span pull-left" style="margin-top:10px;">
                                                           <div class="alert alert-success fade"> 
                                                                <button type="button" class="close" data-dismiss="alert">×</button>
                                                                <strong>¡Excelente!</strong> Hay existencia de todos los activos indicados.
                                                            </div>
                                                    </div>
                                                        <script>
                                                            $("#comprobar").on("click", function () {
                                                                $(".alert").removeClass("in").show();
                                                                $(".alert").delay(500).addClass("in").fadeOut(4000);
                                                            });
                                                        </script>
                                                </div>
                                            </div>
                                        <script>
                                            $(document).ready(function () {
                                                var i = 1;
                                                $("#add_row").click(function () {
                                                    $('#addr' + i).html("<td>" + (i + 1) + "</td><td><input name='activo" + i + "' type='text' placeholder='ENF-1523' class='form-control input-md'  /> </td>");

                                                    $('#tab_logic').append('<tr id="addr' + (i + 1) + '"></tr>');
                                                    i++;
                                                });
                                                $("#delete_row").click(function () {
                                                    if (i > 1) {
                                                        $("#addr" + (i - 1)).html('');
                                                        i--;
                                                    }
                                                });

                                            });
                                        </script>
                                    </div>

                                </div>
                                    <div class="pure-controls-group" style="margin-top:40px;">
                                        <button data-toggle="modal" data-target="#modalProveedor" class="btn btn-success" id="enviar">Realizar préstamo</button>
                                        <div id="mensaje" style="display:none">
                                            <h3>Las acciones han sido realizado con éxito.</h3>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                            <h1 style="text-align:center" id="titulo">Administrar préstamos</h1>
                            <table id="tabla" class="display" cellspacing="0" width="100">
                                <thead style="text-align:center">
                                    <tr>
                                        <th>Identificador del préstamo</th>
                                        <th>Identificación del solicitante asociado</th>
                                        <th>Detalle</th>
                                        <th>¿Al dia?</th>
                                        <th>¿Finalizado?</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>PRES-001</td>
                                        <td>115380448</td>
                                        <td><a style="font-size:large" data-toggle="modal" data-target="#modalProveedor"><span class="glyphicon glyphicon-list-alt"></span></a></td>
                                        <td><a style="font-size:large" ><span class="glyphicon glyphicon-thumbs-up"></span></a></td>
                                        <td><a style="font-size:large" data-toggle="modal" data-target="#modalAreas"><span id="mano" class="glyphicon glyphicon-thumbs-down"></span></a></td>
                                    </tr>
                                </tbody>
                            </table>
                             <script>
                                 $(document).ready(function () {
                                     $('#tabla').DataTable();
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
                                        <textarea></textarea>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <button type="button" class="btn btn-danger" id="enviar2">Inhabilitar</button>
                                    </div>
                                </div><!-- /.modal-content -->
                            </div><!-- /.modal-dialog -->
                        </div><!-- /.modal -->
                        <div class="modal fade" id="modalDescripcion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Nueva descripción</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="ocupacion">Descripción</label>
                                                        <input id="ocupacion" required type="text" placeholder="Dispositivo de audio" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la descripción del activo que se desea registrar, es requerido. ">
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <button id="btn" class="btn btn-success">Registrar descripción</button>
                                                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
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
                        <div class="modal fade"    id="modalProveedor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document" style="float:left">
                                <div class="modal-content"  style="width:180%;margin-left:140px" >
                                    <div class="modal-header" >
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Detalle del préstamo</h4>
                                    </div>
                                    <!-- MODAL A CAMBIAR  -->
                                    <div id="muestra" >
                                        <div class="modal-body">
                                            <div class="container">
                                                <img src="img/colegioAbogadoscr.png" style="width:90px; height:90px;float:left" alt="" />
                                                <br />
                                                <label for="Fecha" style="font-size:20px; margin-right:148px; margin-left:75px;">COLEGIO DE ABOGADOS Y ABOGADAS DE COSTA RICA</label> <b id="Fecha">Fecha 28/01/2016</b>
                                                <label for="Numero" style="font-size:20px; margin-right:150px; margin-left:25px;">SOLICITUD DE TRASLADO,PRESTAMO,EXCLUSIÓN DE ACTIVO FIJO </label><b id="Numero">N°001</b>
                                                <br />
                                                <br />
                                                <br />
                                                <fieldset class="pure-control-group" style="border:none">
                                                    <div class="col-md-10 column">
                                                    <table class="table table-bordered" id="tab_logic">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <label for="1ch" style="font-size:18px; margin-right:152px;">1.SOLICITUD DE TRASLADO (cuando es en forma permanente a otro departamento)</label>
                                                                </td>
                                                                <td>
                                                                    <input id="1ch" type="checkbox" disabled />
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td>
                                                                   <label for="1ch" style="font-size:18px; margin-right:250px;">2.SOLICITUD DE EXCLUSIÓN(cuando va a dejarse de usar por el colegio)</label> 
                                                                </td>
                                                                <td>
                                                                    <input id="2ch" type="checkbox" disabled />
                                                               </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                   <label for="1ch" style="font-size:18px; margin-right:370px;">3.SOLICITUD DE PRESTAMO (cuando es en forma temporal)</label> 
                                                                </td>
                                                                <td>
                                                                   <input id="3ch" type="checkbox" checked disabled />
                                                               </td>
                                                            </tr>

                                                        </tbody>
                                                    </table>
                                                </div>
                                                </fieldset>
                                                <label for="idSolicitante">Identificación de solicitante: 115380448</label><br />
                                                <label for="fechaentrada">Fecha de conclusión: 19/11/2015</label><br />
                                                <div class="col-md-6 column">
                                                    <table class="table table-bordered table-hover" id="tab_logic">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center">
                                                                    Consecutivo
                                                                </th>
                                                                <th class="text-center">
                                                                    Número de placa del activo
                                                                </th>
                                                                <th class="text-center">
                                                                    Descripción
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    1
                                                                </td>
                                                                <td>
                                                                    <label>EIF-001</label>
                                                                </td>
                                                                <td>
                                                                    <label>Computadora Dell, Intel core i5, 500GB HDD, pantalla de 14 pulgadas</label>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
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
                                                <pre style="background:none; width:85%;">Observaciones: (indicar si se entrega con otros componentes,motivode préstamo,traslado o exclisión y
condiciones fisicas - en caso de préstamo o traslado)



</pre>

                                                <pre style="border:none; background:none"> Visto bueno:  ___________________________________                    ___________________________________
                                 Jefe de Departamento                                                         Dirección Ejecutiva</pre>


                                            </div>
                                        </div>
                                    </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <button id="descargar"  onclick="javascript:imprSelec('muestra')" class="btn btn-success">Descargar detalle</button> 
                                                
                                                <script type="text/javascript">
                                            function imprSelec(muestra)
                                            {
                                                var ficha = document.getElementById(muestra);
                                               
                                                var ventana = window.open("about :blank", "ventana", "width=711.628,height=692.105,top=0,left=0");
                                                ventana.document.open();
                                                ventana.document.write(ficha.outerHTML);
                                    
                                                ventana.document.close();
                                                ventana.print();
                                                ventana.focus();
                                                ventana.close();
                                            }
                                                </script>
                                                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                            <div class="span pull-left" style="margin-top:20px;">
                                                <div id="alerta" class="alert alert-success fade">
                                                    <button type="button" class="close" data-dismiss="alert">×</button>
                                                    <strong>¡Acciones completadas!</strong> Su descarga se iniciará en cualquier momento.
                                                </div>
                                            </div>
                                            <script>
                                                $("#detalle").on("click", function () {
                                                    $("#alerta").removeClass("in").show();
                                                    $("#alerta").delay(500).addClass("in").fadeOut(5000);
                                                });
                                            </script>
                                        </div>
                                    </div>
                                </div>
                            </div><!-- /.modal A CAMBIAR  -->
                        <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">¿Desea finalizar el préstamo?</h4>
                                    </div>
                   
                                    <div class="modal-footer">
                                            <div class="span">
                                                <button id="bt1" class="btn btn-danger" onclick="cambiarMano();">Finalizar préstamo</button>
                                                <button class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                            </div>
                                            <div class="span pull-left" style="margin-top:20px;">
                                                <div id="fpre"class="alert alert-success fade">
                                                    <button type="button" class="close" data-dismiss="alert">×</button>
                                                    <strong>¡Acciones completadas!</strong> El préstamo ha terminado.
                                                </div>
                                            </div>
                                            <script>
                                                function cambiarMano() {
                                                    document.getElementById('mano').className = 'glyphicon glyphicon-thumbs-up';
                                                }
                                            </script>
                                            <script>
                                                $("#bt1").on("click", function () {
                                                    $("#fpre").removeClass("in").show();
                                                    $("#fpre").delay(500).addClass("in").fadeOut(2000);
                                                });
                                            </script>
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
</body>
</html>
