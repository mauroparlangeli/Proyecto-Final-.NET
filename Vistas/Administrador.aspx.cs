using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargar nombre de administrador
                Entidades.Usuarios usuario = new Entidades.Usuarios();
                if (Session["UsuarioAdministrador"] != null)
                {
                    usuario = (Entidades.Usuarios)Session["UsuarioAdministrador"];
                    lblUsuario.Text = usuario.NombreUsuario;
                }
                else
                {
                    lblUsuario.Text = "No hay usuario logueado";
                }
            }
        }
    }
}