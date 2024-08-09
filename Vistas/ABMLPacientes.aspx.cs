using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class ABMLPacientes : System.Web.UI.Page
    {
        NegocioPacientes negocioPacientes = new NegocioPacientes();
        NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                cargarGrilla();
                //cargar nombre de administrador
                Entidades.Usuarios usuario = new Entidades.Usuarios();
                if (Session["UsuarioAdministrador"] != null)
                {
                    usuario = (Entidades.Usuarios)Session["UsuarioAdministrador"];
                    LblNombreUsuario.Text = usuario.NombreUsuario;
                }
                else
                {
                    LblNombreUsuario.Text = "No hay usuario logueado";
                }
            }
        }

        protected void BtnFiltrarNombre_Click(object sender, EventArgs e)
        {
            string nombre = txtFiltrarNombre.Text;
            //mediante una consulta te buscan los pacientes que contienen el texto ingresado en el txtbox
            GrdPacientes.DataSource = negocioPacientes.FiltrarPacientesPorNombre(nombre);
            GrdPacientes.DataBind();
            txtFiltrarNombre.Text = "";
        }

        protected void GrdPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Dni = ((Label)GrdPacientes.Rows[e.RowIndex].FindControl("Lbl_it_DniPaciente")).Text;
            //guardar dni para buscar el paciente y borrarlo
            negocioPacientes = new NegocioPacientes();

            if (negocioPacientes.eliminarPaciente(Dni))
            {
                cargarGrilla();
                LblPaciente.Text = "Paciente eliminado";
            }
            else
            {
                LblPaciente.Text = "No se pudo eliminar el paciente";
            }

        }

        protected void GrdPacientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
          
        }

        protected void GrdPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GrdPacientes.EditIndex = e.NewEditIndex;
            cargarGrilla();
        }

        protected void GrdPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GrdPacientes.EditIndex = -1;
            cargarGrilla();
        }

        protected void cargarGrilla()
        {
            GrdPacientes.DataSource = negocioPacientes.getPacientesEstadoTrue();
            GrdPacientes.DataBind();
        }

        protected void GrdPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //guarda los valores en variables
            string s_Dni_Pa = ((Label)GrdPacientes.Rows[e.RowIndex].FindControl("Lbl_eit_DNI_Pa")).Text;
            string s_Nombre_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Nombre_Pa")).Text;
            string s_Apellido_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Apellido_Pa")).Text;
            string s_Sexo = ((DropDownList)GrdPacientes.Rows[e.RowIndex].FindControl("Ddl_eit_Sexo")).Text;
            string s_Nacionalidad_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Nacionalidad_Pa")).Text;
            string s_Fecha_Nacimiento_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Fecha_Nacimiento_Pa")).Text;
            string s_Direccion_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Direccion_Pa")).Text;
            string s_Id_Localidad = ((DropDownList)GrdPacientes.Rows[e.RowIndex].FindControl("Ddl_eit_Nombre_Loc")).SelectedValue;
            string s_Correo_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Correo_Pa")).Text;
            string s_Telefono_Pa = ((TextBox)GrdPacientes.Rows[e.RowIndex].FindControl("Txt_eit_Telefono_Pa")).Text;

            //modifica el paciente con los valores guardados
            negocioPacientes.ModificarPaciente(s_Dni_Pa, s_Nombre_Pa, s_Apellido_Pa, s_Sexo[0], s_Nacionalidad_Pa, Convert.ToDateTime(s_Fecha_Nacimiento_Pa), s_Direccion_Pa, s_Id_Localidad, s_Correo_Pa, s_Telefono_Pa);

            //termina la edicion
            GrdPacientes.EditIndex = -1;
            cargarGrilla();
            LblPaciente.Text = "El paciente ha sido editado exitosamente";
        }

        protected void GrdPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Cargar DDL eit_Nombre_Loc
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlLoc = (DropDownList)e.Row.FindControl("Ddl_eit_Nombre_Loc");
                if(ddlLoc != null)
                {
                    ddlLoc.DataSource = negocioLocalidades.getLocalidades();
                    ddlLoc.DataTextField = "Nombre_Loc";
                    ddlLoc.DataValueField = "Id_Localidad";
                    ddlLoc.DataBind();
                }

                //cargar ddl Ddl_eit_Provincia
                NegocioProvincias negocioProvincias = new NegocioProvincias();
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("Ddl_eit_Provincia");
                if(ddlProvincia != null)
                {
                    ddlProvincia.DataSource = negocioProvincias.GetProvincias();
                    ddlProvincia.DataTextField = "Nombre_Prov";
                    ddlProvincia.DataValueField = "Id_Provincia";
                    ddlProvincia.DataBind();
                }

                //string s_Id_Localidad = ((Label)e.Row.FindControl("lbl_it_Id_Localidad")).Text;
                //string s_Nombre_Loc = ((Label)e.Row.FindControl("Lbl_eit_NombreLoc")).Text;

                ////Insertarlo en el ddl localidades al editar
                //ddl = (DropDownList)e.Row.FindControl("Ddl_eit_Nombre_Loc");
                //if (ddl != null)
                //{
                //    // Insertar un nuevo ítem en el índice 0
                //    ddl.Items.Insert(0, new ListItem(s_Id_Localidad, s_Nombre_Loc));
                //}
            }
        }

        protected void Ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddlLoc = (DropDownList)row.FindControl("Ddl_eit_Nombre_Loc");
            if (ddlLoc != null)
            {
                string Id_provincia = ddlProvincia.SelectedValue;
                ddlLoc.DataSource = negocioLocalidades.GetLocalidadesPorProvincia(Id_provincia);
                ddlLoc.DataTextField = "Nombre_Loc";
                ddlLoc.DataValueField = "Id_Localidad";
                ddlLoc.DataBind();
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            cargarGrilla();
            LblPaciente.Text = "";
        }

        protected void Ddl_eit_Nombre_Loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlLocalidad = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlLocalidad.NamingContainer;

            DropDownList ddlProv = (DropDownList)row.FindControl("Ddl_eit_Provincia");
            if (ddlProv != null)
            {
                string Id_Localidad = ddlLocalidad.SelectedValue;
                ddlProv.DataSource = negocioLocalidades.GetProvinciaPorLocalidades(Id_Localidad);
                ddlProv.DataTextField = "Nombre_Prov";
                ddlProv.DataValueField = "Id_Provincia";
                ddlProv.DataBind();
            }
        }
    }
}