using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DaoMedicos
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable obtenerEspecialidad() ///Para luego cargar el ddl Especialidades
        {
            return ds.ObtenerTabla("Especialidades", "Select Nombre_Especialidad, Id_Especialidad from Especialidades");
        }

        public DataTable obtenerMedicoXEspecialidad(string id_Esp) ///Para luego cargar el ddl Especialidades
        {
            return ds.ObtenerTabla("Medicos", "Select Nombre_Med, Legajo_Med from Medicos WHERE Especialidad = " + id_Esp + "");
        }


        public Medico getMedico(Medico medico)
        {
            string id = medico.getIdUsuario();
            DataTable tabla = ds.ObtenerTabla("Medicos", "SELECT * FROM Medicos WHERE Legajo_Med ='" + medico.getLegajoMed() + "'");

            if (tabla.Rows.Count > 0)
            {
                medico.setLegajoMed(tabla.Rows[0][0].ToString());
                medico.setDNIMed(tabla.Rows[0][1].ToString());
                medico.setNombreMed(tabla.Rows[0][2].ToString());
                medico.setApellidoMed(tabla.Rows[0][3].ToString());
                medico.setSexoMed(Convert.ToChar(tabla.Rows[0][4]));
                medico.setNacionalidadMed(tabla.Rows[0][5].ToString());
                medico.setFechaNacimientoMed(Convert.ToDateTime(tabla.Rows[0][6]));
                medico.setDireccion(tabla.Rows[0][7].ToString());
                medico.setIdLocalidad(tabla.Rows[0][8].ToString());
                medico.setCorreoMed(tabla.Rows[0][9].ToString());
                medico.setTelefonoMed(tabla.Rows[0][10].ToString());
                medico.setEspecialidad(tabla.Rows[0][11].ToString());
                medico.setIdUsuario(tabla.Rows[0][12].ToString());
                medico.setEstado(Convert.ToBoolean(tabla.Rows[0][13]));
                return medico;
            }
            else
            {
                return null;
            }
        }

        public Medico GetMedico(Medico medico)
        {
            DataTable tabla = ds.ObtenerTabla("Medicos", "SELECT * FROM Medicos WHERE Legajo_Med ='" + medico.getLegajoMed() + "'");

            if (tabla.Rows.Count > 0)
            {
                medico.setLegajoMed(tabla.Rows[0][0].ToString());
                medico.setDNIMed(tabla.Rows[0][1].ToString());
                medico.setNombreMed(tabla.Rows[0][2].ToString());
                medico.setApellidoMed(tabla.Rows[0][3].ToString());
                medico.setSexoMed(Convert.ToChar(tabla.Rows[0][4]));
                medico.setNacionalidadMed(tabla.Rows[0][5].ToString());
                medico.setFechaNacimientoMed(Convert.ToDateTime(tabla.Rows[0][6]));
                medico.setDireccion(tabla.Rows[0][7].ToString());
                medico.setIdLocalidad(tabla.Rows[0][8].ToString());
                medico.setCorreoMed(tabla.Rows[0][9].ToString());
                medico.setTelefonoMed(tabla.Rows[0][10].ToString());
                medico.setEspecialidad(tabla.Rows[0][11].ToString());
                medico.setIdUsuario(tabla.Rows[0][12].ToString());
                medico.setEstado(Convert.ToBoolean(tabla.Rows[0][13]));
                return medico;
            }
            else
            {
                return null;
            }
        }

        public Medico ObtenerMedicoxEspecialidad(Medico medico)
        {
            DataTable tabla = ds.ObtenerTabla("Medicos", "SELECT * FROM Medicos WHERE Especialidad ='" + medico.getEspecialidad() + "'");

            if (tabla.Rows.Count > 0)
            {
                medico.setLegajoMed(tabla.Rows[0][0].ToString());
                medico.setDNIMed(tabla.Rows[0][1].ToString());
                medico.setNombreMed(tabla.Rows[0][2].ToString());
                medico.setApellidoMed(tabla.Rows[0][3].ToString());
                medico.setSexoMed(Convert.ToChar(tabla.Rows[0][4]));
                medico.setNacionalidadMed(tabla.Rows[0][5].ToString());
                medico.setFechaNacimientoMed(Convert.ToDateTime(tabla.Rows[0][6]));
                medico.setDireccion(tabla.Rows[0][7].ToString());
                medico.setIdLocalidad(tabla.Rows[0][8].ToString());
                medico.setCorreoMed(tabla.Rows[0][9].ToString());
                medico.setTelefonoMed(tabla.Rows[0][10].ToString());
                medico.setEspecialidad(tabla.Rows[0][11].ToString());
                medico.setIdUsuario(tabla.Rows[0][12].ToString());
                medico.setEstado(Convert.ToBoolean(tabla.Rows[0][13]));
                return medico;
            }
            else
            {
                return null;
            }
        }

        public Medico ObtenerMedicoxIdUsuario(Medico medico)
        {
            DataTable tabla = ds.ObtenerTabla("Medicos", "SELECT * FROM Medicos WHERE Id_Usuario ='" + medico.getIdUsuario() + "'");

            if (tabla.Rows.Count > 0)
            {
                medico.setLegajoMed(tabla.Rows[0][0].ToString());
                medico.setDNIMed(tabla.Rows[0][1].ToString());
                medico.setNombreMed(tabla.Rows[0][2].ToString());
                medico.setApellidoMed(tabla.Rows[0][3].ToString());
                medico.setSexoMed(Convert.ToChar(tabla.Rows[0][4]));
                medico.setNacionalidadMed(tabla.Rows[0][5].ToString());
                medico.setFechaNacimientoMed(Convert.ToDateTime(tabla.Rows[0][6]));
                medico.setDireccion(tabla.Rows[0][7].ToString());
                medico.setIdLocalidad(tabla.Rows[0][8].ToString());
                medico.setCorreoMed(tabla.Rows[0][9].ToString());
                medico.setTelefonoMed(tabla.Rows[0][10].ToString());
                medico.setEspecialidad(tabla.Rows[0][11].ToString());
                medico.setIdUsuario(tabla.Rows[0][12].ToString());
                medico.setEstado(Convert.ToBoolean(tabla.Rows[0][13]));
                return medico;
            }
            else
            {
                return null;
            }
        }

        public DataTable getTablaMedico()
        {
            DataTable dt = ds.ObtenerTabla("Medicos", "SELECT * FROM Medicos M " +
                "INNER JOIN Localidades L ON M.Id_Localidad = L.Id_Localidad " +
                "INNER JOIN Especialidades E ON M.Especialidad = E.Id_Especialidad " +
                "INNER JOIN provincias P ON L.ID_Provincias = P.Id_Provincia " +
                "WHERE M.estado = 1");

            return dt;
        }


        public Boolean ExisteMedico(Medico medico)
        {
            String consulta = "SELECT Legajo_Med, DNI_Med, Nombre_Med, Apellido_Med, Sexo_Med, Nacionalidad_Med, Fecha_Nacimiento_Med, Id_Localidad, Correo_Med, Telefono_Med, Especialidad, Id_Usuario, estado FROM Medicos WHERE DNI_Med ='" + medico.getDNIMed() + "'";
            return ds.existe(consulta);
        }

        public int agregarMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoAgregar(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarMedico");
        }
        public int eliminarMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoEliminar(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarMedico");
        }

        public int ModificarMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoModificar(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarMedico");
        }

        private void ArmarParametrosMedicoAgregar(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = medico.getLegajoMed();

            SqlParametros = Comando.Parameters.Add("@DNI_Med", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getDNIMed();

            SqlParametros = Comando.Parameters.Add("@Nombre_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getNombreMed();

            SqlParametros = Comando.Parameters.Add("@Apellido_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getApellidoMed();

            SqlParametros = Comando.Parameters.Add("@Sexo_Med", SqlDbType.Char);
            SqlParametros.Value = medico.getSexoMed();

            SqlParametros = Comando.Parameters.Add("@Nacionalidad_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getNacionalidadMed();

            SqlParametros = Comando.Parameters.Add("@Fecha_Nacimiento_Med", SqlDbType.Date);
            SqlParametros.Value = medico.getFechaNacimientoMed();

            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 50);
            SqlParametros.Value = medico.getDireccion();

            SqlParametros = Comando.Parameters.Add("@ID_localidad", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getIdLocalidad();

            SqlParametros = Comando.Parameters.Add("@Correo_Med", SqlDbType.VarChar, 50);
            SqlParametros.Value = medico.getCorreoMed();

            SqlParametros = Comando.Parameters.Add("@Telefono_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getTelefonoMed();

            SqlParametros = Comando.Parameters.Add("@Especialidad", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getEspecialidad();

            SqlParametros = Comando.Parameters.Add("@ESTADO", SqlDbType.Bit);
            SqlParametros.Value = medico.getEstado();
        }

        private void ArmarParametrosMedicoModificar(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = medico.getLegajoMed();

            SqlParametros = Comando.Parameters.Add("@DNI_Med", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getDNIMed();

            SqlParametros = Comando.Parameters.Add("@Nombre_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getNombreMed();

            SqlParametros = Comando.Parameters.Add("@Apellido_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getApellidoMed();

            SqlParametros = Comando.Parameters.Add("@Sexo_Med", SqlDbType.Char, 1);
            SqlParametros.Value = medico.getSexoMed();

            SqlParametros = Comando.Parameters.Add("@Nacionalidad_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getNacionalidadMed();

            SqlParametros = Comando.Parameters.Add("@Fecha_Nacimiento_Med", SqlDbType.Date);
            SqlParametros.Value = medico.getFechaNacimientoMed();

            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar, 50);
            SqlParametros.Value = medico.getDireccion();

            SqlParametros = Comando.Parameters.Add("@ID_localidad", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getIdLocalidad();

            SqlParametros = Comando.Parameters.Add("@Correo_Med", SqlDbType.VarChar, 50);
            SqlParametros.Value = medico.getCorreoMed();

            SqlParametros = Comando.Parameters.Add("@Telefono_Med", SqlDbType.VarChar, 20);
            SqlParametros.Value = medico.getTelefonoMed();

            SqlParametros = Comando.Parameters.Add("@Especialidad", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getEspecialidad();

            SqlParametros = Comando.Parameters.Add("@Id_Usuario", SqlDbType.Char, 6);
            SqlParametros.Value = medico.getIdUsuario();
        }

        private void ArmarParametrosMedicoEliminar(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@LEGAJOMED", SqlDbType.Char, 6);
            SqlParametros.Value = medico.getLegajoMed();
        }

        public DataTable GetDiasAtenciosMedicos(Medico med)
        {
            DataTable dt = ds.ObtenerTabla("Medicos", "SELECT Dia_Semana FROM Horarios_Medicos WHERE Legajo_Med = '" + med.getLegajoMed() + "'");
            return dt;
        }

        public DataTable GetHorariosAtencion(string legajo, string diaSeleccionado)
        {
            DataTable dt = ds.ObtenerTabla("Medicos", "SELECT Hora_Inicio, Hora_Fin FROM Horarios_Medicos WHERE Legajo_Med = '" + legajo + "' AND Dia_Semana = '" + diaSeleccionado + "'");
            return dt;
        }

        public int ContarLegajos()
        {
            DataTable dt = ds.ObtenerTabla("Medicos", "SELECT COUNT(Legajo_Med) FROM Medicos");
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public int VincularUsuarioMedico(Medico medico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoVincularUsuario(ref comando, medico);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SpVincularUsuarioAmedico");
        }
        private void ArmarParametrosMedicoVincularUsuario(ref SqlCommand Comando, Medico medico)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = medico.getLegajoMed();

            SqlParametros = Comando.Parameters.Add("@Id_Usuario", SqlDbType.Char, 8);
            SqlParametros.Value = medico.getIdUsuario();
        }
    }

}

/*
CREATE PROCEDURE spAgregarMedico
(
    @Legajo_Med CHAR(6),
    @DNI_Med CHAR(8),
    @Nombre_Med VARCHAR(20),
    @Apellido_Med VARCHAR(20),
    @Sexo_Med CHAR(1),
    @Nacionalidad_Med VARCHAR(20),
    @Fecha_Nacimiento_Med DATE,
    @Direccion VARCHAR(50),
    @ID_localidad CHAR(8),
    @Correo_Med VARCHAR(50),
    @Telefono_Med VARCHAR(20),
    @Especialidad CHAR(8),
    @Estado BIT
)
AS
BEGIN
    INSERT INTO Medicos
    (
        Legajo_Med,
        DNI_Med,
        Nombre_Med,
        Apellido_Med,
        Sexo_Med,
        Nacionalidad_Med,
        Fecha_Nacimiento_Med,
        Direccion,
        Id_Localidad,
        Correo_Med,
        Telefono_Med,
        Especialidad,
        Estado
    )
    VALUES
    (
        @Legajo_Med,
        @DNI_Med,
        @Nombre_Med,
        @Apellido_Med,
        @Sexo_Med,
        @Nacionalidad_Med,
        @Fecha_Nacimiento_Med,
        @Direccion,
        @ID_localidad,
        @Correo_Med,
        @Telefono_Med,
        @Especialidad,
        @Estado
    );
END
GO

CREATE PROCEDURE spEliminarMedico
(
    @LEGAJOMED CHAR(6)
)
AS
BEGIN
    UPDATE Medicos
    SET estado = 0
    WHERE Legajo_Med = @LEGAJOMED;
    RETURN
END;
GO

CREATE PROCEDURE spModificarMedico
(
    @Legajo_Med CHAR(6),
    @DNI_Med CHAR(8),
    @Nombre_Med VARCHAR(20),
    @Apellido_Med VARCHAR(20),
    @Sexo_Med CHAR(1),
    @Nacionalidad_Med VARCHAR(20),
    @Fecha_Nacimiento_Med DATE,
    @Direccion VARCHAR(50),
    @ID_localidad CHAR(8),
    @Correo_Med VARCHAR(50),
    @Telefono_Med VARCHAR(20),
    @Especialidad CHAR(8)
)
AS
BEGIN
    UPDATE Medicos
    SET
        DNI_Med = @DNI_Med,
        Nombre_Med = @Nombre_Med,
        Apellido_Med = @Apellido_Med,
        Sexo_Med = @Sexo_Med,
        Nacionalidad_Med = @Nacionalidad_Med,
        Fecha_Nacimiento_Med = @Fecha_Nacimiento_Med,
        Direccion = @Direccion,
        Id_Localidad = @ID_localidad,
        Correo_Med = @Correo_Med,
        Telefono_Med = @Telefono_Med,
        Especialidad = @Especialidad
    WHERE Legajo_Med = @Legajo_Med;
END;
GO
*/