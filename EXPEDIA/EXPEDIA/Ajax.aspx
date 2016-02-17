<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ajax.aspx.cs" Inherits="EXPEDIA.Ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:TextBox ID="Ingresa" runat="server"></asp:TextBox>
                <asp:Button ID="BtnAjax" OnClick="BtnAjax_Click" runat="server" Text="Button" />
                <asp:TextBox ID="Devuelve" runat="server"></asp:TextBox>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
