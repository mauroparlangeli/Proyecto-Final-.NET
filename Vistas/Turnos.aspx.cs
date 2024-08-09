using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class Turnos : System.Web.UI.Page
    {
        NegocioTurnos negTur = new NegocioTurnos();
        NegocioPacientes negPacientes = new NegocioPacientes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                cargarddlPacientes();
                cargarddlEspecialidades();
            }
        }

        public void cargarddlPacientes()
        {
            ddlPaciente.DataSource = negPacientes.getPacientesEstadoTrue();
            ddlPaciente.DataTextField = "Nombre_Pa";
            ddlPaciente.DataValueField = "DNI_Pa";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        public void cargarddlEspecialidades()
        {
            ddlEspecialidad.DataSource = negTur.obtenerEspecialidad();
            ddlEspecialidad.DataTextField = "Nombre_Especialidad";
            ddlEspecialidad.DataValueField = "Id_Especialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        public void cargarddlMedico(string id_Esp)
        {
            ddlMedico.DataSource = negTur.obtenerMedico(id_Esp);
            ddlMedico.DataTextField = "Nombre_Med";
            ddlMedico.DataValueField = "Legajo_Med";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }
        
        protected void ddlEspecialidad_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DdlDia.Items.Clear();
            DdlDia.Items.Add(new ListItem("--Seleccionar--", "8"));
            DdlHorario.Items.Clear();
            DdlHorario.Items.Add(new ListItem("--Seleccionar--", "0"));
            DdlFechas.Items.Clear();
            DdlFechas.Items.Add(new ListItem("--Seleccionar--", "0"));
            string idEspecialidad = ddlEspecialidad.SelectedValue;
            if (idEspecialidad != "0")
            {
                cargarddlMedico(idEspecialidad);
            }
            else
            {
                ddlMedico.Items.Clear();
                ddlMedico.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            // se asignan los valores mediante sets para el nuevo turno asignado
            Entidades.Turnos nuevoTurno = new Entidades.Turnos();
            nuevoTurno.setDNI_Paciente(ddlPaciente.SelectedValue);
            nuevoTurno.setLegajo_Med(ddlMedico.SelectedValue.ToString());
            nuevoTurno.setfecha(DdlFechas.SelectedValue.ToString());
            nuevoTurno.sethorario(DdlHorario.SelectedValue.ToString());
            nuevoTurno.setObvservaciones("");
            nuevoTurno.setAsistencia(false);

            if (negTur.TurnoOcupado(nuevoTurno) == false)
            {
                //se agrega el turno en la db mediante un insert
                NegocioTurnos negTurnos = new NegocioTurnos();
                bool resultado = negTurnos.agregarTurno(nuevoTurno);

                if (resultado)
                {
                    lblMensaje.Text = "Turno agregado exitosamente.";
                }
                else
                {
                    lblMensaje.Text = "Error al agregar el turno.";
                }
            }
            else
            {
                lblMensaje.Text = "Turno no disponible";
            }
            
        }

        protected void CargarDdlDias()
        {
            DdlDia.Items.Clear();
            NegocioMedicos NegocioMedicos = new NegocioMedicos();
            DataTable Horarios = NegocioMedicos.GetDiasAtencion(ddlMedico.SelectedValue);
            if (Horarios.Rows.Count != 0)
            {
                foreach (DataRow row in Horarios.Rows)
                {
                    switch (row["Dia_Semana"].ToString())
                    {
                        case "1":
                            DdlDia.Items.Add(new ListItem("Lunes", "1"));
                            break;
                        case "2":
                            DdlDia.Items.Add(new ListItem("Martes", "2"));
                            break;
                        case "3":
                            DdlDia.Items.Add(new ListItem("Miércoles", "3"));
                            break;
                        case "4":
                            DdlDia.Items.Add(new ListItem("Jueves", "4"));
                            break;
                        case "5":
                            DdlDia.Items.Add(new ListItem("Viernes", "5"));
                            break;
                        case "6":
                            DdlDia.Items.Add(new ListItem("Sábado", "6"));
                            break;
                        case "0":
                            DdlDia.Items.Add(new ListItem("Domingo", "0"));
                            break;
                    }
                }
            }
            else//Si no tiene horarios de atención se borra Dia, Horario y Fecha sino queda cargado lo de otro medico
            {
                DdlDia.Items.Clear();
                DdlDia.Items.Add(new ListItem("--Seleccionar--", "8"));
                DdlHorario.Items.Clear();
                DdlHorario.Items.Add(new ListItem("--Seleccionar--", "0"));
                DdlFechas.Items.Clear();
                DdlFechas.Items.Add(new ListItem("--Seleccionar--", "0"));
            }
        }
        public void CargarDdlHorarios()//traer los horarios del medico en el dia de la semana seleccionado
        {
            NegocioMedicos NegMedicos = new NegocioMedicos();

            DataTable dt = NegMedicos.GetHorariosAtencion(ddlMedico.SelectedValue, DdlDia.SelectedValue);//traer los horarios del medico en el dia de la semana seleccionado

            if (dt.Rows.Count == 0)//Si no tiene horarios se limpia el DdlHorario y DdlFechas
            {
                DdlHorario.Items.Clear();
                DdlHorario.Items.Add(new ListItem("--Seleccionar--", "0"));
                DdlFechas.Items.Clear();
                DdlFechas.Items.Add(new ListItem("--Seleccionar--"));
                return;
            }

            //Guardar hora_Inicio y hora_Fin en variables
            DateTime Hora_Inicio = DateTime.Parse(dt.Rows[0]["Hora_Inicio"].ToString());
            DateTime Hora_Fin = DateTime.Parse(dt.Rows[0]["Hora_Fin"].ToString());

            int Inicio = Hora_Inicio.Hour;
            int Fin = Hora_Fin.Hour;

            //Cargar DdlHorarios con los horarios disponibles en el dia seleccionado previamente
            DdlHorario.Items.Clear();
            for (int i = Inicio; i <= Fin; i++)
            {
                DdlHorario.Items.Add(new ListItem(i.ToString() + ":00hs", i.ToString()));
            }
        }

        private void CargarFechas()
        {
            DdlFechas.Items.Clear();
            int DiaSemana = int.Parse(DdlDia.SelectedValue);//obtener el dia de la semana seleccionado
            DayOfWeek DiaSeleccionado = (DayOfWeek)DiaSemana;//convertir el dia de la semana a un tipo DayOfWeek EJ: 1 = Lunes

            DateTime startDate = DateTime.Today;
            DateTime endDate = startDate.AddMonths(6);

            while (startDate <= endDate)//cargar las fechas de los próximos 6 meses del dia de la semana seleccionado
            {
                if (startDate.DayOfWeek == DiaSeleccionado)
                {
                    DdlFechas.Items.Add(new ListItem(startDate.ToString("dd/MM/yyyy"), startDate.ToString("yyyy-MM-dd")));//
                }

                startDate = startDate.AddDays(1);
            }

            //opcional eliminar o no cargar las fechas ocupadas
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlDias();
            //CargarDdlHorarios();
            //CargarFechas();
        }

        protected void DdlDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDdlHorarios();
            CargarFechas();
        }
    }
}