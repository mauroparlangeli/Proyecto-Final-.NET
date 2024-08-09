<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedicos.aspx.cs" Inherits="Vistas.AltaMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 85px;
        }
        .auto-style4 {
            width: 330px;
        }
        .auto-style5 {
            width: 136px;
        }
        .auto-style7 {
            width: 120px;
        }
        .auto-style8 {
            width: 307px;
        }
        .auto-style9 {
            width: 239px;
        }
        .auto-style10 {
            width: 40px;
        }
        .auto-style11 {
            height: 25px;
        }
        .auto-style12 {
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
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">DNI:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Dni" runat="server" ControlToValidate="txtDni" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">Fecha de nacimiento:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                        &nbsp;<asp:RegularExpressionValidator ID="RevFecha" runat="server" ControlToValidate="txtFechaNacimiento" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$" ValidationGroup="AgregarMedico">Fecha no valida</asp:RegularExpressionValidator>
                    &nbsp;<asp:RequiredFieldValidator ID="Rfv_txtFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">Usuario:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TxtUsuario" runat="server" ValidationGroup="Crear Usuario"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RfvUsuario" runat="server" ControlToValidate="TxtUsuario" ValidationGroup="Crear Usuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">Nombre:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">Localidad:</td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddlLocalidad" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_ddl_Localidad" runat="server" ControlToValidate="ddlLocalidad" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">Contraseña:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TxtContraseña" runat="server" ValidationGroup="Crear Usuario" TextMode="Password"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RfvContraseña" runat="server" ControlToValidate="TxtContraseña" ValidationGroup="Crear Usuario"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">Apellido:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Apellido" runat="server" ControlToValidate="txtApellido" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">Correo:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Correo" runat="server" ControlToValidate="txtCorreo" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">Repetir contraseña:</td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TxtContraseña2" runat="server" ValidationGroup="Crear Usuario" TextMode="Password"></asp:TextBox>
&nbsp;<asp:CompareValidator ID="CvContraseña" runat="server" ControlToCompare="TxtContraseña" ControlToValidate="TxtContraseña2" ValidationGroup="Crear Usuario">*</asp:CompareValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">Sexo:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddlSexo" runat="server">
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style5">Telefono</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Telefono" runat="server" ControlToValidate="txtTelefono" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">Medicos:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="DdlMedicos" runat="server">
                        </asp:DropDownList>
&nbsp;</td>
                    <td>
                        <asp:Button ID="BtnCrearUsuario" runat="server" OnClick="BtnCrearUsuario_Click" Text="Crear Usuario" ValidationGroup="Crear Usuario" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">Nacionalidad:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="txtNacionalidad" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Nacionalidad" runat="server" ValidationGroup="AgregarMedico" ControlToValidate="txtNacionalidad">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">Especialidad</td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddl_especialidades" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">
                        <asp:Label ID="Lbl_CrearUsuario" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">Direccion: </td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RfvDireccion" runat="server" ControlToValidate="TxtDireccion" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style5">ID Usuario:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtIdUsuario" runat="server" Height="21px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_IdUsuario" runat="server" ControlToValidate="txtIdUsuario" ValidationGroup="AgregarMedico">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="AgregarMedico" />
                    </td>
                    <td class="auto-style5">
                        HORARIOS:</td>
                    <td class="auto-style8">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="LblAltaMedico" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="Ddl_MedicoHorario" runat="server" OnSelectedIndexChanged="Ddl_MedicoHorario_SelectedIndexChanged" ValidationGroup="AgregarHorarios">
                        </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="Rfv_Ddl_MedicoHorario" runat="server" ControlToValidate="Ddl_MedicoHorario" ValidationGroup="AgregarHorarios">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>Dias Semana:</td>
                    <td>
&nbsp;<asp:CheckBoxList ID="Cbl_Dias" runat="server" ValidationGroup="AgregarHorarios">
                            <asp:ListItem Value="1">Lunes</asp:ListItem>
                            <asp:ListItem Value="2">Martes</asp:ListItem>
                            <asp:ListItem Value="3">Miercoles</asp:ListItem>
                            <asp:ListItem Value="4">Jueves</asp:ListItem>
                            <asp:ListItem Value="5">Viernes</asp:ListItem>
                            <asp:ListItem Value="6">Sabado</asp:ListItem>
                            <asp:ListItem Value="0">Domingo</asp:ListItem>
                        </asp:CheckBoxList>
&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style11">
                        <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Administrador.aspx">&lt;- Volver</asp:HyperLink>
                    </td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11">Hora Inicio:</td>
                    <td class="auto-style11">
                        <asp:DropDownList ID="Ddl_HoraInicio" runat="server" ValidationGroup="AgregarHorarios">
                        </asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="Rfv_Ddl_HoraInicio" runat="server" ControlToValidate="Ddl_HoraInicio" ValidationGroup="AgregarHorarios">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>Hora Fin:</td>
                    <td>
                        <asp:DropDownList ID="Ddl_HoraFin" runat="server" ValidationGroup="AgregarHorarios">
                        </asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="Rfv_Ddl_HoraFin" runat="server" ControlToValidate="Ddl_HoraFin" ValidationGroup="AgregarHorarios">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11">
                        <asp:Button ID="BtnAgregarHorarios" runat="server" OnClick="BtnAgregarHorarios_Click" Text="Agregar Horarios" ValidationGroup="AgregarHorarios" />
                    </td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                    <td class="auto-style12"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
