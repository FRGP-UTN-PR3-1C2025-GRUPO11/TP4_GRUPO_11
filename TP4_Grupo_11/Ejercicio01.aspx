<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio01.aspx.cs" Inherits="TP4_Grupo_11.Ejercicio01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ejercicio 1</title>
    <style>
        body, select { background-color: black; color: white; font-family:Arial, Helvetica, sans-serif; font-size:large}

        .divInicio {
        display: grid;
        grid-template-columns: 200px 200px;
        gap: 15px;
        padding-top: 10px;
        text-transform: uppercase; 

        }

        .divFinal {
        display: grid;
        grid-template-columns: 200px 200px;
        gap: 10px;
        padding-top: 10px;
        text-transform: uppercase; 
        }
    </style>
</head>
<body>
    <form id="formularioEj01" runat="server">
        
        <asp:Label ID="lblDestinoInicio" Text="Destino Inicio" runat="server" style="text-decoration: underline; text-transform: uppercase; font-size: large"/>
        
        <div id="divDestinoInicio" class="divInicio">
            <asp:Label ID="lblProvincia" Text="Provincia:" runat="server" />
            <asp:DropDownList runat="server" ID="drpDownLstProvincia" CssClass="drpDownProvincia" AutoPostBack="True" OnSelectedIndexChanged="ddlProvinciaInicio_SelectedIndexChanged">
            </asp:DropDownList>
            
            <asp:Label ID="lblLocalidad" Text="Localidad:" runat="server" />
            <asp:DropDownList runat="server" ID="ddlLocalidad" CssClass="drpDownLocalidad" AutoPostBack="True" OnSelectedIndexChanged="ddlLocalidadInicio_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <br />
        <asp:Label ID="lblDestinoFinal" Text="Destino Final" runat="server" style="text-decoration: underline; text-transform: uppercase; font-size: large"/>


        <div id="divDestinoFinal" class="divFinal">
            <asp:Label ID="lblProvinciaFinal" runat="server" Text="Provincia: "></asp:Label>
            <asp:DropDownList ID="dpProvinciaFinal" runat="server"  CssClass="drpDownProvincia" OnSelectedIndexChanged="ddlProvinciaFinal_SelectedIndexChanged" AutoPostBack="True" >
            </asp:DropDownList>


            <asp:Label ID="lblLocalidadFinal" runat="server" Text="Localidad: "></asp:Label>
            <asp:DropDownList ID="ddlLocalidadFinal" runat="server" CssClass="drpDownLocalidad" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidadDestinoIndexChanged">
            </asp:DropDownList>
        </div>

    </form>
</body>
</html>
