<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio03.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style>
        a {
            display: block;
            margin-top: 20px;
        }
        div {
            padding-bottom: 20px;
        }
    </style>
    <form id="formularioEj3" runat="server">
        <div>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Selecionar Tema:"></asp:Label>
&nbsp;
            <asp:DropDownList ID="ddlTemas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTemas_SelectedIndexChanged" ValidationGroup="Grupo1">
            </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfvTema" runat="server" ControlToValidate="ddlTemas" InitialValue="0" ValidationGroup="Grupo1">Debe seleccionar un tema</asp:RequiredFieldValidator>
        </div>
            <asp:Button ID="btnVerLibros" runat="server" Text="Ver libros" OnClick="btnVerLibros_Click" ValidationGroup="Grupo1" />
    </form>
</body>
</html>
