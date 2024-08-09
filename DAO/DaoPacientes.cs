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
    public class DaoPacientes
    {
        AccesoDatos ds = new AccesoDatos();

        public Paciente getPaciente(Paciente paciente)
        {
            DataTable tabla = ds.ObtenerTabla("Pacientes", "SELECT DNI_Pa, Nombre_Pa, Apellido_Pa, Sexo_Pa, Nacionalidad_Pa, Fecha_Nacimiento_Pa, Direccion_Pa, ID_Localidad, Provincia_Pa, Correo_Pa, Telefono_Pa, Id_Usuario, estado FROM Pacientes WHERE DNI_Pa ='" + paciente.getDNIPa() + "'");

            if (tabla.Rows.Count > 0)
            {
                paciente.setDNIPa(tabla.Rows[0][0].ToString());
                paciente.setNombrePa(tabla.Rows[0][1].ToString());
                paciente.setApellidoPa(tabla.Rows[0][2].ToString());
                paciente.setSexoPa(Convert.ToChar(tabla.Rows[0][3]));
                paciente.setNacionalidadPa(tabla.Rows[0][4].ToString());
                paciente.setFechaNacimientoPa(Convert.ToDateTime(tabla.Rows[0][5]));
                paciente.setDireccionPa(tabla.Rows[0][6].ToString());
                paciente.setIDLocalidad(tabla.Rows[0][7].ToString());
                paciente.setCorreoPa(tabla.Rows[0][9].ToString());
                paciente.setTelefonoPa(tabla.Rows[0][10].ToString());
                paciente.setIdUsuario(tabla.Rows[0][11].ToString());
                paciente.setEstado(Convert.ToBoolean(tabla.Rows[0][12]));
                return paciente;
            }
            else
            {
                return null;
            }
        }

        public DataTable getTablaPaciente()
        {
            DataTable dt = ds.ObtenerTabla("Pacientes", "SELECT DNI_Pa, Nombre_Pa, Apellido_Pa, Sexo_Pa, Nacionalidad_Pa, Fecha_Nacimiento_Pa, Direccion_Pa, ID_Localidad, Correo_Pa, Telefono_Pa, Id_Usuario, estado FROM Pacientes");
            return dt;
        }

        public DataTable getPacientes()
        {
            DataTable dt = ds.ObtenerTabla("Pacientes", "select * from Pacientes");
            return dt;
        }

        public DataTable getLocalidades()
        {
            return ds.ObtenerTabla("Localidades", "SELECT Id_Localidad, Nombre_Loc FROM Localidades");
        }

        public DataTable getPacientesEstadoTrue()
        {
            string consulta = "SELECT * FROM Pacientes p " +
                      "INNER JOIN Localidades l ON p.ID_localidad = l.ID_localidad " +
                      "INNER JOIN Provincias prov ON l.ID_provincias = prov.ID_provincia " +
                      "WHERE p.estado = 1";

            DataTable dt = ds.ObtenerTabla("Pacientes", consulta);
            return dt;
        }

        public Boolean ExistePaciente(Paciente paciente)
        {
            String consulta = "SELECT DNI_Pa FROM Pacientes WHERE DNI_Pa ='" + paciente.getDNIPa() + "'";
            return ds.existe(consulta);
        }

        public int agregarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPaciente(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPaciente");
        }

        public int eliminarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteEliminar(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarPaciente");
        }

        public int modificarPaciente(Paciente paciente)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPaciente(ref comando, paciente);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarPaciente");
        }

        private void ArmarParametrosPaciente(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNI_Pa", SqlDbType.Char, 8);
            SqlParametros.Value = paciente.getDNIPa();

            SqlParametros = Comando.Parameters.Add("@Nombre_Pa", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getNombrePa();

            SqlParametros = Comando.Parameters.Add("@Apellido_Pa", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getApellidoPa();

            SqlParametros = Comando.Parameters.Add("@Sexo", SqlDbType.Char, 1);
            SqlParametros.Value = paciente.getSexoPa();

            SqlParametros = Comando.Parameters.Add("@Nacionalidad_Pa", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getNacionalidadPa();

            SqlParametros = Comando.Parameters.Add("@Fecha_Nacimiento_Pa", SqlDbType.Date);
            SqlParametros.Value = paciente.getFechaNacimientoPa();

            SqlParametros = Comando.Parameters.Add("@Direccion_Pa", SqlDbType.VarChar, 30);
            SqlParametros.Value = paciente.getDireccionPa();

            SqlParametros = Comando.Parameters.Add("@ID_localidad", SqlDbType.Char, 8);
            SqlParametros.Value = paciente.getIDLocalidad();

            SqlParametros = Comando.Parameters.Add("@Correo_Pa", SqlDbType.VarChar, 50);
            SqlParametros.Value = paciente.getCorreoPa();

            SqlParametros = Comando.Parameters.Add("@Telefono_Pa", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getTelefonoPa();
        }

        private void ArmarParametrosPacienteAgregar(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNIPA", SqlDbType.Char, 8);
            SqlParametros.Value = paciente.getDNIPa();

            SqlParametros = Comando.Parameters.Add("@NOMBREPA", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getNombrePa();

            SqlParametros = Comando.Parameters.Add("@APELLIDOPA", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getApellidoPa();

            SqlParametros = Comando.Parameters.Add("@SEXOPA", SqlDbType.Char, 1);
            SqlParametros.Value = paciente.getSexoPa();

            SqlParametros = Comando.Parameters.Add("@NACIONALIDADPA", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getNacionalidadPa();

            SqlParametros = Comando.Parameters.Add("@FECHANACIMIENTOPA", SqlDbType.Date);
            SqlParametros.Value = paciente.getFechaNacimientoPa();

            SqlParametros = Comando.Parameters.Add("@DIRECCIONPA", SqlDbType.VarChar, 30);
            SqlParametros.Value = paciente.getDireccionPa();

            SqlParametros = Comando.Parameters.Add("@IDLOCALIDAD", SqlDbType.Char, 8);
            SqlParametros.Value = paciente.getIDLocalidad();

            SqlParametros = Comando.Parameters.Add("@CORREOPA", SqlDbType.VarChar, 50);
            SqlParametros.Value = paciente.getCorreoPa();

            SqlParametros = Comando.Parameters.Add("@TELEFONOPA", SqlDbType.VarChar, 20);
            SqlParametros.Value = paciente.getTelefonoPa();

            SqlParametros = Comando.Parameters.Add("@IDUSUARIO", SqlDbType.Char, 6);
            SqlParametros.Value = paciente.getIdUsuario();

            SqlParametros = Comando.Parameters.Add("@ESTADO", SqlDbType.Bit);
            SqlParametros.Value = paciente.getEstado();
        }

        private void ArmarParametrosPacienteEliminar(ref SqlCommand Comando, Paciente paciente)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI_Pa", SqlDbType.Char, 8);
            SqlParametros.Value = paciente.getDNIPa();
        }

        public DataTable FiltrarPacientesPorNombre(string nombre)
        {
            string consulta = "SELECT * FROM Pacientes p " +
                              "INNER JOIN Localidades l ON p.ID_localidad = l.ID_localidad " +
                              "INNER JOIN Provincias prov ON l.ID_provincias = prov.ID_provincia " +
                              "WHERE p.estado = 1 AND p.Nombre_Pa LIKE '%"+nombre+"%'";

            
            DataTable dt = ds.ObtenerTabla("Pacientes", consulta);
            return dt;
        }
    }
}


/*
CREATE PROCEDURE SpAgregarPaciente
(
    @DNI_Pa CHAR(8),
    @Nombre_Pa VARCHAR(20),
    @Apellido_Pa VARCHAR(20),
    @Sexo_Pa CHAR(1),
    @Nacionalidad_Pa VARCHAR(20),
    @Fecha_Nacimiento_Pa DATE,
    @Direccion_Pa VARCHAR(30),
    @ID_localidad CHAR(8),
    @Correo_Pa VARCHAR(50),
    @Telefono_Pa VARCHAR(20),
)
AS
BEGIN
    INSERT INTO Pacientes
    VALUES (@DNI_Pa, @Nombre_Pa, @Apellido_Pa, @Sexo_Pa, @Nacionalidad_Pa, @Fecha_Nacimiento_Pa, @Direccion_Pa, @ID_localidad, @Correo_Pa, @Telefono_Pa);
END;
*/


/*
CREATE PROCEDURE SpEliminarPaciente
(
    @DNI_Pa CHAR(8)
)
AS
BEGIN
    UPDATE Pacientes
    SET estado = 0
    WHERE DNI_Pa = @DNI_Pa;
END;
*/

/*
CREATE PROCEDURE SpModificarPaciente
(
    @DNI_Pa CHAR(8),
    @Nombre_Pa VARCHAR(20),
    @Apellido_Pa VARCHAR(20),
    @Sexo CHAR(1),
    @Nacionalidad_Pa VARCHAR(20),
    @Fecha_Nacimiento_Pa DATE,
    @Direccion_Pa VARCHAR(30),
    @ID_localidad CHAR(8),
    @Correo_Pa VARCHAR(50),
    @Telefono_Pa VARCHAR(20)
)
AS
BEGIN
    UPDATE Pacientes
    SET 
    Nombre_Pa = @Nombre_Pa, 
    Apellido_Pa = @Apellido_Pa, 
    Sexo = @Sexo, 
    Nacionalidad_Pa = @Nacionalidad_Pa, 
    Fecha_Nacimiento_Pa = @Fecha_Nacimiento_Pa, 
    Direccion_Pa = @Direccion_Pa, 
    ID_localidad = @ID_localidad, 
    Correo_Pa = @Correo_Pa, 
    Telefono_Pa = @Telefono_Pa
    WHERE DNI_Pa = @DNI_Pa;
END;
*/