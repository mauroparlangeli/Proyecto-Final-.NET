using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;

namespace Vistas
{
    public partial class AltaMedicos : System.Web.UI.Page
    {
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
                CargarLocalidades();
                CargarDdlMedicos();
                CargarDdlIinicoFin();
                CargarDdlMedicosHorarios();
                CargarDdlEspecialidades();
            }
        }

        private void CargarLocalidades()
        {
            NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
            DataTable dtLocalidades = negocioLocalidades.getLocalidades();

            ddlLocalidad.DataSource = dtLocalidades;
            ddlLocalidad.DataTextField = "Nombre_Loc";
            ddlLocalidad.DataValueField = "Id_Localidad";
            ddlLocalidad.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //se guardan los valores ingresados en variables
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string sexo = ddlSexo.SelectedValue;
            string nacionalidad = txtNacionalidad.Text.Trim();
            string fechaNacimiento = txtFechaNacimiento.Text.Trim();
            string direccion = TxtDireccion.Text.Trim();
            string localidad = ddlLocalidad.SelectedValue;
            string correo = txtCorreo.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string especialidad = ddl_especialidades.SelectedValue;


            NegocioMedicos NegocioMedicos = new NegocioMedicos();
            // se chequea que no exista un medico con el mismo dni y si no existe 
            // se agrega a la db mediante un insert
            if (NegocioMedicos.ExisteMedico(dni))
            {
                LblAltaMedico.Text = "El medico ya existe";
                return;
            }
            int Legajo = NegocioMedicos.ContarLegajos() + 1;
            bool Agregado = NegocioMedicos.AgregarMedico(Legajo.ToString(), dni, nombre, apellido, sexo[0], nacionalidad, Convert.ToDateTime(fechaNacimiento), direccion, localidad, correo, telefono, especialidad, true);

            
        }

        protected void CargarDdlMedicos()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            DdlMedicos.DataSource = negocioMedicos.ObtenerMedicos();
            DdlMedicos.DataTextField = "Nombre_Med";
            DdlMedicos.DataValueField = "Legajo_Med";
            DdlMedicos.DataBind();
        }

        protected void CargarDdlEspecialidades()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            ddl_especialidades.DataSource = negocioMedicos.ObtenerEspecialidades();
            ddl_especialidades.DataTextField = "Nombre_Especialidad";
            ddl_especialidades.DataValueField = "Id_Especialidad";
            ddl_especialidades.DataBind();
        }

        protected void CargarDdlMedicosHorarios()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            Ddl_MedicoHorario.DataSource = negocioMedicos.ObtenerMedicos();
            Ddl_MedicoHorario.DataTextField = "Nombre_Med";
            Ddl_MedicoHorario.DataValueField = "Legajo_Med";
            Ddl_MedicoHorario.DataBind();
        }

        protected void BtnCrearUsuario_Click(object sender, EventArgs e)    
        {
            string nombreUsuario = TxtUsuario.Text.Trim();
            string contraseña = TxtContraseña.Text.Trim();
            string legajo = DdlMedicos.SelectedValue;

            //Comprobar si el usuario ya existe
            NegocioUsuarios negocioUsuarios = new NegocioUsuarios();
            if (negocioUsuarios.ExisteUsuario(nombreUsuario))
            {
                Lbl_CrearUsuario.Text = "El usuario ya existe";
                return;
            }
            bool Agregado = negocioUsuarios.agregarUsuario(nombreUsuario, contraseña, "M");

            
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            Entidades.Medico medico = new Entidades.Medico();
            Entidades.Usuarios usuario = negocioUsuarios.GetUsuario(nombreUsuario);
            medico = negocioMedicos.GetMedico(legajo);
            medico.setIdUsuario(usuario.IdUsuario.ToString());
            string id = medico.getIdUsuario();
            Agregado = negocioMedicos.ModificarMedico(medico.getLegajoMed(), medico.getDNIMed(), medico.getNombreMed(), medico.getApellidoMed(), medico.getSexoMed(), medico.getNacionalidadMed(), medico.getFechaNacimientoMed(), medico.getDireccion(), medico.getIdLocalidad(), medico.getCorreoMed(), medico.getTelefonoMed(), medico.getEspecialidad(), medico.getIdUsuario(), true);

            if (Agregado)
            {
                Lbl_CrearUsuario.Text = "Usuario creado exitosamente";
            }
            else
            {
                Lbl_CrearUsuario.Text = "Error al crear el Usuario";
            }
        }

        protected void CargarDdlIinicoFin()
        {
            Ddl_HoraInicio.Items.Clear();
            Ddl_HoraFin.Items.Clear();
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                {
                    Ddl_HoraInicio.Items.Add(new ListItem("0" + i.ToString() + ":00hs", i.ToString()));
                    Ddl_HoraFin.Items.Add(new ListItem("0" + i.ToString() + ":00hs", i.ToString()));
                }
                else
                { 
                Ddl_HoraInicio.Items.Add(new ListItem(i.ToString() + ":00hs", i.ToString()));
                Ddl_HoraFin.Items.Add(new ListItem(i.ToString() + ":00hs", i.ToString()));
                }
            }
        }

        protected void BtnAgregarHorarios_Click(object sender, EventArgs e)
        {
            String Legajo = Ddl_MedicoHorario.SelectedValue;
            NegocioHorariosMedicos negocioHorariosMedicos = new NegocioHorariosMedicos();
            foreach (ListItem item in Cbl_Dias.Items)
            {
                if (item.Selected)
                {
                    int dia = int.Parse(item.Value);
                    TimeSpan horaInicio = TimeSpan.FromHours(int.Parse(Ddl_HoraInicio.SelectedValue));
                    TimeSpan horaFin = TimeSpan.FromHours(int.Parse(Ddl_HoraFin.SelectedValue));
                    bool AgregadoHorario = negocioHorariosMedicos.AgregarHorarioMedico(Legajo.ToString(), dia, horaInicio, horaFin);
                }
            }
        }

        protected void Ddl_MedicoHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}