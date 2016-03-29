<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Errores.aspx.cs" Inherits="EXPEDIA.Errores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
<div class="container">
  <!-- Jumbotron -->
  <div class="jumbotron" style="background-color:darkred">
    <h1 style="color:white"><span class="glyphicon glyphicon-fire white"></span> Error 500</h1>
    <p class="lead" style="color:white">El servidor web retornó un error interno <em><span id="display-domain"></span></em>.</p>
    <a class="btn btn-default btn-lg text-center" href="index.aspx"><span class="green">Volver a un sitio seguro</span></a>
  </div>
</div>
<div class="container">
  <div class="body-content">
    <div class="row">
      <div class="col-md-6">
        <h2>¿Que sucedió?</h2>
        <p class="lead">El estado de un error 500 implica que el software del servidor web ejecuto incorrectamente una función.</p>
      </div>
      <div class="col-md-6">
        <h2>¿Que puedo hacer?</h2>
        <p class="lead">Si eres visitante</p>
        <p> No puedes hacer nada de momento. Si necesitas asistencia, por favor envía un correo electronico notificando el error. Nos disculpamos por este inconveniente.</p>
        <p class="lead">Si eres dueño del sistema</p>
         <p>Contactece con los con los administradores del servidor, ellos lograran solucionar el problema.</p>
     </div>
    </div>
  </div>
</div>
</body>
</html>
