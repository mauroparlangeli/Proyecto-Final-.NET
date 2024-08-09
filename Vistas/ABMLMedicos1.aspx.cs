using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class ABMLMedicos1 : System.Web.UI.Page
    {
        NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
        NegocioMedicos negocioMedicos = new NegocioMedicos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Usuarios usuario = new Entidades.Usuarios();
                if (Session["UsuarioAdministrador"] != null)
                {
                    usuario = (Entidades.Usuarios)Session["UsuarioAdministrador"];
                    Lbl_NombreAdministrador.Text = usuario.NombreUsuario;
                }
                else
                {
                    Lbl_NombreAdministrador.Text = "No hay usuario logueado";
                }
                cargarGrilla();
            }
        }

        //carga la grilla con todos los medicos
        protected void cargarGrilla()
        {
            NegocioMedicos negocioMedicos = new NegocioMedicos();
            GrdMedicos.DataSource = negocioMedicos.ObtenerMedicos();
            GrdMedicos.DataBind();
        }


        protected void GrdMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //guarda los valores en variables
            string legajo = ((Label)GrdMedicos.Rows[e.RowIndex].FindControl("Lbl_eit_Legajo_Med")).Text;
            string Dni = ((Label)GrdMedicos.Rows[e.RowIndex].FindControl("Lbl_eit_Dni_Med")).Text;
            string nombre = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Nombre_Med")).Text;
            string Apellido = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Apellido_Med")).Text;
            string Sexo = ((DropDownList)GrdMedicos.Rows[e.RowIndex].FindControl("Ddl_eit_Sexo_Med")).Text;
            string Nacionalidad = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Nacionalidad_Med")).Text;
            string FechaNacimiento = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_FechaNacimientoMed")).Text;
            string Direccion = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Direccion_Med")).Text;
            string IdLocalidad = ((DropDownList)GrdMedicos.Rows[e.RowIndex].FindControl("Ddl_eit_Nombre_Loc")).SelectedValue;
            string Correo = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Correo_Med")).Text;
            string telefono = ((TextBox)GrdMedicos.Rows[e.RowIndex].FindControl("Txt_eit_Telefono_Med")).Text;
            string Especialidad = ((DropDownList)GrdMedicos.Rows[e.RowIndex].FindControl("Ddl_eit_Especialidad")).SelectedValue;

            Entidades.Medico medico = negocioMedicos.GetMedico(legajo);

            //modifica el medico con los valores guardados
            negocioMedicos.ModificarMedico(legajo, Dni, nombre, Apellido, Sexo[0], Nacionalidad, Convert.ToDateTime(FechaNacimiento), Direccion, IdLocalidad, Correo, telefono, Especialidad, medico.getIdUsuario(),true);

            //termina la edicion
            GrdMedicos.EditIndex = -1;
            cargarGrilla();
            LblMedico.Text = "Médico editado correctamente";
        }

        protected void GrdMedicos_RowEditing(object sender, GridViewEditEventArgs e)//Cuadno se hace click en el boton editar
        {
            GrdMedicos.EditIndex = e.NewEditIndex;
            cargarGrilla();
        }

        protected void GrdMedicos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //guarda el legajo del medico a borrar
            string Legajo = ((Label)GrdMedicos.Rows[e.RowIndex].FindControl("Lbl_it_Legajo")).Text;

            negocioMedicos = new NegocioMedicos();

            if (negocioMedicos.EliminarMedico(Legajo))
            {
                cargarGrilla();
                LblMedico.Text = "Medico eliminado";
            }
            else
            {
                LblMedico.Text = "No se pudo eliminar el medico";
            }
            
        }

        //carga el ddl localidades en base a la provincia seleccionada
        protected void Ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guarda el valor de la provincia
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            DropDownList ddlLoc = (DropDownList)row.FindControl("Ddl_eit_Nombre_Loc");
            if (ddlLoc != null)
            {
                //busca las localidades de la provincia con el valor guardado anteriormente
                string Id_provincia = ddlProvincia.SelectedValue;
                ddlLoc.DataSource = negocioLocalidades.GetLocalidadesPorProvincia(Id_provincia);
                ddlLoc.DataTextField = "Nombre_Loc";
                ddlLoc.DataValueField = "Id_Localidad";
                ddlLoc.DataBind();
            }
        }

        protected void GrdMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Cargar DDL eit_Nombre_Loc
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NegocioLocalidades negocioLocalidades = new NegocioLocalidades();
                DropDownList ddlLoc = (DropDownList)e.Row.FindControl("Ddl_eit_Nombre_Loc");
                if (ddlLoc != null)
                {
                    ddlLoc.DataSource = negocioLocalidades.getLocalidades();
                    ddlLoc.DataTextField = "Nombre_Loc";
                    ddlLoc.DataValueField = "Id_Localidad";
                    ddlLoc.DataBind();
                }

                //Cargar Ddl_eit_Provincia
                NegocioProvincias negocioProvincias = new NegocioProvincias();
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("Ddl_eit_Provincia");
                if (ddlProvincia != null)
                {
                    ddlProvincia.DataSource = negocioProvincias.GetProvincias();
                    ddlProvincia.DataTextField = "Nombre_Prov";
                    ddlProvincia.DataValueField = "Id_Provincia";
                    ddlProvincia.DataBind();
                }

                //Cargar Ddl_eit_Especialidad
                NegocioEspecialidades negocioEspecialidades = new NegocioEspecialidades();
                //se busca un control a partir de un identificador (eit)
                DropDownList ddlEspecialidad = (DropDownList)e.Row.FindControl("Ddl_eit_Especialidad");
                if (ddlEspecialidad != null)
                {
                    //se traen las especialidades mediante un metodo y se guardan en el ddl
                    ddlEspecialidad.DataSource = negocioEspecialidades.getEspecialidades();
                    ddlEspecialidad.DataTextField = "Nombre_Especialidad";
                    ddlEspecialidad.DataValueField = "Id_Especialidad";
                    ddlEspecialidad.DataBind();
                }
            }


        }

        protected void Ddl_eit_Provincia_SelectedIndexChanged1(object sender, EventArgs e)
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

        protected void GrdMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)//cuando se cancela editar
        {
            GrdMedicos.EditIndex = -1;
            cargarGrilla();
        }
    }
}