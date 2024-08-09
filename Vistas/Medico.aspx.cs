using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Medico : System.Web.UI.Page
    {
        NegocioTurnos negTurno = new NegocioTurnos();
        Entidades.Turnos tur = new Entidades.Turnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Usuarios usuario = new Entidades.Usuarios();
                if (Session["UsuarioMedico"] != null)
                {
                    usuario = (Entidades.Usuarios)Session["UsuarioMedico"];
                    Lbl_Medico.Text = usuario.NombreUsuario;
                }
                else
                {
                    Lbl_Medico.Text = "No hay usuario logueado";
                }
                cargarGridTurnos();
                
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            //convierte el valor del txt en entero 
            // y con ese valor se busca el turno con ese numero
            obtenerTurno();
            txtTurnos.Text = "";
        }

        public void cargarGridTurnos()
        {
            DataTable dtTurno = negTurno.obtenerTablaTurnos();
            grdTurnosMed.DataSource = dtTurno;
            grdTurnosMed.DataBind();
        }

        public void obtenerTurno()
        {
            int nroTurno = Convert.ToInt32(txtTurnos.Text);
            Entidades.Turnos tur = negTurno.obtenerTurno(nroTurno);

            if (tur != null)
            {
                // se agregan columnas para cada valor
                DataTable dtTurno = new DataTable();
                dtTurno.Columns.Add("Nro_Turno");
                dtTurno.Columns.Add("DNI_Paciente");
                dtTurno.Columns.Add("Legajo_Med");
                dtTurno.Columns.Add("Fecha");
                dtTurno.Columns.Add("Horario");
                dtTurno.Columns.Add("Observaciones");
                dtTurno.Columns.Add("Asistencia");

                // se cargan los valores en cada columna
                DataRow row = dtTurno.NewRow();
                row["Nro_Turno"] = tur.GetNro_Turno();
                row["DNI_Paciente"] = tur.GetDNI_Paciente();
                row["Legajo_Med"] = tur.GetLegajo_Med();
                row["Fecha"] = tur.Getfecha();
                row["Horario"] = tur.Gethorario();
                row["Observaciones"] = tur.GetObvservaciones();
                row["Asistencia"] = tur.GetAsistencia();
                dtTurno.Rows.Add(row);

                grdTurnosMed.DataSource = dtTurno;
                grdTurnosMed.DataBind();
            }
            else
            {
                grdTurnosMed.DataSource = null;
                grdTurnosMed.DataBind();
            }

        }

        protected void grdTurnosMed_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string NroTurno = ((Label)grdTurnosMed.Rows[e.NewSelectedIndex].FindControl("lbl_it_NroTurno")).Text;
            string Dni = ((Label)grdTurnosMed.Rows[e.NewSelectedIndex].FindControl("lbl_it_DniPaciente")).Text;
            string fecha = ((Label)grdTurnosMed.Rows[e.NewSelectedIndex].FindControl("lbl_it_Fecha")).Text;
            string horario = ((Label)grdTurnosMed.Rows[e.NewSelectedIndex].FindControl("lbl_it_Horario")).Text;
            LblSeleccion.Text = NroTurno;

            tur = negTurno.obtenerTurno(int.Parse(NroTurno));
            string dni = tur.GetDNI_Paciente();
            TxtObservaciones.Text = tur.GetObvservaciones();
        }

        protected void BtnAsistencia_Click(object sender, EventArgs e)
        {
            if (LblSeleccion.Text.Trim() != "")
            {
                //obtener turno
                int NroTurno = Convert.ToInt32(LblSeleccion.Text.Trim());
                tur = negTurno.obtenerTurno(NroTurno);
                bool CambioAsistencia = !tur.GetAsistencia();//cambia la asistencia alternando entre true y false
                //modificar asistencia
                bool resultado = negTurno.ModificarTurno(tur.GetNro_Turno(), tur.GetDNI_Paciente(), tur.GetLegajo_Med(), tur.Getfecha(), tur.Gethorario(), tur.GetObvservaciones(), CambioAsistencia);
                if (resultado)
                {
                    lblMensaje.Text = "Asistencia modificada";
                    cargarGridTurnos();
                }
                else
                {
                    lblMensaje.Text = "No se pudo modificar la asistencia";
                }
            }
        }

        protected void BtnActualizarObservacion_Click(object sender, EventArgs e)
        {
            string NroTurno = LblSeleccion.Text.Trim();
            tur = negTurno.obtenerTurno(int.Parse(NroTurno));
            bool resultado = negTurno.ModificarTurno(tur.GetNro_Turno(), tur.GetDNI_Paciente(), tur.GetLegajo_Med(), tur.Getfecha(), tur.Gethorario(), TxtObservaciones.Text, tur.GetAsistencia());
            if (resultado)
            {
                lblMensaje.Text = "Observacion modificada";
                cargarGridTurnos();
            }
            else
            {
                lblMensaje.Text = "No se pudo modificar la observacion";
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarGridTurnos();
        }
    }
}