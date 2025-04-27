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
            <asp:DropDownList ID="ddlProducto" runat="server" style="margin-left: 7px">
                <asp:ListItem Value="0">-- Seleccionar --</asp:ListItem>
                <asp:ListItem Value="1">-- Igual a: --</asp:ListItem>
                <asp:ListItem Value="2">-- Mayor a: --</asp:ListItem>
                <asp:ListItem Value="3">-- Menor a: --</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtProducto" runat="server" style="margin-left: 15px" Width="101px"></asp:TextBox>
            <br />
            <asp:Label ID="lblCantegoria" runat="server" Text="Cantegoria: " style="text-transform: uppercase; font-size: large"></asp:Label>
            <asp:DropDownList ID="ddlCantegoria" runat="server" Height="16px" style="margin-left: 15px" Width="108px">
               <asp:ListItem Value="0">-- Seleccionar --</asp:ListItem>
               <asp:ListItem Value="1">-- Igual a: --</asp:ListItem>
               <asp:ListItem Value="2">-- Mayor a: --</asp:ListItem>
               <asp:ListItem Value="3">-- Menor a: --</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtCantegoria" runat="server" style="margin-left: 15px" Width="101px"></asp:TextBox>
            <br />

            <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
        </div>
        <asp:GridView ID="GVEj2" runat="server">
        </asp:GridView>
    </form>
</body>
</html>