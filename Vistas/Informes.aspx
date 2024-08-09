<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vistas.Informes" %>

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
            width: 30px;
        }
        .auto-style4 {
            width: 100px;
        }
        .auto-style5 {
            width: 148px;
        }
        .auto-style6 {
            width: 120px;
        }
        .auto-style7 {
            width: 28px;
        }
        .auto-style15 {
            width: 427px;
        }
        .auto-style18 {
            width: 427px;
            height: 22px;
        }
        .auto-style16 {
            width: 427px;
            height: 23px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lbl_Nombre_Usuario" runat="server"></asp:Label>
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style6">
                        <asp:LinkButton ID="LBtnPromedioEdad" runat="server" OnClick="LBtnPromedioEdad_Click">Promedio edad pacientes</asp:LinkButton>
                    </td>
                    <td class="auto-style5">
                        <asp:LinkButton ID="CantidadPacientesPorLocalidad" runat="server" OnClick="CantidadPacientesPorLocalidad_Click">Cantidad Pacientes por localidad</asp:LinkButton>
                    </td>
                    <td class="auto-style4">
                        <asp:LinkButton ID="lb_PacientesEliminados" runat="server" OnClick="lb_PacientesEliminados_Click">Pacientes dados de baja</asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton ID="lb_MedicosEliminados" runat="server" OnClick="lb_MedicosEliminados_Click">Medicos dados de baja</asp:LinkButton>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                </table>
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="GrdInformes" runat="server">
        </asp:GridView>
                    <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style6">
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style15">REPORTES</td>
                        </tr>
                        <tr>
                            <td class="auto-style18">Buscar Turnos del Médico:&nbsp;&nbsp;
                                <asp:DropDownList ID="ddl_Medicos" runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_BuscarTurnos" runat="server" Height="26px" OnClick="btn_BuscarTurnos_Click" Text="Buscar" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16"></td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>
                        <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Administrador.aspx">&lt;- Volver</asp:HyperLink>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
&nbsp;</form>
</body>
</html>
