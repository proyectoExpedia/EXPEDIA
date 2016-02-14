﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionUsuarios.aspx.cs" Inherits="EXPEDIA.gestionUsuarios" %>

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
                <h3 class="panel-title">Gestión de usuarios</h3>
            </div>
            <div class="panel-body">
                <div class="tabs-example">
                    <ul id="myTab" class="nav nav-tabs">
                        <li class="active"><a href="#Ingresar" data-toggle="tab">Registro de usuarios <span class="glyphicon glyphicon-plus-sign"></span></a></li>
                        <li><a href="#Consultar" data-toggle="tab">Control de usuarios <span class="glyphicon glyphicon-question-sign"></span><span class="glyphicon glyphicon-minus-sign"></span><span class="glyphicon glyphicon-ok-sign"></span></a></li>
                        <a style="float:right" href="mainAdministrador.aspx" class="btn"><span class="glyphicon glyphicon-menu-left"></span>  Atrás</a>
                    </ul>
                    <div id="myTabContent" class="tab-content">
                        <div  class="tab-pane fade in active" id="Ingresar">
                            <h1 style="text-align:center">Formulario de registro</h1>
                            <form class="pure-form pure-form-aligned" style="margin-top:5px;margin-left:20px;">
                                <fieldset>
                                    <div class="pure-control-group">
                                        <label for="nombre">Nombre completo</label>
                                        <input id="nombre" data-toggle="tooltip" data-placement="left" title="Este espacio debe proporcionar el nombre completo y apellidos de la persona a registrar, es requerido." type="text" required>                
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="cedula">Número de cédula</label>
                                        <input id="cedula" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." type="text" placeholder="#########" required>
                                    </div>
                                    <button type="button" onclick="myFunction()">Insert option</button>

                                    <script>
