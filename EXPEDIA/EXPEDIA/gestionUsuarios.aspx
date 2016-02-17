<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gestionUsuarios.aspx.cs" Inherits="EXPEDIA.gestionUsuarios" %>

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
    <form runat="server">
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
                            <div class="pure-form pure-form-aligned" style="margin-top:5px;margin-left:20px;">
                                <fieldset>
                                    <div class="pure-control-group">
                                        <label for="nombre">Nombre</label>
                                        <asp:TextBox runat="server" ID="nombre_usuario" data-toggle="tooltip" data-placement="left" toolT="Este espacio debe proporcionar el nombre completo y apellidos de la persona a registrar, es requerido." />                
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="nombre">Primer Apellido</label>
                                        <asp:TextBox runat="server" ID="apellido_usuario1" data-toggle="tooltip" data-placement="left" toolT="Este espacio debe proporcionar el nombre completo y apellidos de la persona a registrar, es requerido." />                
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="nombre">Segundo Apellido</label>
                                        <asp:TextBox runat="server" ID="apellido_usuario2" data-toggle="tooltip" data-placement="left" toolT="Este espacio debe proporcionar el nombre completo y apellidos de la persona a registrar, es requerido." />                
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="cedula">Número de cédula</label>
                                        <asp:TextBox runat="server" ID="cedula_usuario" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." placeholder="#########" />
                                    </div>
    
                                    <div class="pure-control-group">
                                        <label for="contraseña">Contraseña</label>
                                        <asp:TextBox runat="server" ID="contrasena_usuario" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. "  TextMode="Password"/>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="correo">Correo electrónico</label>
                                        <asp:TextBox runat="server" ID="correo_usuario" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a registrar, es requerido." TextMode="Email" />
                                    </div>


                                    <fieldset class="pure-control-group">
                                        <div class="input-prepend">
                                            <label for="telefono">Número telefónico</label>
                                            <span class="add-on btn btn-default">506</span>
                                            <asp:TextBox  runat="server" ID="telefono_usuario" TextMode="Number"  placeholder="########" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número telefónico principal de la persona a registrar, es requerido." min="11111111" max="99999999"/>
                                        </div>
                                    </fieldset>
                                    <div class="pure-control-group">
                                        <label for="puesto">Ocupación</label>

                                        <asp:dropdownlist runat ="server"  ID="puesto" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a registrar, es requerido." >
                                          <asp:ListItem Selected="False">¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva. </asp:ListItem>

                                        </asp:dropdownlist>
                                        <a data-toggle="modal" data-target="#modalPuesto"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>

                                    <div class="pure-control-group">
                                        <label for="area">Área de servicio</label>
                                        <asp:dropdownlist runat ="server" ID="area" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a registrar, es requerido." >                                         
                                            <asp:ListItem Selected="False">¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                          
                                        </asp:dropdownlist>
                                        <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                    </div>
                                    <div class="pure-control-group">
                                        <label for="tipo_usuario">Usuario</label>
                                        <asp:dropdownlist runat ="server" ID="tipo_usuario" class="pure-input-1-2" data-toggle="tooltip" data-placement="left" title="En este espacio se debe representar el rol de la persona a registrar en el sistema." >
                                            <asp:ListItem Selected="False">Elige</asp:ListItem>
                                            <asp:ListItem Value="1">Administrador</asp:ListItem>
                                            <asp:ListItem Value="0">Consultas</asp:ListItem>
                                        </asp:dropdownlist>
                                    </div>
                                    <div class="pure-controls-group">
                                        <label for="Genero">Género</label>
                                        <div style="margin-left:104px;" class="btn-group"  data-toggle="buttons">
                                            <label class="btn btn-primary" >
                                                <asp:RadioButton runat="server"  name="options" ID="masculino" autocomplete="off" data-toggle="tooltip" data-placement="left" title="Oprime para definir el género masculino." Text="Masculino"/> 
                                            </label>
                                            <label class="btn btn-primary ">
                                                 <asp:RadioButton runat="server"   name="options" ID="femenino" autocomplete="off" data-toggle="tooltip" data-placement="left" title="Oprime para definir el género femenino. " Text="Femenino"/> 
                                            </label>
                                        </div>
                                    </div>

                                    <div class="pure-controls-group" style="margin-top:10px;">
                                        <asp:Button runat="server" CssClass="btn btn-success" OnClick=" Bt_Ingresar_Click" ID="Bt_Ingresar" Text="Registrar Usuario" />
                                        <div id="mensaje" style="display:none"><h3>Las acciones han sido realizadas con éxito.</h3></div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="Consultar">
                            <h1 style="text-align:center" id="titulo">Formulario de consultas</h1>
                            <div class="pure-form pure-form-aligned">
                                <div class="pure-control-group">
                                    <label for="cedula">Número de cédula</label>
                                    <asp:TextBox runat="server" ID="cedula_Consulta" data-toggle="tooltip" data-placement="left" title="Proporciona el número de cédula que desees consultar. Recuerda no ingresar guiones y tomar en cuenta los ceros del documento de identidad. " placeholder="#########" /></div>
                                <p>
                                    <asp:button runat="server" ID="Consulta" type="button" CssClass="btn btn-primary" Text="Consultar" onclick="cargarUsuario_Click"/>
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
                                               <input type="button" value="Habilitar modificación" class="btn btn-success" id="hab" onclick="habilitar()"/>
                                                <asp:Button runat="server"  ID="inhabilitar" CssClass="btn btn-danger" data-toggle="modal" data-target="#myModal" Text="Inhabilitar usuario"></asp:Button>
                                            </p>
                                            <div id="t" style="display:none"><h3>Formulario de modificación</h3></div>
                                            <script>
                                                $(document).ready(function () {
                                                    $("#hab").click(function () {
                                                        $('#t').show(2000, 'swing', function () {
                                                            //callback function after animation finished
                                                            $("#hab").attr('value', 'Formulario de modificacion');
                                                        });
                                                    });
                                                });
                                            </script>
                                        </div>
                                        <div class="pure-control-group" style="margin-top:30px;">
                                            <label for="nombre1">Nombre</label>
                                            <asp:TextBox runat="server" ID="nombre_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido."  />
                                        </div>

                                        <div class="pure-control-group" style="margin-top:30px;">
                                            <label for="nombre1">Primer Apellido</label>
                                            <asp:TextBox runat="server" ID="apellido_actualizar1" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido."  />
                                        </div>

                                        <div class="pure-control-group" style="margin-top:30px;">
                                            <label for="nombre1">Segundo Apellido</label>
                                            <asp:TextBox runat="server" ID="apellido_actualizar2" data-toggle="tooltip" title="En este espacio se debe proporcionar el nombre completo y apellidos de la persona a modificar, es requerido."  />
                                        </div>

                                        <div class="pure-control-group">
                                        <label for="cedula">Número de cédula</label>
                                        <asp:TextBox runat="server" ID="cedula_actualizar" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el número de cedula de la persona a registrar, omita guiones y todos los dígitos del documento de identidad, es requerido." placeholder="#########" />
                                    </div>

                                        <div class="pure-control-group">
                                            <label for="contraseña1">Contraseña</label>
                                             <asp:TextBox  runat="server"  ID="contrasena_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar la contraseña que el usuario desee para su eventual ingreso al sistema, es requerido. " TextMode="Password" value="Hola Mundo" />
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="correo1">Correo electrónico</label>
                                            <asp:TextBox ID="correo_actualizar"  runat="server" data-toggle="tooltip" title="En este espacio se debe proporcionar la dirección de correo electrónico de la persona a modificar, es requerido. "  TextMode="Email" />
                                        </div>

                                        <fieldset class="pure-control-group">
                                            <label for="telefono1">Número telefónico</label>
                                            <span class="add-on btn btn-default">506</span>
                                            <asp:TextBox runat="server" ID="telefono_actualizar" data-toggle="tooltip" title="En este espacio se debe proporcionar el número telefónico principal de la persona a modificar, es requerido." TextMode="Number" placeholder="########" min="11111111" max="99999999" disable />
                                        </fieldset>

                                        <div class="pure-control-group">
                                            <label for="puesto1">Ocupación</label>
                                            <asp:DropDownList runat="server" ID="puesto_actualizar" class="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe proporcionar el puesto en el cual se desempeña la persona a modificar, es requerido." disable>
                         
                                                <asp:ListItem Selected="False">¿La ocupación no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                            </asp:DropDownList>
                                           <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="area1">Área de servicio</label>
                                            <asp:DropDownList runat="server" ID="area_actualizar" class="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe proporcionar el área o unidad donde labora la persona a modificar, es requerido."  >

                                                <asp:ListItem Selected="False">¿El área no aparece? Haz uso el icono situado contiguo a esta categoría para proporcionar una nueva.</asp:ListItem>
                                            </asp:DropDownList>
                                            <a data-toggle="modal" data-target="#modalAreas"><span class="glyphicon glyphicon-wrench"></span></a>
                                        </div>

                                        <div class="pure-control-group">
                                            <label for="tipo1">Usuario</label>
                                            <asp:DropDownList runat="server" ID="tipo_actualizar" class="pure-input-1-2" data-toggle="tooltip" title="En este espacio se debe representar el rol de la persona a modificar en el sistema." disable>
                                                <asp:ListItem Value="0">Consultas</asp:ListItem>
                                                <asp:ListItem Value="1">Administrador</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="pure-controls-group">
                                            <label for="Genero1">Género </label>
                                            <div style="margin-left:104px;" class="btn-group" data-toggle="buttons">
                                                <label class="btn btn-primary disabled" id="rb1">
                                                    <asp:RadioButton runat="server"  name="options" ID="option1" autocomplete="off"  Text="Masculino"/> 
                                                </label>
                                                <label class="btn btn-primary" id="rb2">
                                                    <asp:RadioButton runat="server" name="options" ID="option2" autocomplete="off"  Text="Femenino"  /> 
                                                </label>
                                            </div>
                                        </div>
                                        <p style="margin-top:30px;">
                                            <asp:Button runat="server" CssClass="btn btn-success" id="enviar1" OnClick="Bt_actualizar_Click" style="display:block;float:left" Text="Realizar modificaciones" />
                                        </p>
                                        <br/>
                                            <div id="mensaje1" style="display:none;float:right"><h3>Las acciones han sido realizadas con éxito.</h3></div>

                                    </fieldset>
                                </div>
                            <script type="text/javascript">
                                function habilitar() {
                                    <%apellido_actualizar1.ReadOnly = false;%>
                                    document.getElementById('rb1').className = "btn btn-primary";
                                    document.getElementById('rb2').className = "btn btn-primary active";
                                    document.getElementById('area1').removeAttribute("readonly", false);
                                    document.getElementById('tipo1').removeAttribute("readonly", false);
                                    document.getElementById("apellido_actualizar1").removeAttribute("readonly", false);
                                    document.getElementById('nombre1').removeAttribute("readonly", false);
                                    document.getElementById('apellido_actualizar2').removeAttribute("readonly", false);
                                    document.getElementById('correo1').removeAttribute("readonly", false);
                                    document.getElementById('telefono1').removeAttribute("readonly", false);
                                    document.getElementById('nacimiento1').removeAttribute("readonly", false);
                                    document.getElementById('enviar1').removeAttribute("readonly", false);
                                    document.getElementById('a').className = '';
                                    document.getElementById('p').className = '';

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
                                        <asp:TextBox runat="server" TextMode="MultiLine"/>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <asp:Button runat="server"  CssClass="btn btn-danger" id="enviar2" Text="Inhabilitar"/>
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
                                                        <asp:TextBox runat="server" ID="idocupacion"  placeholder="OC-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificador que caracterice la ocupación que se esté registrando, es requerido. "/>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="ocupacion">Ocupación</label>
                                                        <asp:TextBox runat="server" ID="ocupacion"   placeholder="Programador" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la ocupación que se desea registrar, es requerido. "/>
                                                    </div>
                                                </fieldset>
                                        </div> <!-- /container -->
                                    </div>
                                    <div class="modal-footer">
                                        <div class="span">
                                            <asp:Button runat="server" ID="btn"  class="btn btn-success" Text="Registrar ocupacion"/>
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
                                                        <asp:TextBox runat="server" ID="idareas"   placeholder="AR-001" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar un identificado que caracterice el área o unidad que se esté registrando, es requerido. "/>
                                                    </div>
                                                    <div class="input-prepend">
                                                        <label for="area57">Área</label>
                                                        <asp:TextBox runat="server" ID="area57"   placeholder="Recursos Humanos" data-toggle="tooltip" data-placement="left" title="En este espacio se debe proporcionar el nombre de la área que se desea registrar, es requerido. "/>
                                                    </div>
                                                </fieldset>
                                            </div> <!-- /container -->
                                        </div>
                                        <div class="modal-footer">
                                            <div class="span">
                                                <asp:Button runat="server" ID="bt1" CssClass="btn btn-success" Text="Registrar área"/>
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
        </form>
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
            $("#Bt_Ingresar").click(function () {
                $('#mensaje').show(2000, 'swing', function () {
                    //callback function after animation finished
                    $("Bt_Ingresar").attr('value', 'Las acciones han sido realizadas correctamente');
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
