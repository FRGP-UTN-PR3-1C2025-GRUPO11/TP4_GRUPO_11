<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio02.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio2</title>
</head>
 
<body>
    <form id="formularioEj02" runat="server">
        <div>
            <asp:Label ID="lblProducto" runat="server" Text="IdProducto: " style="text-transform: uppercase; font-size: large"></asp:Label>
            <asp:DropDownList ID="ddlProducto" runat="server" style="margin-left: 7px"></asp:DropDownList>
            <asp:TextBox ID="txtProducto" runat="server" style="margin-left: 15px" Width="101px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
