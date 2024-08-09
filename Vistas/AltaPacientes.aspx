<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPacientes.aspx.cs" Inherits="Vistas.AltaPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style6 {
            height: 23px;
            width: 50px;
        }
        .auto-style4 {
            height: 23px;
            width: 90px;
        }
        .auto-style8 {
            height: 23px;
            width: 150px;
        }
        .auto-style21 {
            height: 23px;
            width: 191px;
        }
        .auto-style18 {
            height: 23px;
            width: 120px;
        }
        .auto-style24 {
            height: 23px;
            width: 160px;
        }
        .auto-style26 {
            height: 23px;
            width: 253px;
        }
        .auto-style19 {
            height: 23px;
        }
        .auto-style5 {
            width: 50px;
        }
        .auto-style3 {
            width: 90px;
        }
        .auto-style7 {
            width: 150px;
        }
        .auto-style20 {
            width: 191px;
        }
        .auto-style16 {
            width: 120px;
        }
        .auto-style22 {
            width: 160px;
        }
        .auto-style27 {
            width: 253px;
        }
        .auto-style11 {
            width: 50px;
            height: 25px;
        }
        .auto-style12 {
            width: 90px;
            height: 25px;
        }
        .auto-style13 {
            width: 150px;
            height: 25px;
        }
        .auto-style25 {
            width: 191px;
            height: 25px;
        }
        .auto-style17 {
            width: 120px;
            height: 25px;
        }
        .auto-style23 {
            height: 25px;
            width: 160px;
        }
        .auto-style28 {
            width: 253px;
            height: 25px;
        }
        .auto-style15 {
            height: 25px;
        }
        .auto-style29 {
            width: 50px;
            height: 30px;
        }
        .auto-style30 {
            width: 90px;
            height: 30px;
        }
        .auto-style31 {
            width: 150px;
            height: 30px;
        }
        .auto-style32 {
            width: 191px;
            height: 30px;
        }
        .auto-style33 {
            width: 120px;
            height: 30px;
        }
        .auto-style34 {
            width: 160px;
            height: 30px;
        }
        .auto-style35 {
            width: 253px;
            height: 30px;
        }
        .auto-style36 {
            height: 30px;
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
                    <td class="auto-style6"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style21"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style26"></td>
                    <td class="auto-style19"></td>
                    <td class="auto-style19"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">DNI:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="Txt_Dni" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style20">
                        <asp:RegularExpressionValidator ID="Rfv_DNI" runat="server" ControlToValidate="Txt_Dni" ValidationExpression="^\d{8}$" ValidationGroup="AgregarUsuario">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Rfv_Txt_Dni" runat="server" ControlToValidate="Txt_Dni" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style16">Fecha nacimiento:</td>
                    <td class="auto-style22">
                        <asp:TextBox ID="TxtFechaNacimiento" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style27">
                        <asp:RegularExpressionValidator ID="Rev_FechaNacimiento" runat="server" ControlToValidate="TxtFechaNacimiento" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$" ValidationGroup="AgregarUsuario">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Rfv_TxtFechaNacimiento" runat="server" ControlToValidate="TxtFechaNacimiento" ErrorMessage="RequiredFieldValidator" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style12">Nombre: </td>
                    <td class="auto-style13">
                        <asp:TextBox ID="Txt_Nombre" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style25">
                        <asp:RequiredFieldValidator ID="Rfv_Nombre" runat="server" ControlToValidate="Txt_Apellido" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="Rev_Nombre" runat="server" ControlToValidate="Txt_Nombre" ValidationExpression="^[a-zA-Z]{1,20}$" ValidationGroup="AgregarUsuario">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style17">Direccion:</td>
                    <td class="auto-style23">
                        <asp:TextBox ID="Txt_Direccion" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style28">
                        &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="Rfv_Direccion" runat="server" ControlToValidate="Txt_Direccion" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
                    <td class="auto-style15"></td>
                    <td class="auto-style15"></td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style3">Apellido:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="Txt_Apellido" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style20">
                        <asp:RequiredFieldValidator ID="Rfv_Apellido" runat="server" ControlToValidate="Txt_Apellido" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:RegularExpressionValidator ID="Rev_Apellido" runat="server" ControlToValidate="Txt_Apellido" ValidationExpression="^[a-zA-Z]{1,20}$" ValidationGroup="AgregarUsuario">*</asp:RegularExpressionValidator>
                    </td>
                    <td class="auto-style16">Localidad</td>
                    <td class="auto-style22">
                        <asp:DropDownList ID="DdlLocalidad" runat="server" ValidationGroup="AgregarPaciente">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="Rfv_Localidad" runat="server" ControlToValidate="DdlLocalidad" ValidationGroup="AgregarUsuario" InitialValue="Seleccione una localidad">*</asp:RequiredFieldValidator>
                    &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4">Sexo</td>
                    <td class="auto-style8">
                        <asp:DropDownList ID="Ddl_Sexo" runat="server" ValidationGroup="AgregarPaciente">
                            <asp:ListItem>F</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style20">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Ddl_Sexo" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style18">Correo:</td>
                    <td class="auto-style22">
                        <asp:TextBox ID="Txt_Correo" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                        &nbsp;</td>
                    <td class="auto-style27">
                        <asp:RegularExpressionValidator ID="Rev_Correo" runat="server" ControlToValidate="Txt_Correo" ValidationGroup="AgregarUsuario" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Rfv_Txt_Correo" runat="server" ControlToValidate="Txt_Correo" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4">Nacionalidad:</td>
                    <td class="auto-style8">
                        <asp:TextBox ID="Txt_Nacionalidad" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style20">
                        <asp:RequiredFieldValidator ID="Rfv_Nacionalidad" runat="server" ControlToValidate="Txt_Nacionalidad" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style18">Telefono:</td>
                    <td class="auto-style22">
                        <asp:TextBox ID="Txt_Telefono" runat="server" ValidationGroup="AgregarPaciente"></asp:TextBox>
                    </td>
                    <td class="auto-style27">
                        <asp:RegularExpressionValidator ID="Rev_Telefono" runat="server" ControlToValidate="Txt_Telefono" ValidationExpression="^\d{8}$" ValidationGroup="AgregarUsuario">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="Rfv_Txt_Telefono" runat="server" ControlToValidate="Txt_Telefono" ValidationGroup="AgregarUsuario">*</asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style21"></td>
                    <td class="auto-style18"></td>
                    <td class="auto-style24"></td>
                    <td class="auto-style26"></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style29"></td>
                    <td class="auto-style30">
                        <asp:Button ID="Btn_AgregarPaciente" runat="server" Text="Agregar" ValidationGroup="AgregarUsuario" OnClick="Btn_AgregarPaciente_Click" />
                    </td>
                    <td class="auto-style31"></td>
                    <td class="auto-style32">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style33">
                        <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Administrador.aspx">&lt;- Volver</asp:HyperLink>
                    </td>
                    <td class="auto-style34"></td>
                    <td class="auto-style35"></td>
                    <td class="auto-style36"></td>
                    <td class="auto-style36"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
