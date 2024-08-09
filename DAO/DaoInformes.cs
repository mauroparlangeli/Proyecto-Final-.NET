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
    public class DaoInformes
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoInformes() { }

        public DataTable ObtenerCantidadPacientesPorLocalidad()
        {
            string consulta = "SELECT p.Id_Localidad as 'IDLocalidad', l.Nombre_Loc as 'Nombre Localidad', COUNT(p.DNI_Pa) AS 'Numero De Pacientes' FROM Pacientes p INNER JOIN Localidades l ON P.Id_Localidad = L.Id_Localidad GROUP BY l.Nombre_Loc, p.Id_Localidad";
            DataTable dt = ds.ObtenerTabla("CantidadPacientesPorLocalidad", consulta);
            return dt;
        }

        public DataTable ObtenerPromedioEdadPacientes()
        {
            string consulta = "SELECT AVG(DATEDIFF(year, Fecha_Nacimiento_Pa, GETDATE())) AS 'Edad Promedio' FROM Pacientes";
            DataTable dt = ds.ObtenerTabla("PromedioEdadPacientes", consulta);
            return dt;
        }
        public DataTable ObtenerPacientesDadosDeBaja()
        {
            string consulta = "SELECT DNI_Pa AS 'DNI', Nombre_Pa AS 'Nombre', Apellido_Pa AS 'Apellido', Sexo, Nacionalidad_Pa AS 'Nacionalidad', Fecha_Nacimiento_Pa AS 'Fecha de Nacimiento', Direccion_Pa AS 'Direccion', Nombre_Loc AS 'Localidad', Correo_Pa AS 'Correo electronico',	Telefono_Pa AS 'Telefono' FROM Pacientes p INNER JOIN Localidades l ON p.Id_Localidad = l.Id_Localidad WHERE estado = 0";
            DataTable dt = ds.ObtenerTabla("PacientesDadosDeBaja", consulta);
            return dt;
        }

        public DataTable ObtenerMedicosDadosDeBaja()
        {
            string consulta = "SELECT m.Legajo_Med AS 'Legajo', m.DNI_Med AS 'DNI', m.Nombre_Med AS 'Nombre', m.Apellido_Med AS 'Apellido', m.Sexo_Med AS 'Sexo', m.Nacionalidad_Med AS 'Nacionalidad', m.Fecha_Nacimiento_Med AS 'Fecha de Nacimiento', m.Direccion AS 'Direccion', l.Nombre_Loc AS 'Localidad', m.Correo_Med AS 'Correo electronico', m.Telefono_Med AS 'Telefono', e.Nombre_Especialidad AS 'Especialidad' " +
                      "FROM Medicos m " +
                      "INNER JOIN Localidades l ON m.Id_Localidad = l.Id_Localidad " +
                      "INNER JOIN Especialidades e ON m.Especialidad = e.Id_Especialidad " +
                      "WHERE m.estado = 0";
            DataTable dt = ds.ObtenerTabla("MedicosDadosDeBaja", consulta);
            return dt;
        }

        public DataTable ObtenerTurnosMedicos(string legajo)
        {
            string consulta = "SELECT T.Nro_Turno AS [Nro Turno], P.Nombre_Pa AS [Paciente], T.Fecha AS [Fecha], T.Horario AS [Horario] " +
                              "FROM Turnos T " +
                              "INNER JOIN Pacientes P ON T.DNI_Paciente = P.DNI_Pa " +
                              "WHERE T.Legajo_Med = " + legajo;
            DataTable dt = ds.ObtenerTabla("TurnosMedicos", consulta);
            return dt;
        }
    }
}
