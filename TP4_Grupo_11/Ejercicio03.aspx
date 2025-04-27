<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio03.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Selecionar Tema:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:LinkButton ID="lbTemas" runat="server">Ver Temas</asp:LinkButton>
        </div>
    </form>
</body>
</html>
