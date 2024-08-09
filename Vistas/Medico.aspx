<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medico.aspx.cs" Inherits="Vistas.Medico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

    .auto-style6 {
        width: 100%;
    }
    .auto-style7 {
        width: 224px;
    }
    .auto-style9 {
        width: 292px;
    }
    .auto-style10 {
        width: 224px;
        height: 42px;
    }
    .auto-style11 {
        height: 42px;
    }
        .auto-style12 {
            width: 224px;
            height: 23px;
        }
        .auto-style13 {
            width: 292px;
            height: 23px;
        }
        .auto-style14 {
            height: 23px;
        }
        .auto-style15 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Medico:
            <asp:Label ID="Lbl_Medico" runat="server"></asp:Label>
            <br />
            <table class="auto-style6">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblTurnos" runat="server" Font-Bold="True" Font-Size="20pt" Text="Listado de turnos"></asp:Label>
                    </td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="txtTurnos" runat="server" Width="284px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_txtFiltrar" runat="server" ControlToValidate="txtTurnos" ErrorMessage="Debe ingresar un paciente"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnMostrarTodos" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar Todos" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10"></td>
                    <td class="auto-style11" colspan="2">
                        <asp:GridView ID="grdTurnosMed" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="grdTurnosMed_SelectedIndexChanging" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField HeaderText="TURNO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_NroTurno" runat="server" Text='<%# Bind("Nro_Turno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI PACIENTE">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_DniPaciente" runat="server" Text='<%# Bind("DNI_Paciente") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FECHA TURNO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Fecha" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HORARIO TURNO">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Horario" runat="server" Text='<%# Bind("horario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="OBSERVACIONES">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Observaciones" runat="server" Text='<%# Bind("observaciones") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ASISTENCIA">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_it_Asistencia" runat="server" Text='<%# Bind("Asistencia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style14"></td>
                </tr>
                <tr>
                    <td class="auto-style15">Numero Turno:
                        <asp:Label ID="LblSeleccion" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style15">
                        <asp:Button ID="BtnAsistencia" runat="server" OnClick="BtnAsistencia_Click" Text="Asistencia" CausesValidation="False" />
                    </td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
        <asp:TextBox ID="TxtObservaciones" runat="server" Height="133px" Width="400px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td><asp:Button ID="BtnActualizarObservacion" runat="server" OnClick="BtnActualizarObservacion_Click" Text="Actualizar Observacion" CausesValidation="False" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:HyperLink ID="hlMedico" runat="server" NavigateUrl="~/Login.aspx">Cerrar Sesion</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
