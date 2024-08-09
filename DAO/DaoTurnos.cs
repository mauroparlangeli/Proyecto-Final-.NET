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
    public class DaoTurnos
    {
        AccesoDatos ds = new AccesoDatos();

        public DataTable obtenerEspecialidad() ///Para luego cargar el ddl Especialidades
        {
            return ds.ObtenerTabla("Turnos", "Select * from Especialidad");
        }

        public Turnos GetTurnos (Turnos Turno)///para filtrar
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", "SELECT Nro_Turno, DNI_Paciente, Legajo_Med, fecha, horario, observaciones, Asistencia FROM Turnos WHERE Nro_Turno ='" + Turno.GetNro_Turno() + "'");

            if (tabla.Rows.Count > 0)
            {
                Turno.setNro_Turno(Convert.ToInt16(tabla.Rows[0][0]));
                Turno.setDNI_Paciente(tabla.Rows[0][1].ToString());
                Turno.setLegajo_Med(tabla.Rows[0][2].ToString());
                Turno.setfecha(tabla.Rows[0][3].ToString());
                Turno.sethorario(tabla.Rows[0][4].ToString());
                Turno.setObvservaciones(tabla.Rows[0][5].ToString());
                Turno.setAsistencia(Convert.ToBoolean(tabla.Rows[0][6]));
                return Turno;
            }
            else
            {
                return null;
            }

        }

        public DataTable getTablaTurnos()
        {
            DataTable dt = ds.ObtenerTabla("Turnos", "SELECT Nro_Turno, DNI_Paciente, Legajo_Med, fecha, horario, observaciones, Asistencia FROM Turnos");
            return dt;
        }

        public Boolean ExisteTurno(Turnos Turno)
        {
            String consulta = "SELECT Nro_Turno, DNI_Paciente, Legajo_Med, fecha, horario, observaciones, Asistencia FROM Turnos WHERE Nro_Turno ='" + Turno.GetNro_Turno() + "'";
            return ds.existe(consulta);
        }

        public Boolean TurnoOcupado(Turnos Turno)
        {
            String consulta = "SELECT * FROM Turnos WHERE Legajo_Med ='" + Turno.GetLegajo_Med() + "' and Fecha ='" + Turno.Getfecha() + "' and Horario ='" + Turno.Gethorario() + "'";
            return ds.existe(consulta);
        }

        public bool agregarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoAgregar(ref comando, turno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno") > 0;
        }

        public bool ModificarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoModificar(ref comando, turno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SpModificarTurno") > 0;
        }
        private void ArmarParametrosTurnoAgregar(ref SqlCommand Comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();

            SqlParametros = Comando.Parameters.Add("@DNI_Paciente", SqlDbType.Char, 8);
            SqlParametros.Value = turno.GetDNI_Paciente();

            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = turno.GetLegajo_Med();

            SqlParametros = Comando.Parameters.Add("@Fecha", SqlDbType.Char, 10);
            SqlParametros.Value = turno.Getfecha();

            SqlParametros = Comando.Parameters.Add("@Horario", SqlDbType.Char, 8);
            SqlParametros.Value = turno.Gethorario();

            SqlParametros = Comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 255);
            SqlParametros.Value = turno.GetObvservaciones();

            SqlParametros = Comando.Parameters.Add("@Asistencia", SqlDbType.Bit);
            SqlParametros.Value = turno.GetAsistencia();
        }

        private void ArmarParametrosTurnoModificar(ref SqlCommand Comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI_Paciente", SqlDbType.Char, 8);
            SqlParametros.Value = turno.GetDNI_Paciente();

            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = turno.GetLegajo_Med();

            SqlParametros = Comando.Parameters.Add("@Fecha", SqlDbType.Char, 10);
            SqlParametros.Value = turno.Getfecha();

            SqlParametros = Comando.Parameters.Add("@Horario", SqlDbType.Char, 8);
            SqlParametros.Value = turno.Gethorario();

            SqlParametros = Comando.Parameters.Add("@Observaciones", SqlDbType.VarChar, 500);
            SqlParametros.Value = turno.GetObvservaciones();

            SqlParametros = Comando.Parameters.Add("@Asistencia", SqlDbType.Bit);
            SqlParametros.Value = turno.GetAsistencia();
        }
    }
}
/*
CREATE PROCEDURE spAgregarTurno
(
    @DNI_Paciente CHAR(8),
    @Legajo_Med CHAR(6),
    @Fecha CHAR(10), 
    @Horario CHAR(8), 
    @Observaciones VARCHAR(255),
    @Asistencia BIT
)
AS
BEGIN
    INSERT INTO Turnos
    (
        DNI_Paciente,
        Legajo_Med,
        Fecha,
        Horario,
        Observaciones,
        Asistencia
    )
    VALUES
    (
        @DNI_Paciente,
        @Legajo_Med,
        @Fecha,
        @Horario,
        @Observaciones,
        @Asistencia
    );
END
GO
 */