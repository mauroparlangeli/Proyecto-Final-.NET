<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="Vistas.Turnos" %>

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
            width: 130px;
        }
        .auto-style3 {
            width: 130px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 130px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 130px;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lbl_Nombre_Usuario" runat="server"></asp:Label>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Asignación de Turnos Médicos"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Paciente:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlPaciente" runat="server" ValidationGroup="AsignarTurno">
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="Rfv_Ddl_Paciente" runat="server" ControlToValidate="ddlPaciente" InitialValue="--Seleccionar--" ValidationGroup="AsignarTurno">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style7">Especialidad:</td>
                <td class="auto-style8">
                    <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged1" ValidationGroup="AsignarTurno">
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="Rfv_ddlEspecialidad" runat="server" ControlToValidate="ddlEspecialidad" InitialValue="--Seleccionar--" ValidationGroup="AsignarTurno">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style5">Médico:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" ValidationGroup="AsignarTurno">
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="Rfv_ddlMedico" runat="server" ControlToValidate="ddlMedico" InitialValue="--Seleccionar--" ValidationGroup="AsignarTurno">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td>Dia:</td>
                <td>
                    <asp:DropDownList ID="DdlDia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlDia_SelectedIndexChanged" ValidationGroup="AsignarTurno">
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="Rfv_DdlDia" runat="server" ControlToValidate="DdlDia" InitialValue="--Seleccionar--" ValidationGroup="AsignarTurno">*</asp:RequiredFieldValidator>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Horario:</td>
                <td class="auto-style6">
                    <asp:DropDownList ID="DdlHorario" runat="server" ValidationGroup="AsignarTurno">
                    </asp:DropDownList>
                &nbsp;<asp:RequiredFieldValidator ID="Rfv_DdlHorario" runat="server" ControlToValidate="DdlHorario" InitialValue="--Seleccionar--" ValidationGroup="AsignarTurno">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style2">Fecha:</td>
                <td>
                    <asp:DropDownList ID="DdlFechas" runat="server">
                        <asp:ListItem>--Seleccionar--</asp:ListItem>
                    </asp:DropDownList>
                &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnAsignar" runat="server" OnClick="btnAsignar_Click" Text="Asignar Turno" ValidationGroup="AsignarTurno" />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:HyperLink ID="hlTurnos" runat="server" NavigateUrl="~/Administrador.aspx">&lt;- Volver</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
