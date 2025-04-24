<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio01.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 1</title>
    <style>
        .divInicio {
        display: flex;
        gap: 10px;
        padding-top: 10px;
        text-transform: uppercase; 
        }
        .divInicio > .drpDownProvincia {
        width: 140px;
        }
        .divInicio > .drpDownLocalidad {
          width: 140px;
        }  
    </style>
</head>
<body>
    <form id="formularioEj01" runat="server">
            <asp:Label ID="lblDestinoInicio" Text="Destino Inicio" runat="server" style="text-decoration: underline; text-transform: uppercase; font-size: large"/>
        <div id="divDestinoInicio" class="divInicio">
            <asp:Label ID="lblProvincia" Text="Provincia:" runat="server" />
            <asp:DropDownList runat="server" ID="drpDownLstProvincia" CssClass="drpDownProvincia" AutoPostBack="True" OnSelectedIndexChanged="drpDownLstProvincia_SelectedIndexChanged">
            </asp:DropDownList>
            
            <asp:Label ID="lblLocalidad" Text="Localidad:" runat="server" />
            <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="drpDownLocalidad">
            </asp:DropDownList>
            <br />
        </div>
            <asp:Label ID="Label1" runat="server" Font-Underline="True" Text="DESTINO FINAL"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="PROVINCIA: "></asp:Label>
            <asp:DropDownList ID="dpProvinciaFinal" runat="server" AutoPostBack="True" >
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
    </form>
</body>
</html>
