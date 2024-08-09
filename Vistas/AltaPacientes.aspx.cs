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
    public partial class AltaPacientes : System.Web.UI.Page
    {
        NegocioPacientes negocioPacientes = new NegocioPacientes();
        protected void Page_Load(object sender, EventArgs e)
        {
      
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
                }
            }
    
        }

        private void CargarLocalidades()
        {
            DataTable dtLocalidades = negocioPacientes.obtenerLocalidades();

            DdlLocalidad.DataSource = dtLocalidades;
            DdlLocalidad.DataTextField = "Nombre_Loc";
            DdlLocalidad.DataValueField = "Id_Localidad";
            DdlLocalidad.DataBind();

            DdlLocalidad.Items.Insert(0, new ListItem("Seleccione una localidad", "0"));
        }

        protected void Btn_AgregarPaciente_Click(object sender, EventArgs e)
        {
            //se chequea que no exista un paciente con el mismo dni
            if (!negocioPacientes.ExistePaciente(Txt_Dni.Text.Trim()))
            {
                //se guardan los valores ingresados en variables
                string dni = Txt_Dni.Text;
                string nombre = Txt_Nombre.Text;
                string apellido = Txt_Apellido.Text;
                char sexo = Ddl_Sexo.SelectedValue[0];
                string nacionalidad = Txt_Nacionalidad.Text;
                DateTime fechaNacimiento = DateTime.Parse(TxtFechaNacimiento.Text);
                string direccion = Txt_Direccion.Text;
                string idLocalidad = DdlLocalidad.SelectedValue;
                string correo = Txt_Correo.Text;
                string telefono = Txt_Telefono.Text;
                string idUsuario = "usuario";

                // se agrega a la db el paciente mediante un insert
                bool resultado = negocioPacientes.agregarPaciente(dni, nombre, apellido, sexo, nacionalidad, fechaNacimiento, direccion, idLocalidad, correo, telefono, idUsuario);


                if (resultado)
                {

                    lblMensaje.Text = "Paciente agregado correctamente.";
                    LimpiarControles();
                }
                else
                {

                    lblMensaje.Text = "Hubo un error al agregar el paciente.";
                }
            }
            else
            {
                lblMensaje.Text = "El paciente ya existe.";
                LimpiarControles();
            }
        }

        private void LimpiarControles()
        {
            Txt_Dni.Text = "";
            Txt_Nombre.Text = "";
            Txt_Apellido.Text = "";
            Ddl_Sexo.SelectedIndex = 0;
            Txt_Nacionalidad.Text = "";
            TxtFechaNacimiento.Text = "";
            Txt_Direccion.Text = "";
            DdlLocalidad.SelectedIndex = 0;
            Txt_Correo.Text = "";
            Txt_Telefono.Text = "";
        }
    }
}