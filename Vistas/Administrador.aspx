<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="Vistas.Administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 94px;
        }
        .auto-style3 {
            width: 94px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Usuario:<asp:Label ID="lblUsuario" runat="server"></asp:Label>
&nbsp;<table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpPacientes" runat="server" NavigateUrl="~/ABMLPacientes.aspx">GESTION DE PACIENTES</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpMedicos" runat="server" NavigateUrl="~/ABMLMedicos1.aspx">GESTION DE MÉDICOS</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpTurnos" runat="server" NavigateUrl="~/Turnos.aspx">ASIGNAR TURNOS</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hlAltaPacientes" runat="server" NavigateUrl="~/AltaPacientes.aspx">ALTA PACIENTES</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hlAltaMedicos" runat="server" NavigateUrl="~/AltaMedicos.aspx">ALTA MEDICOS</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hpInformes" runat="server" NavigateUrl="~/Informes.aspx">INFORMES</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <asp:HyperLink ID="hlAdministrador" runat="server" NavigateUrl="~/Login.aspx">Cerrar Sesion</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
