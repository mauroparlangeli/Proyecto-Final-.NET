using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class Informes : System.Web.UI.Page
    {
        NegocioInformes negocioInformes = new NegocioInformes();
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios usuario = new Entidades.Usuarios();
            if (Session["UsuarioAdministrador"] != null)
            {
                usuario = (Entidades.Usuarios)Session["UsuarioAdministrador"];
                Lbl_Nombre_Usuario.Text = usuario.NombreUsuario;
            }
            else
            {
                Lbl_Nombre_Usuario.Text = "No hay usuario logueado";
            }
            if (!IsPostBack)
            {
                CargarDdlMedicos();
            }
        }


        // se muestran los pacientes ordenados por localidad mediante una consulta
        // que busca los pacientes y los agrupa por localidad
        protected void CantidadPacientesPorLocalidad_Click(object sender, EventArgs e)
        {
            GrdInformes.DataSource = negocioInformes.ObtenerCantidadPacientesPorLocalidad();
            GrdInformes.DataBind();
        }

        //se muestra el promedio de edad mediante una consulta con la funcion AVG()
        protected void LBtnPromedioEdad_Click(object sender, EventArgs e)
        {
            GrdInformes.DataSource = negocioInformes.ObtenerPromedioEdadPacientes();
            GrdInformes.DataBind();
        }

        // se buscan los turnos de un medico mediante un legajo ingresado
        protected void btn_BuscarTurnos_Click(object sender, EventArgs e)
        {
            string legajo = ddl_Medicos.SelectedValue;
            GrdInformes.DataSource = negocioInformes.ObtenerTurnosMedicos(legajo);
            GrdInformes.DataBind();
        }

        protected void CargarDdlMedicos()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            ddl_Medicos.DataSource = negocioMedicos.ObtenerMedicos();
            ddl_Medicos.DataTextField = "Nombre_Med";
            ddl_Medicos.DataValueField = "Legajo_Med";
            ddl_Medicos.DataBind();

        }

        protected void lb_PacientesEliminados_Click(object sender, EventArgs e)
        {
            GrdInformes.DataSource = negocioInformes.ObtenerPacientesDadosDeBaja();
            GrdInformes.DataBind();
        }

        protected void lb_MedicosEliminados_Click(object sender, EventArgs e)
        {
            GrdInformes.DataSource = negocioInformes.ObtenerMedicosDadosDeBaja();
            GrdInformes.DataBind();
        }
    }
}