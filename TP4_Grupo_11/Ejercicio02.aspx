<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio02.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio2</title>
</head>
 
<body>
    <style>
        .filtro {
            display: inline-grid;
            width: 700px;
            grid-template-columns: 100px 100px 300px 200px;
            gap: 15px;
        }
        .botones {
            display: flex;
            gap: 15px;
            flex-direction: row;
            justify-content: center;
            width: 600px;
            margin: 30px 30px;
        }
        .validador {
            color: red;
            font-weight: bolder;
        }
    </style>
    <form id="formularioEj02" runat="server">
        <div class="filtro">

            <asp:Label ID="lblProducto" runat="server" Text="IdProducto: "></asp:Label>
            <asp:DropDownList ID="ddlProducto" runat="server">
                <asp:ListItem Value="1">-- Igual a: --</asp:ListItem>
                <asp:ListItem Value="2">-- Mayor a: --</asp:ListItem>
                <asp:ListItem Value="3">-- Menor a: --</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revIdProducto" runat="server" ErrorMessage="Debe ser un valor numérico" ValidationExpression="^[0-9,$]*$" ControlToValidate="txtProducto" CssClass="validador"></asp:RegularExpressionValidator>
            
            <asp:Label ID="lblCategoria" runat="server" Text="IdCategoria: "></asp:Label>
            <asp:DropDownList ID="ddlCategoria" runat="server">
               <asp:ListItem Value="1">-- Igual a: --</asp:ListItem>
               <asp:ListItem Value="2">-- Mayor a: --</asp:ListItem>
               <asp:ListItem Value="3">-- Menor a: --</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="revIdCategoria" runat="server" ErrorMessage="Debe ser un valor numérico" ValidationExpression="^[0-9,$]*$" ControlToValidate="txtCategoria" CssClass="validador"></asp:RegularExpressionValidator>
            
        </div>
        <div class="botones">
            <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
            <asp:Button ID="btnQuitarFiltro" runat="server" Text="Quitar Filtro" OnClick="btnBorrarFiltro"/>
        </div>
        <asp:GridView ID="GVEj2" runat="server">
        </asp:GridView>
    </form>
</body>
</html>