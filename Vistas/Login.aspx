<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style7 {
            width: 96px;
        }
        .auto-style8 {
            width: 192px;
        }
        .auto-style9 {
            width: 96px;
            height: 31px;
        }
        .auto-style10 {
            width: 192px;
            height: 31px;
        }
        .auto-style11 {
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSesion" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Inicio de sesión"></asp:Label>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style10"></td>
                <td class="auto-style11"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="lblContraseña" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td class="auto-style8">
                    <asp:TextBox ID="txtContraseña" runat="server" TextMode ="Password" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style8">
                    <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" OnClick="btnIniciarSesion_Click" style="height: 26px" />
                </td>
                <td>
                    <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
