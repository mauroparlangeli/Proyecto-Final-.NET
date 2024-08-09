using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            NegocioUsuarios negocioUsuarios = new NegocioUsuarios();
            NegocioMedicos negocioMedicos = new NegocioMedicos();

            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            //buscar en la tabla usuarios si existe el usuario y la contraseña
            bool existe = negocioUsuarios.validarUsuario(usuario, contraseña);

            //si existe el usuario y la contraseña, se redirige a la pagina correspondiente
            if (existe)
            {
                bool tipoUsuario = negocioUsuarios.getTipoUsuario(usuario);
                if (tipoUsuario)
                {
                    //guardar administrador en session
                    NegocioAdministrador negocioAdministradores = new NegocioAdministrador();
                    Entidades.Usuarios UsuarioAdministrador = negocioUsuarios.GetUsuario(usuario);//buscar el usuario por nombre
                    Session["UsuarioAdministrador"] = UsuarioAdministrador;
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    //obtener nombre del medico asociado al usuario
                    Entidades.Usuarios Usuario = negocioUsuarios.GetUsuario(usuario);
                    Session["UsuarioMedico"] = Usuario;
                    Response.Redirect("Medico.aspx");
                }
            }
            else
            {
                LblMensaje.Text = "Usuario o contraseña incorrectos";
            }
            
        }
    }
}