function myFunction() {
    var x = document.getElementById("puesto");
    var option = document.createElement("option");
    option.text = "Kiwi";
    x.add(option);
}
                                    </script>
                                    <div class="pure-control-group">
                                        <label for="contraseña">Contraseña</label>
                                        <input id="contraseña" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. " type="password" required>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="correo">Correo electrónico</label>
                                        <input id="correo" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a registrar, es requerido." type="email" required>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="nacimiento">Fecha de nacimiento</label>
                                        <input id="nacimiento" type="text" placeholder="Fecha de nacimiento" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la fecha de nacimiento de la persona a registrar.">
                                        <script>$("#nacimiento").datepicker();</script>
                                    </div>

                                    <fieldset class="pure-control-group">
                                        <div class="input-prepend">
                                            <label for="telefono">Número telefónico</label>
                                            <span class="add-on btn btn-default">506</span>
                                            <input id="telefono" required type="number" placeholder="########" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal de la persona a registrar, es requerido." min="11111111" max="99999999">
                                        </div>
                                    </fieldset>
                                    <div class="pure-control-group">
                                        <label for="puesto">Ocupación</label>
                                        <select id="puesto" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a registrar, es requerido." required>
                                            <option>Elige</option>
                                            <option>Juez</option>
                                            <option>Abogado(a)</option>
                                            <option>Informático</option>
                                            <option disabled>¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="area">Área de servicio</label>
                                        <select id="area" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a registrar, es requerido." required>                                         
                                            <option>Elige</option>
                                            <option>Recursos Humanos</option>
                                            <option>Departamento Legal</option>
                                            <option>Biblioteca</option>
                                            <option disabled>¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                        </select>
                                        <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>
                                    <div class="pure-control-group">
                                        <label for="usuario">Usuario</label>
                                        <select id="usuario" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe representar el rol de la persona a registrar en el sistema." required>
                                            <option>Elige</option>
                                            <option>Administrador</option>
                                            <option>Consultas</option>
                                        </select>
                                    </div>
                                    <div class="pure-controls-group">
                                        <label for="Genero">Género</label>
                                        <div style="margin-left:104px;" class="btn-group"  data-toggle="buttons">
                                            <label class="btn btn-primary" >
                                                <input type="radio" name="options" id="option1" autocomplete="off" data-toggle="tooltip" data-placement="left" title="Oprime para definir el género masculino."> Masculino
                                            </label>
                                            <label class="btn btn-primary ">
                                                <input type="radio" name="options" id="option2" autocomplete="off" data-toggle="tooltip" data-placement="left" title="Oprime para definir el género femenino. "> Femenino
                                            </label>
                                        </div>
                                    </div>

                                    <div class="pure-controls-group" style="margin-top:10px;">
                                        <button class="btn btn-success" id="enviar">Registrar Usuario</button>
                                        <div id="mensaje" style="display:none"><h3>Las acciones han sido realizadas con éxito.</h3></div>
                                    </div>
                                </fieldset>
                            </form>
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                            <h1 style="text-align:center" id="titulo">Formulario de consultas</h1>
                            <div class="pure-form pure-form-aligned">
                                <div class="pure-control-group">
                                    <label for="cedula">Número de cédula</label>
                                    <input id="cedula" data-toggle="tooltip" data-placement="left" title="Proporciona el número de cédula que desees consultar. Recuerda no ingresar guiones y tomar en cuenta los ceros del documento de identidad. " type="text" placeholder="#########" required></div>
                                <p>
                                    <button type="button" class="btn btn-primary" onclick="mostrar()">Consultar</button>
                                 </p>
                                <script type="text/javascript">
                                    function mostrar() {
                                        document.getElementById('oculto').style.display = 'block';
                                    }

                                </script>
                            </div>

                                <div id="oculto" class="pure-form pure-form-aligned" style="display:none" ><!--Esto realmente es un form-->
                                    <fieldset>
                                        <div class="pure-control-group" style="margin-top:40px;">
                                            <p>
                                                <button class="btn btn-success" id="hab" onclick="habilitar();">Habilitar modificación</button>
                                                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#myModal">Inhabilitar usuario</button>
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
                                        <div class="pure-control-group" style="margin-top:30px;">
                                            <label for="nombre1">Nombre completo</label>
                                            <input id="nombre1" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido." required value=" manuela solorzano quiel" type="text" readonly>
                                        </div>
                                        <div class="pure-control-group">
                                            <label for="contraseña1">Contraseña</label>
                                            <input id="contraseña1" data-toggle="tooltip" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. " required type="password" value="Hola Mundo" readonly>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="correo1">Correo electrónico</label>
                                            <input id="correo1" data-toggle="tooltip" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a modificar, es requerido. " required type="email" value="msq2000@mail.com" readonly>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="nacimiento1">Fecha de nacimiento</label>
                                            <input id="nacimiento1" value="12/11/2015" type="text" placeholder="Fecha de nacimiento" data-toggle="tooltip" title="En este espacio se debe proporcionar la fecha de nacimiento de la persona a modificar." disabled>
                                            <script>$("#nacimiento1").datepicker();</script>
                                        </div>

                                        <fieldset class="pure-control-group">
                                            <label for="telefono1">Número telefónico</label>
                                            <span class="add-on btn btn-default">506</span>
                                            <input id="telefono1" data-toggle="tooltip" title="En este espacio se debe proporcionar el número telefónico principal de la persona a modificar, es requerido." required type="number" value="83420113" placeholder="########" min="11111111" max="99999999" readonly>
                                        </fieldset>

                                        <div class="pure-control-group">
                                            <label for="puesto1">Ocupación</label>
                                            <select id="puesto1" class="pure-input-1-2" disabled required data-toggle="tooltip" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a modificar, es requerido.">
                                                <option>Juez</option>
                                                <option>Abogado(a)</option>
                                                <option>Informático</option>
                                                <option disabled>¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a id="p" data-toggle="modal" class="label disabled" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="area1">Área de servicio</label>
                                            <select id="area1" class="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a modificar, es requerido." required disabled>
                                                <option>Departamento Legal</option>
                                                <option>Recursos Humanos</option>
                                                <option>Biblioteca</option>
                                                <option disabled>¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</option>
                                            </select>
                                            <a id="a" data-toggle="modal" class="label disabled" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="tipo1">Usuario</label>
                                            <select id="tipo1" class="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe representar el rol de la persona a modificar en el sistema." required disabled>
                                                <option>Consultas</option>
                                                <option>Administrador</option>
                                            </select>
                                        </div>

                                        <div class="pure-controls-group">
                                            <label for="Genero1">Género </label>
                                            <div style="margin-left:104px;" class="btn-group" data-toggle="buttons">
                                                <label class="btn btn-primary disabled" id="rb1">
                                                    <input type="radio" name="options" id="option1" autocomplete="off"> Masculino
                                                </label>
                                                <label class="btn btn-primary" id="rb2">
                                                    <input type="radio" name="options" id="option1" autocomplete="off"> Femenino
                                                </label>
                                            </div>
                                        </div>
                                        <p style="margin-top:30px;">
                                            <button class="btn btn-success" id="enviar1" style="display:none;float:left" type="button">Realizar modificaciones</button>
                                        </p>
                                        <br/>
                                            <div id="mensaje1" style="display:none;float:right"><h3>Las acciones han sido realizadas con éxito.</h3></div>

                                    </fieldset>
                                </div>
                            <script type="text/javascript">
                                function habilitar() {
                                    document.getElementById('rb1').className = "btn btn-primary";
                                    document.getElementById('rb2').className = "btn btn-primary active";
                                    document.getElementById('area1').disabled = false;
                                    document.getElementById('tipo1').disabled = false;
                                    document.getElementById('puesto1').disabled = false;
                                    document.getElementById('nombre1').readOnly = false;
                                    document.getElementById('contraseña1').readOnly = false;
                                    document.getElementById('correo1').readOnly = false;
                                    document.getElementById('telefono1').readOnly = false;
                                    document.getElementById('nacimiento1').disabled = false;
                                    document.getElementById('enviar1').style.display = 'block';
                                    document.getElementById('a').className = '';
                                    document.getElementById('p').className= '';

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
                                        <textarea></textarea>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <button type="button" class="btn btn-danger" id="enviar2">Inhabilitar</button>
                                    </div>
                                </div><!-- /.modal-content -->
                            </div><!-- /.modal-dialog -->
                        </div><!-- /.modal -->
                        <div class="modal fade" id="modalPuesto" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 class="modal-title" style="text-align:center" id="exampleModalLabel">Nueva ocupación</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="container">
                                            <div class="pure-form pure-form-aligned">
                                                <fieldset class="pure-control-group">
                                                    <div class="input-prepend">
                                                        <label for="idocupacion">Identificador de la ocupación</label>
                                                        <input id="idocupacion" required type="text" placeholder="OC-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice la ocupación que se esté registrando, es requerido. ">
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="ocupacion">Ocupación</label>
                                                        <input id="ocupacion" required type="text" placeholder="Programador" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la ocupación que se desea registrar, es requerido. ">
                                                    </div>
                                                </fieldset>
                                        </div> <!-- /container -->
                                    </div>
                                    <div class="modal-footer">
                                        <div class="span">
                                            <button id="btn" onclick="Guardar(1)" class="btn btn-success">Registrar ocupacion</button>
                                            <button onclick="Mostrar_Info_Usuario(1)" class="btn btn-default" data-dismiss="modal">Cerrar</button>
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
                        <div class="modal fade" id="modalAreas" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
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
                                                        <input id="idareas" required type="text" placeholder="AR-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificado que caracterice el área o unidad que se esté registrando, es requerido. ">
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area57">Área</label>
                                                        <input id="area57" required type="text" placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, es requerido. ">
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <button onclick="Guardar(2)" id="bt1" class="btn btn-success">Registrar área</button>
                                                <button onclick="Mostrar_Info_Usuario(2)" class="btn btn-default" data-dismiss="modal">Cerrar</button>
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
            case 1: { localStorage["Ocupacion"] = document.getElementById("ocupacion").value; break; }
            case 2: { localStorage["Area"] = document.getElementById("area57").value; break; }
                   }
        }


        function Mostrar_Info_Usuario(x)
        {

            switch(x){
                case 1: {
                   
                    var option = document.createElement("option");
                    option.text = localStorage["Ocupacion"].toString();
                    document.getElementById("puesto").add(option);
                    Mostrar_Info_Usuario(3);
                    break;
                }
                case 2: {var option1 = document.createElement("option");
                    option1.text = localStorage["Area"];
                    document.getElementById("area").add(option1);
                    Mostrar_Info_Usuario(4);
                    break;
                }
                case 3: {
                    var option = document.createElement("option");
                    option.text = localStorage["Ocupacion"].toString();
                    document.getElementById("puesto1").add(option);
                    break;
                }
                case 4: {
                    var option1 = document.createElement("option");
                    option1.text = localStorage["Area"];
                    document.getElementById("area1").add(option1); break;
                }
        }

}</script>
</body>
</html>
