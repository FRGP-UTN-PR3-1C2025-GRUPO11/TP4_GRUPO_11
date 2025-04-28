<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio03b.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio03b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style>
        .tabla {
            margin: 30px 30px;
        }

    </style>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Listado de libros"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTema" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
            <div class="tabla">
                <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="true" />
            </div>
            <asp:LinkButton ID="lbVolver" runat="server" PostBackUrl="~/Ejercicio03.aspx">Consultar otro tema</asp:LinkButton>
        </div>
    </form>
</body>
</html>
