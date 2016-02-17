<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebaTag.aspx.cs" Inherits="EXPEDIA.PruebaTag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <%--Codigo JavaScript--%>
    <script lang="javascript" type="text/javascript">
    function fnAceptar() {
        alert('El Contenido del TextBox es: ' + document.getElementById("txtNombre").value);
        document.getElementById("txtNombre").value = '';
    }
    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:TextBox ID="Ingresa" runat="server"></asp:TextBox>
                    <asp:Button ID="BtnBuscar" OnClick="BtnBuscar_Click" runat="server" Text="Buscar" />
                    <asp:TextBox ID="Muestra" runat="server"></asp:TextBox>
                </div>


                 <div>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"/>
        <br/>
        <asp:Label ID="lblResultado" runat="server" ></asp:Label>
        </div>


        </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
